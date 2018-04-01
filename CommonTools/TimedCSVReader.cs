using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonTools
{
    /// <summary>
    /// the class reads from a CSVFile only if time for the line is reached. should enable synchronized read from multiple readers.
    /// </summary>
    public class TimedCSVReader
    {
        #region Data Members

        /// <summary>
        /// The CSVFile to read from.
        /// </summary>
        private CSVFile mFile;

        /// <summary>
        /// the index of time column in the file.
        /// </summary>
        private int mTimeIndex;


        /// <summary>
        /// saves last datetime of updated coordinates to stay insync with file
        /// </summary>
        DateTime mLastCoordinatesUpdated = DateTime.MinValue;

        /// <summary>
        /// how many milli seconds to wait for applying line read to hand coordinates
        /// </summary>
        double mTimeToWaitTillApplyingUpdateMsec = 0;

        /// <summary>
        /// stores next line to be read when time is right and update coordinates
        /// </summary>
        string[] mNextLineToUpdate;

        /// <summary>
        /// stores the datetime for the next update of coordinates
        /// </summary>
        DateTime mNextLineDateTime;

        #endregion

        #region MyRegion

        /// <summary>
        /// constructs the CSV file reader
        /// </summary>
        /// <param name="file">the file to read from</param>
        public TimedCSVReader(CSVFile file, int timeColumnIndex)
        {
            mFile = file;
            mTimeIndex = timeColumnIndex;
        }

        #endregion

        /// <summary>
        /// the functino reads a line from the CSVFile.
        /// if the file is finished or if it's yet the time to read the line null is returned.
        /// </summary>
        /// <returns>an array of csv values of a single line, 
        /// or null if file has finished or we need to wait more time for next read</returns>
        public string[] ReadLine()
        {
            DateTime lastDT;
            string[] currentLine;
            double timeSinceLastUpdateMsec = (DateTime.Now - mLastCoordinatesUpdated).TotalMilliseconds;
            if (timeSinceLastUpdateMsec > mTimeToWaitTillApplyingUpdateMsec)
            {
                // if first read, actually read otherwise get next line the was previously read
                currentLine = (mNextLineToUpdate == null) ? mFile.ReadLine() : mNextLineToUpdate;
                // if end of file
                if (currentLine == null)
                {
                    return null;
                }
                lastDT = DateTime.Parse(currentLine[mTimeIndex]);
                mNextLineToUpdate = mFile.ReadLine();
                mNextLineDateTime = DateTime.Parse(mNextLineToUpdate[mTimeIndex]);
                mTimeToWaitTillApplyingUpdateMsec = (mNextLineDateTime - lastDT).TotalMilliseconds;
                mLastCoordinatesUpdated = DateTime.Now;

                return currentLine;
            }

            return null;
        }
    }
}
