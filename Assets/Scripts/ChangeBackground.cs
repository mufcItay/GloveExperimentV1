using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JasHandExperiment.Configuration;
namespace JasHandExperiment
{
    public class ChangeBackground : MonoBehaviour
    {
        //Change the background according to genderType

        public Material[] material;
        void Start()
        {
            if (ConfigurationManager.Instance.Configuration.VRHandConfiguration.HandGender == GenderType.Male) {
                if (ConfigurationManager.Instance.Configuration.VRHandConfiguration.HandToAnimate == HandType.Left)
                    RenderSettings.skybox = material[0];
                if (ConfigurationManager.Instance.Configuration.VRHandConfiguration.HandToAnimate == HandType.Right)
                    RenderSettings.skybox = material[1];

            }
            else if (ConfigurationManager.Instance.Configuration.VRHandConfiguration.HandGender == GenderType.Female)
            {
                if (ConfigurationManager.Instance.Configuration.VRHandConfiguration.HandToAnimate == HandType.Left)
                    RenderSettings.skybox = material[2];
                if (ConfigurationManager.Instance.Configuration.VRHandConfiguration.HandToAnimate == HandType.Right)
                    RenderSettings.skybox = material[3];

            }
        }
    }
}