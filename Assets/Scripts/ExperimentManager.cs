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

        private BaseConditionedDynamicObjectCreator<GenderType> mDynamicHandCreator;

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
            
            // create and init hand creator
            mDynamicHandCreator = new BaseConditionedDynamicObjectCreator<GenderType>(MaleHandPrefab, FemaleHandPrefab);
            GenderType gender = ConfigurationManager.Instance.Configuration.ParticipantConfiguration.Gender;
            Instantiate(mDynamicHandCreator.GetObjectToCreate(x => x.Equals(GenderType.Male), gender));
        }
    }
}