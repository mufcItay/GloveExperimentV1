using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;

namespace CommonTools
{
    public interface ICSVFile
    {
        bool WriteLine(string line);
        bool WriteLine(string[] valuePerColumn);
        bool WriteLines(IEnumerable<string[]> valuePerColumnEnumer);
        bool WriteLines(IEnumerable<string> lines);

        void Init(string fileName, string seperator = ",", IEnumerable<string> csvColumns = null, IBaseCSVRWSettings settings = null);
        void Close();

        IEnumerable<string[]> ReadLines();
        string[] ReadLine();
    }

    public interface IBaseCSVRWSettings
    {

    }

    [Serializable]
    public class BatchCSVRWSettings : IBaseCSVRWSettings
    {
        internal const uint DEFAULT_READ_BATCH_SIZE = 1;
        internal const uint DEFAULT_WRITE_BATCH_SIZE = 1;

        internal const uint DEFAULT_WRITE_DELAY_MSEC = 0;
        internal const uint DEFAULT_READ_DELAY_MSEC = 0;

        /// <summary>
        /// number of lines to read in batch mode
        /// </summary>
        public uint ReadBatchSize { get; set; }

        /// <summary>
        /// number of lines to write in batch mode
        /// </summary>
        public uint WriteBatchSize { get; set; }

        /// <summary>
        /// number of msecs to wait between reading batches of lines to file
        /// </summary>
        public uint ReadBatchDelayMsec { get; set; }

        /// <summary>
        /// number of msecs to wait between writing batches of lines to file
        /// </summary>
        public uint WriteBatchDelayMsec { get; set; }

        public BatchCSVRWSettings()
        {
            ReadBatchSize = DEFAULT_READ_BATCH_SIZE;
            WriteBatchSize = DEFAULT_WRITE_BATCH_SIZE;
        }
    }


    public class CSVFile : ICSVFile
    {
        protected FileStream mFile;
        protected IEnumerable<string> mColumns;
        protected string mSeperator;
        protected StreamWriter mWriter;
        protected StreamReader mReader;
        protected IBaseCSVRWSettings mSettings;
        private Thread mReadThread;
        private Thread mWriteThread;
        private bool mIsAlive = true;
        private AutoResetEvent mWThreadSleepEvent;
        private AutoResetEvent mRThreadSleepEvent;

        private Queue<string[]> mRemainingBatchUnSeperated;
        private object mQueueLock;

        public event Action<IEnumerable<string[]>> OnLinesReady;

        public BatchCSVRWSettings Settings
        {
            get
            {
                return mSettings as BatchCSVRWSettings;
            }
        }

        void ICSVFile.Init(string fileName, string seperator, IEnumerable<string> csvColumns, IBaseCSVRWSettings settings)
        {
            Init(fileName, seperator, csvColumns, settings);
        }

        void Init(string fileName, string seperator = ",", IEnumerable<string> csvColumns = null, IBaseCSVRWSettings settings = null)
        {
            Init(new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite), seperator, csvColumns, settings);
        }
        public void Init(FileStream fs, char seperator = ',', IEnumerable<string> csvColumns = null, IBaseCSVRWSettings settings = null) 
        {
            Init(fs, seperator.ToString(), csvColumns, settings);
        }

