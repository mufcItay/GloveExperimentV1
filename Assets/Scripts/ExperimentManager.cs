using JasHandExperiment.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JasHandExperiment
{
    
    public class ExperimentManager : MonoBehaviour {

        
        #region Data Members

        private static ExperimentManager sInstance;

        /// <summary>
        /// The experiment runtime singletone instance
        /// </summary>
        ExperimentRuntime mExperimentRuntime;

        /// <summary>
        /// prefab for female hands
        /// </summary>
        public GameObject FemaleHandPrefab;

        /// <summary>
        /// prefab for female hands
        /// </summary>
        public GameObject MaleHandPrefab;

        /// <summary>
        /// prefab for female hands
        /// </summary>
        public GameObject RightKeyboardPrefab;

        /// <summary>
        /// prefab for female hands
        /// </summary>
        public GameObject LeftKeyboardPrefab;

        private BaseConditionedDynamicObjectCreator<GenderType> mDynamicHandCreator;

        private BaseConditionedDynamicObjectCreator<HandType> mDynamicKeyboardCreator;
        
        /// <summary>
        /// indicates if we are in calibration mode or real time running
        /// </summary>
        public HandPlayMode Mode;

        #endregion


        void Awake()
        {
            if (sInstance != null && sInstance != this)
            {
                Destroy(gameObject);
            }
            else if (sInstance != null)
            {
                sInstance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        // Use this for initialization
        void Start() {
            sInstance = this;
            mExperimentRuntime = ExperimentRuntime.Instance;
            CalibrationManager.Mode = Mode;

            // create and init hand creator
            mDynamicHandCreator = new BaseConditionedDynamicObjectCreator<GenderType>(MaleHandPrefab, FemaleHandPrefab);
            GenderType gender = ConfigurationManager.Instance.Configuration.ParticipantConfiguration.Gender;
            Instantiate(mDynamicHandCreator.GetObjectToCreate(x => x.Equals(GenderType.Male), gender));

            // create and init keyboard creator
            mDynamicKeyboardCreator = new BaseConditionedDynamicObjectCreator<HandType>(LeftKeyboardPrefab, RightKeyboardPrefab);
            HandType side = ConfigurationManager.Instance.Configuration.VRHandConfiguration.HandToAnimate;
            Instantiate(mDynamicKeyboardCreator.GetObjectToCreate(x => x.Equals(HandType.Left), side));
        }
    }
}