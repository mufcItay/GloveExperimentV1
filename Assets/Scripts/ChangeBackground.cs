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
            if (ConfigurationManager.Instance.Configuration.VRHandConfiguration.HandGender == GenderType.Male)
                RenderSettings.skybox = material[1];
            else
                RenderSettings.skybox = material[0];
          
        }
    }
}