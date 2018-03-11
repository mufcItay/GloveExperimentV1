using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    public class HandCoordinates : Dictionary<FingerType, float[]>, ICloneable, IHandData
    {
        float[] mCurrentSensorsScaled;

        public HandCoordinates()
        {
            float[] sensors = new float[CommonConstants.SCALED_SESORS_ARRAY_LENGTH];
            InitDict(sensors);
        }

        public HandCoordinates(float[] scaledSensors)
        {
            InitDict(scaledSensors);
        }

        public HandCoordinates(string[] scaledSensors)
        {
            float[] scaledSensorsFloat = StringArrayToFloatArray(scaledSensors);

            InitDict(scaledSensorsFloat);
        }

        private float[] StringArrayToFloatArray(string[] scaledSensors)
        {
            float[] scaledSensorsFloat = new float[scaledSensors.Length];
            for (int i = 0; i < scaledSensors.Length; i++)
            {
                scaledSensorsFloat[i] = float.Parse(scaledSensors[i]);
            }

            return scaledSensorsFloat;
        }

        private void InitDict(float[] scaledSensors)
        {
            mCurrentSensorsScaled = scaledSensors;

            Add(FingerType.Index, new float[] { scaledSensors[(int)EfdSensors.FD_INDEXNEAR], scaledSensors[(int)EfdSensors.FD_INDEXFAR] });
            Add(FingerType.Little, new float[] { scaledSensors[(int)EfdSensors.FD_LITTLENEAR], scaledSensors[(int)EfdSensors.FD_LITTLEFAR] });
            Add(FingerType.Middle, new float[] { scaledSensors[(int)EfdSensors.FD_MIDDLENEAR], scaledSensors[(int)EfdSensors.FD_MIDDLEFAR] });
            Add(FingerType.Ring, new float[] { scaledSensors[(int)EfdSensors.FD_RINGNEAR], scaledSensors[(int)EfdSensors.FD_RINGFAR] });
            Add(FingerType.Thumb, new float[] { scaledSensors[(int)EfdSensors.FD_THUMBNEAR], scaledSensors[(int)EfdSensors.FD_THUMBFAR] });
        }

        private void UpdateValues(string[] scaledSensors)
        {
            float[] scaledSensorsFloat = StringArrayToFloatArray(scaledSensors);
            UpdateValues(scaledSensorsFloat);
        }

        private void UpdateValues(float[] scaledSensors)
        {
            mCurrentSensorsScaled = scaledSensors;

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

        public object Clone()
        {
            HandCoordinates copy = new HandCoordinates(mCurrentSensorsScaled);
            return copy;
        }

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
    }
}