        public void Init(string fileName, char seperator = ',', IEnumerable<string> csvColumns = null, IBaseCSVRWSettings settings = null)
        {
           Init(new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite), seperator, csvColumns, settings);
        }
    
        public void Init(FileStream fs, string seperator = ",", IEnumerable<string> csvColumns = null, IBaseCSVRWSettings settings = null)
        {
            mFile = fs;
            mRemainingBatchUnSeperated = new Queue<string[]>();
            mWThreadSleepEvent = new AutoResetEvent(false);
            mRThreadSleepEvent = new AutoResetEvent(false);
            mQueueLock = new object();
            mColumns = csvColumns;
            mSeperator = seperator;
            mWriter = new StreamWriter(mFile);
            mWriter.AutoFlush = true;
            mReader = new StreamReader(mFile);
            mReader.BaseStream.Position = 0;
            mSettings = settings;
            if (mSettings == null)
            {
                mSettings = new BatchCSVRWSettings();
            }

            if (mFile.Length == 0)
            {
                AppendLineToFile(csvColumns.ToArray());
            }
            else
            {
                // read columns line
                mReader.ReadLine();
            }
        }

        public string[] ReadLine()
        {
            string line = mReader.ReadLine();
            if (line == null)
            {
                return null;
            }
            return line.Split(new string[] { mSeperator }, StringSplitOptions.RemoveEmptyEntries);
        }

        public IEnumerable<string[]> ReadLines()
        {
            IList<string[]> csvLines = new List<string[]>();

            if (Settings.ReadBatchDelayMsec == 0)
            {
                while (!mReader.EndOfStream)
                {
                    for (int i = 0; i < Settings.ReadBatchSize; i++)
                    {
                        csvLines.Add(ReadLine());
                    }
                }
            }
            else
            {
                if (mReadThread == null)
                {
                    mReadThread = new Thread(new ThreadStart(ReaderThreadFunc));
                    mReadThread.Start();
                }
            }


            return csvLines;
        }

        private void ReaderThreadFunc()
        {
            IList<string[]> csvLines = new List<string[]>();

            while (mIsAlive && !mReader.EndOfStream)
            {
                csvLines.Clear();

                for (int i = 0; i < Settings.ReadBatchSize; i++)
                {
                    string[] line = ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    csvLines.Add(line);
                }

                if (csvLines.Count != 0 && OnLinesReady != null)
                {
                    OnLinesReady(csvLines);
                }

                mRThreadSleepEvent.WaitOne((int)Settings.ReadBatchDelayMsec);
            }
        }

        public bool WriteLine(string line)
        {
            if (mFile == null)
            {
                return false;
            }

            if (Settings.WriteBatchDelayMsec == 0)
            {
                AppendLineToFile(SeperateLine(line));
            }
            else
            {
                lock (mQueueLock)
                {
                    mRemainingBatchUnSeperated.Enqueue(SeperateLine(line));
                }
                CreateWriterThreadIfNeeded();
            }

            return true;
        }

        private string[] floatToStringArray(float[] floatLine)
        {
            string[] strArr = new string[floatLine.Length];
            for (int i =0; i < floatLine.Length; ++i)
            {
                strArr[i] = floatLine[i].ToString();
            }
            return strArr;
        }

        public bool WriteLine(float[] valuePerColumn)
        {
            return WriteLine(floatToStringArray(valuePerColumn));
        }

        public bool WriteLine(string[] valuePerColumn)
        {
            if (mFile == null)
            {
                return false;
            }

            if (Settings.WriteBatchDelayMsec == 0)
            {
                AppendLineToFile(valuePerColumn);
            }
            else
            {
                lock (mQueueLock)
                {
                    mRemainingBatchUnSeperated.Enqueue(valuePerColumn); 
                }
                CreateWriterThreadIfNeeded();
            }

            return true;
        }

        public bool WriteLines(IEnumerable<string[]> valuePerColumnEnumer)
        {
            if (mFile == null)
            {
                return false;
            }

            if (Settings.WriteBatchDelayMsec == 0)
            {
                AppendLinesToFile(valuePerColumnEnumer);
            }
            else
            {
                lock (mQueueLock)
                {
                    foreach (var line in valuePerColumnEnumer)
                    {
                        mRemainingBatchUnSeperated.Enqueue(line);
                    } 
                }
                CreateWriterThreadIfNeeded();
            }
            return true;
        }

        public bool WriteLines(IEnumerable<string> lines)
        {
            if (mFile == null)
            {
                return false;
            }

            if (Settings.WriteBatchDelayMsec == 0)
            {
                List<string[]> seperatedLines = new List<string[]>();
                foreach (var line in lines)
                {
                    seperatedLines.Add(SeperateLine(line));
                }
                AppendLinesToFile(seperatedLines);
            }
            else
            {
                lock (mQueueLock)
                {
                    foreach (var line in lines)
                    {
                        mRemainingBatchUnSeperated.Enqueue(SeperateLine(line));
                    } 
                }
                CreateWriterThreadIfNeeded();
            }
            return true;
        }

        private void CreateWriterThreadIfNeeded()
        {
            if (mWriteThread == null)
            {
                mWriteThread = new Thread(new ThreadStart(WriterThreadFunc));
                mWriteThread.Start();
            }
        }


        private void WriterThreadFunc()
        {
            List<string[]> currentBatch = new List<string[]>();
            while (mIsAlive)
            {
                lock (mQueueLock)
                {
                    if (mRemainingBatchUnSeperated.Any())
                    {
                        int currentBatchSize = (int)Math.Min(mRemainingBatchUnSeperated.Count, Settings.WriteBatchSize);
                        for (int i = 0; i < currentBatchSize; i++)
                        {
                            string[] line = mRemainingBatchUnSeperated.Dequeue();
                            currentBatch.Add(line);
                        }
                        AppendLinesToFile(currentBatch);
                    }
                }

                currentBatch.Clear();

                mWThreadSleepEvent.WaitOne((int)Settings.WriteBatchDelayMsec);
            }
            lock (mQueueLock)
            {
                if (mRemainingBatchUnSeperated.Any())
                {
                    while (mRemainingBatchUnSeperated.Any())
                    {
                        string[] line = mRemainingBatchUnSeperated.Dequeue();
                        currentBatch.Add(line);
                    }

                    AppendLinesToFile(currentBatch);
                }
            }
        }

        public virtual void Close()
        {
            mIsAlive = false;
            if (mReadThread != null)
            {
                mRThreadSleepEvent.Set();
                mReadThread.Join();
            }
            if (mWriteThread != null)
            {
                mWThreadSleepEvent.Set();
                mWriteThread.Join();
            }
            mFile.Close();
        }

        protected string[] SeperateLine(string line)
        {
            return line.Split(new string[] { mSeperator }, StringSplitOptions.RemoveEmptyEntries);
        }

        protected void AppendLinesToFile(IEnumerable<string[]> valuePerColumnEnumer)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var line in valuePerColumnEnumer)
            {
                for (int i=0; i< line.Length; i++)
                {
                    sb.Append(line[i]);
                    if (i != line.Length)
                    {
                        sb.Append(mSeperator);
                    }
                }
                sb.AppendLine();
            }

            mWriter.Write(sb.ToString());
        }

        protected void AppendLineToFile(string[] line)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in line)
            {
                sb.Append(item);
                if (!item.Equals(line.Last()))
                {
                    sb.Append(mSeperator);
                }
            }
            mWriter.WriteLine(sb.ToString());
        }

    }
}
