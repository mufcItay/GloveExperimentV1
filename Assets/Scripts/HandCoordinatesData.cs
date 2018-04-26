using CommonTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JasHandExperiment
{
    /// <summary>
    /// the class is an implementation of IHandData, gives data about each bone in a finger in the hand.
    /// suitable to 5DT glove sensors data.
    /// inherites from Dictionary, in order to save inner state for each finger (FingerType),
    /// and in each finger to each bone (float[] each cell is a bone).
    /// </summary>
    public class HandCoordinatesData : Dictionary<FingerType, float[]>, IHandData
    {
        #region Data Members
        /// <summary>
        /// current sensors information
        /// </summary>
        float[] mCurrentSensorsScaled;

        /// <summary>
        /// The time stamp of current coordinates
        /// </summary>
        public string TimeStamp { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// creates the structure with initialized member values
        /// </summary>
        public HandCoordinatesData()
        {
            float[] sensors = new float[CommonConstants.SCALED_SESORS_ARRAY_LENGTH];
            TimeStamp = DateTime.Now.ToLongTimeString();
            InitDict(sensors);
        }

        /// <summary>
        /// creates an instance with given hand movement data
        /// </summary>
        /// <param name="scaledSensors">the initial hand data</param>
        public HandCoordinatesData(float[] scaledSensors)
        {
            TimeStamp = DateTime.Now.ToLongTimeString();
            InitDict(scaledSensors);
        }

        /// <summary>
        /// creates an instance with given hand movement data
        /// </summary>
        /// <param name="scaledSensors">the initial hand data - string flavour</param>
        public HandCoordinatesData(string[] scaledSensors)
        {
            TimeStamp = DateTime.Now.ToLongTimeString();
            // cast and launch
            float[] scaledSensorsFloat = StringUtilities.StringArrayToFloatArray(scaledSensors);
            InitDict(scaledSensorsFloat);
        } 
        #endregion

        #region Functions
        /// <summary>
        /// the functino convers string array to float array
        /// </summary>
        /// <param name="scaledSensors"></param>
        /// <returns></returns>
        
        /// <summary>
        /// the fucntino initialzied the inner dictionary by given params
        /// </summary>
        /// <param name="scaledSensors">the hand data for each bone and finger to set</param>
        private void InitDict(float[] scaledSensors)
        {
            mCurrentSensorsScaled = scaledSensors;
            // add each finger and then value per bone
            Add(FingerType.Index, new float[] { scaledSensors[(int)EfdSensors.FD_INDEXNEAR], scaledSensors[(int)EfdSensors.FD_INDEXFAR], scaledSensors[(int)EfdSensors.FD_INDEXFAR] });
            Add(FingerType.Little, new float[] { scaledSensors[(int)EfdSensors.FD_LITTLENEAR], scaledSensors[(int)EfdSensors.FD_LITTLEFAR], scaledSensors[(int)EfdSensors.FD_LITTLEFAR] });
            Add(FingerType.Middle, new float[] { scaledSensors[(int)EfdSensors.FD_MIDDLENEAR], scaledSensors[(int)EfdSensors.FD_MIDDLEFAR], scaledSensors[(int)EfdSensors.FD_MIDDLEFAR] });
            Add(FingerType.Ring, new float[] { scaledSensors[(int)EfdSensors.FD_RINGNEAR], scaledSensors[(int)EfdSensors.FD_RINGFAR], scaledSensors[(int)EfdSensors.FD_RINGFAR] });
            Add(FingerType.Thumb, new float[] { scaledSensors[(int)EfdSensors.FD_THUMBNEAR], scaledSensors[(int)EfdSensors.FD_THUMBFAR], scaledSensors[(int)EfdSensors.FD_THUMBFAR] });
        }

        /// <summary>
        /// the function updates the values of data for each bone and finger according to given data.
        /// </summary>
        /// <param name="scaledSensors">hand data to update - string flavour</param>
        private void UpdateValues(string[] scaledSensors, ushort[] max = null, ushort[] min = null)
        {
            // cast and launch
            float[] scaledSensorsFloat = StringUtilities.StringArrayToFloatArray(scaledSensors);
            UpdateValues(scaledSensorsFloat,max,min);
        }
        
        /// <summary>
        /// the function updates the values of data for each bone and finger according to given data.
        /// </summary>
        /// <param name="sensorsData">hand data to update</param>
        private void UpdateValues(float[] sensorsData, ushort[] max = null, ushort[] min = null)
        {
            mCurrentSensorsScaled = sensorsData;
            // sets per each bone and finger the current scaled sensor hand data
            this[FingerType.Index][(int)BoneSection.Near] = sensorsData[(int)EfdSensors.FD_INDEXNEAR];
            this[FingerType.Index][(int)BoneSection.Inter] = sensorsData[(int)EfdSensors.FD_INDEXFAR];
            this[FingerType.Index][(int)BoneSection.Far] = sensorsData[(int)EfdSensors.FD_INDEXFAR];
            this[FingerType.Little][(int)BoneSection.Near] = sensorsData[(int)EfdSensors.FD_LITTLENEAR];
            this[FingerType.Little][(int)BoneSection.Inter] = sensorsData[(int)EfdSensors.FD_LITTLEFAR];
            this[FingerType.Little][(int)BoneSection.Far] = sensorsData[(int)EfdSensors.FD_LITTLEFAR];
            this[FingerType.Middle][(int)BoneSection.Near] = sensorsData[(int)EfdSensors.FD_MIDDLENEAR];
            this[FingerType.Middle][(int)BoneSection.Inter] = sensorsData[(int)EfdSensors.FD_MIDDLEFAR];
            this[FingerType.Middle][(int)BoneSection.Far] = sensorsData[(int)EfdSensors.FD_MIDDLEFAR];
            this[FingerType.Ring][(int)BoneSection.Near] = sensorsData[(int)EfdSensors.FD_RINGNEAR];
            this[FingerType.Ring][(int)BoneSection.Inter] = sensorsData[(int)EfdSensors.FD_RINGFAR];
            this[FingerType.Ring][(int)BoneSection.Far] = sensorsData[(int)EfdSensors.FD_RINGFAR];
            this[FingerType.Thumb][(int)BoneSection.Near] = sensorsData[(int)EfdSensors.FD_THUMBNEAR];
            this[FingerType.Thumb][(int)BoneSection.Inter] = sensorsData[(int)EfdSensors.FD_THUMBFAR];
            this[FingerType.Thumb][(int)BoneSection.Far] = sensorsData[(int)EfdSensors.FD_THUMBFAR];
        }

        /// <summary>
        /// the fucntion clonescurrent instance
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            HandCoordinatesData copy = new HandCoordinatesData(mCurrentSensorsScaled);
            copy.TimeStamp = this.TimeStamp;
            return copy;
        }

        /// <summary>
        /// the function sets inner state according to data
        /// </summary>
        /// <param name="data">the data about hand movements to set inner state from</param>
        public void SetHandMovementData(object data)
        {
            if (data is string[])
            {
                UpdateValues(data as string[], CalibrationManager.UpperCalibValues, CalibrationManager.LowerCalibValues);
            }
            else if (data is float[])
            {
                UpdateValues(data as float[], CalibrationManager.UpperCalibValues, CalibrationManager.LowerCalibValues);
            }
            else
            {
                Debug.Log("hand movement data is not a the correct format (not in a suitable type)");
            }
        } 
        #endregion
    }
}
