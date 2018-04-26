using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace JasHandExperiment
{
    public class moveToCalibration : MonoBehaviour
    {
        //change scene from empty room to calibration room  
        public Text text;
        // Use this for initialization
        void Start()
        {   
            //the text on the display once it runs . 
            if(ConfigurationManager.Instance.Configuration.ExperimentType == Configuration.ExperimentType.Active)
                 text.text = "Click Space To Move To Calibration Room";
            else
                text.text = "Click Space To Move To Test Room";
        }

        // Update is called once per frame
        void Update()
        {
            //the key to change scenes 
            if (ConfigurationManager.Instance.Configuration.ExperimentType == Configuration.ExperimentType.Active)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("calibScene");
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("testroom");
                }
            }

        }
    }
}
