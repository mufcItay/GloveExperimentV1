using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TestGame
{
    public class Finger
    {
        private Quaternion[] mInitialRotate;
        private FingerType mFingerType;
        private Transform[] mBones;

        public FingerType FingerType { get { return mFingerType; } }

        public Finger(Transform handController, FingerType fingerType)
        {
            mFingerType = fingerType;
            int numOfBoneSections = Enum.GetValues(typeof(BoneSection)).Length;
            mBones = new Transform[numOfBoneSections];

            var fingerTransform = CommonUtilities.GetFingerObject(handController, mFingerType);
            // get prox bone
            mBones[(int)BoneSection.Near] = fingerTransform.GetChild(0);
            // get dist bone
            mBones[(int)BoneSection.Far] = fingerTransform.GetChild(0).GetChild(0).GetChild(0);

            SetInitialRotation(numOfBoneSections);
        }

        public void ResetRotation()
        {
            if (mInitialRotate == null)
            {
                return;
            }

            for (int i = 0; i < mBones.Length; i++)
            {
                mBones[i].rotation = mInitialRotate[i];
            }
        }

        public void Rotate(HandCoordinates coordinates)
        {
            ResetRotation();
            for (int i = 0; i < mBones.Length; i++)
            {
                float angle = -90 * coordinates[mFingerType][i];
                mBones[i].Rotate(Vector3.right, angle);
                Debug.Log("Current Angle : " + angle.ToString());
            }
        }

        private void SetInitialRotation(int numOfBoneSections)
        {
            mInitialRotate = new Quaternion[numOfBoneSections];
            mInitialRotate[(int)BoneSection.Near] = mBones[(int)BoneSection.Near].rotation;
            mInitialRotate[(int)BoneSection.Far] = mBones[(int)BoneSection.Far].rotation;
        }
    }
}
