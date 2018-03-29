using System.Collections;
using System.Collections.Generic;
using CommonTools;
using FDTGloveUltraCSharpWrapper;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

namespace JasHandExperiment
{

    public class textManager : MonoBehaviour
    {
        public Text text;
        CSVFile mReadFile;
        private int i = 0;
        private int counter = 0;
        private string st = "";
        private string str;
        private bool flag;

        private float timer;

        // Use this for initialization
        void Start()
        {
            timer = ConfigurationManager.Instance.Configuration.SubRuns[0].BlockDuration;
            str = ConfigurationManager.Instance.Configuration.Squence + '\n';

        }


        // Update is called once per frame
        void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {

                SceneManager.LoadScene("restScene");

            }
            if (needToUpdateText())
            {
                str += "* ";
                i++;
            }
            if (i % 5 == 0)
                StartCoroutine(clearScreen());
            text.text = str;

        }
        IEnumerator clearScreen()
        {
            yield return new WaitForSeconds(0.3f);
            str = ConfigurationManager.Instance.Configuration.Squence + '\n';

        }
        bool needToUpdateText()
        {

            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) ||
                Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4)) 
                return true;
            return false;
        }
    }
}