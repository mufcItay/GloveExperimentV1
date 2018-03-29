using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace JasHandExperiment
{
    public class switchScene : MonoBehaviour
    {
        private uint interBlockTimeout, blockDuration, blocksAmount;


        private bool flag;
        public Text text;

        private float timer, StartTime;
        private static bool endofExperiment = false;
        // Use this for initialization
        void Start()
        {
            StartTime = Time.time;
            flag = false;
            interBlockTimeout = ConfigurationManager.Instance.Configuration.SubRuns[0].InterBlockTimeout;
            blocksAmount = ConfigurationManager.Instance.Configuration.SubRuns[0].BlocksAmount;
            text.text = "Rest for " + (interBlockTimeout).ToString() + " sec ";
        }

        // Update is called once per frame
        void Update()
        {
            if (endofExperiment == false)
            {
                if (ExperimentRuntime.Instance.TrialNumber == blocksAmount)
                {
                    text.text = "End of experiment ";
                    endofExperiment = true;
                }


                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("restScene")
                    && endofExperiment == false)
                    StartCoroutine(updateText());


                if (flag == true && endofExperiment == false)
                {
                    flag = false;
                    ExperimentRuntime.Instance.TrialNumber++;
                    SceneManager.LoadScene("testRoom");
                }

            }

        }
        IEnumerator updateText()
        {
            yield return new WaitForSeconds(interBlockTimeout);
            flag = true;
        }
    }
}