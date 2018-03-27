using JasHandExperiment.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JasHandExperiment
{
    public class ExperimentManager : MonoBehaviour {

        #region Data Members
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

        // Use this for initialization
        void Start() {
            mExperimentRuntime = ExperimentRuntime.Instance;

            // create and init hand creator
            mDynamicHandCreator = new BaseConditionedDynamicObjectCreator<GenderType>(MaleHandPrefab, FemaleHandPrefab);
            GenderType gender = ConfigurationManager.Instance.Configuration.ParticipantConfiguration.Gender;
            Instantiate(mDynamicHandCreator.GetObjectToCreate(x => x.Equals(GenderType.Male), gender));
        }
    }
}