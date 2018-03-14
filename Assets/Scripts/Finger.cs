using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JasHandExperiment
{
    /// <summary>
    /// the class represents a finger in a hand. being held by an experiment strategy
    /// </summary>
    public class Finger
    {
        #region Data Members
        /// <summary>
        /// the initial position of the finger
        /// </summary>
        private Quaternion[] mInitialRotate;

        /// <summary>
        /// The type of the finger
        /// </summary>
        private FingerType mFingerType;

        /// <summary>
        /// the bones of the finger, later on to be moved when a hand movement data arrive
        /// </summary>
        private Transform[] mBones;

        #endregion

        #region Properties

        /// <summary>
        /// property for finger type
        /// </summary>
        public FingerType FingerType { get { return mFingerType; } }

        #endregion

        #region Ctors
        /// <summary>
        /// creates an instance of a Finger for given 'handController'
        /// </summary>
        /// <param name="handController">the transform of the hand that holds the finger</param>
        /// <param name="fingerType">the type of the finger</param>
        public Finger(Transform handController, FingerType fingerType)
        {
            mFingerType = fingerType;
            // fill bones
            int numOfBoneSections = Enum.GetValues(typeof(BoneSection)).Length;
            mBones = new Transform[numOfBoneSections];

            // search for relevant finger under the hand, and init bones if it
            var fingerTransform = CommonUtilities.GetFingerObject(handController, mFingerType);
            // get prox bone
            mBones[(int)BoneSection.Near] = fingerTransform.GetChild(0);
            // get dist bone
            mBones[(int)BoneSection.Far] = fingerTransform.GetChild(0).GetChild(0).GetChild(0);

            // remember initial state
            SetInitialRotation(numOfBoneSections);
        }
        #endregion

        #region Functions
        /// <summary>
        /// the fucntion rotates the bone states to it's initial state
        /// </summary>
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

        /// <summary>
        /// The function rotates the finger by rotating it's bones according to HandCoordinates structure
        /// </summary>
        /// <param name="coordinates"></param>
        public void Rotate(HandCoordinatesData coordinates)
        {
            // set initial state before rotating
            ResetRotation();
            for (int i = 0; i < mBones.Length; i++)
            {
                // calculate angle according to 5DT glove documentation
                float angle = -90 * coordinates[mFingerType][i];
                mBones[i].Rotate(Vector3.right, angle);
            }
        }

        /// <summary>
        /// the function set's initial state of bones
        /// </summary>
        /// <param name="numOfBoneSections">the amount of bones in the finger</param>
        private void SetInitialRotation(int numOfBoneSections)
        {
            mInitialRotate = new Quaternion[numOfBoneSections];
            mInitialRotate[(int)BoneSection.Near] = mBones[(int)BoneSection.Near].rotation;
            mInitialRotate[(int)BoneSection.Far] = mBones[(int)BoneSection.Far].rotation;
        } 
        #endregion
    }
}
