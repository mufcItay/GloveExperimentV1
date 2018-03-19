using JasHandExperiment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCreature : MonoBehaviour {

    #region Data Members
    /// <summary>
    /// prefab for female hands
    /// </summary>
    public GameObject FemaleHandPrefab;

    /// <summary>
    /// prefab for female hands
    /// </summary>
    public GameObject MaleHandPrefab;

    #endregion
    // Use this for initialization
    void Start () {

        if (ConfigurationManager.Instance.Configuration.ParticipantConfiguration.Gender == JasHandExperiment.Configuration.GenderType.Male)
        {
            Instantiate(MaleHandPrefab);
        }
        else
        {
            Instantiate(FemaleHandPrefab);
        }
    }

}
