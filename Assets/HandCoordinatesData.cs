using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
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
        #endregion

        #region Ctors
        /// <summary>
        /// creates the structure with initialized member values
        /// </summary>
        public HandCoordinatesData()
        {
            float[] sensors = new float[CommonConstants.SCALED_SESORS_ARRAY_LENGTH];
            InitDict(sensors);
        }

        /// <summary>
        /// creates an instance with given hand movement data
        /// </summary>
        /// <param name="scaledSensors">the initial hand data</param>
        public HandCoordinatesData(float[] scaledSensors)
        {
            InitDict(scaledSensors);
        }

        /// <summary>
        /// creates an instance with given hand movement data
        /// </summary>
        /// <param name="scaledSensors">the initial hand data - string flavour</param>
        public HandCoordinatesData(string[] scaledSensors)
        {
            // cast and launch
            float[] scaledSensorsFloat = StringArrayToFloatArray(scaledSensors);
            InitDict(scaledSensorsFloat);
        } 
        #endregion

        #region Functions
        /// <summary>
        /// the functino convers string array to float array
        /// </summary>
        /// <param name="scaledSensors"></param>
        /// <returns></returns>
        private float[] StringArrayToFloatArray(string[] scaledSensors)
        {
            float[] scaledSensorsFloat = new float[scaledSensors.Length];
            for (int i = 0; i < scaledSensors.Length; i++)
            {
                scaledSensorsFloat[i] = float.Parse(scaledSensors[i]);
            }

            return scaledSensorsFloat;
        }

        /// <summary>
        /// the fucntino initialzied the inner dictionary by given params
        /// </summary>
        /// <param name="scaledSensors">the hand data for each bone and finger to set</param>
        private void InitDict(float[] scaledSensors)
        {
            mCurrentSensorsScaled = scaledSensors;
            // add each finger and then value per bone
            Add(FingerType.Index, new float[] { scaledSensors[(int)EfdSensors.FD_INDEXNEAR], scaledSensors[(int)EfdSensors.FD_INDEXFAR] });
            Add(FingerType.Little, new float[] { scaledSensors[(int)EfdSensors.FD_LITTLENEAR], scaledSensors[(int)EfdSensors.FD_LITTLEFAR] });
            Add(FingerType.Middle, new float[] { scaledSensors[(int)EfdSensors.FD_MIDDLENEAR], scaledSensors[(int)EfdSensors.FD_MIDDLEFAR] });
            Add(FingerType.Ring, new float[] { scaledSensors[(int)EfdSensors.FD_RINGNEAR], scaledSensors[(int)EfdSensors.FD_RINGFAR] });
            Add(FingerType.Thumb, new float[] { scaledSensors[(int)EfdSensors.FD_THUMBNEAR], scaledSensors[(int)EfdSensors.FD_THUMBFAR] });
        }

        /// <summary>
        /// the function updates the values of data for each bone and finger according to given data.
        /// </summary>
        /// <param name="scaledSensors">hand data to update - string flavour</param>
        private void UpdateValues(string[] scaledSensors)
        {
            // cast and launch
            float[] scaledSensorsFloat = StringArrayToFloatArray(scaledSensors);
            UpdateValues(scaledSensorsFloat);
        }


        /// <summary>
        /// the function updates the values of data for each bone and finger according to given data.
        /// </summary>
        /// <param name="scaledSensors">hand data to update</param>
        private void UpdateValues(float[] scaledSensors)
        {
            mCurrentSensorsScaled = scaledSensors;
            // sets per each bone and finger the current scaled sensor hand data
            this[FingerType.Index][(int)BoneSection.Near] = scaledSensors[(int)EfdSensors.FD_INDEXNEAR];
            this[FingerType.Index][(int)BoneSection.Far] = scaledSensors[(int)EfdSensors.FD_INDEXFAR];
            this[FingerType.Little][(int)BoneSection.Near] = scaledSensors[(int)EfdSensors.FD_LITTLENEAR];
            this[FingerType.Little][(int)BoneSection.Far] = scaledSensors[(int)EfdSensors.FD_LITTLEFAR];
            this[FingerType.Middle][(int)BoneSection.Near] = scaledSensors[(int)EfdSensors.FD_MIDDLENEAR];
            this[FingerType.Middle][(int)BoneSection.Far] = scaledSensors[(int)EfdSensors.FD_MIDDLEFAR];
            this[FingerType.Ring][(int)BoneSection.Near] = scaledSensors[(int)EfdSensors.FD_RINGNEAR];
            this[FingerType.Ring][(int)BoneSection.Far] = scaledSensors[(int)EfdSensors.FD_RINGFAR];
            this[FingerType.Thumb][(int)BoneSection.Near] = scaledSensors[(int)EfdSensors.FD_THUMBNEAR];
            this[FingerType.Thumb][(int)BoneSection.Far] = scaledSensors[(int)EfdSensors.FD_THUMBFAR];
        }

        /// <summary>
        /// the fucntion clonescurrent instance
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            HandCoordinatesData copy = new HandCoordinatesData(mCurrentSensorsScaled);
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
                UpdateValues(data as string[]);
            }
            else if (data is float[])
            {
                UpdateValues(data as float[]);
            }
            else
            {
                //ERROR
            }
        } 
        #endregion
    }
}
