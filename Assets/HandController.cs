using System.Collections.Generic;
using CommonTools;
using UnityEngine;
using TestGame;
using System;

public class HandController : MonoBehaviour {
    public GameObject myPrefab;
    // for unity configuration to determine which hand side is this
    public HandType HandSide;
    //the gender of the hand
    public GenderType HandGender;
    // holds the strategy to handle hand movement for given experiment type
    private BaseExperimentStrategy mExperimentStrategy;

    private ExperimentType mExperimentType;
    
    // Use this for initialization
    void Start () {
        SetConfiguredHandAppearance();
        var fingers = new List<Finger>();
        HandType handToAnimate = ConfigurationManager.Instance.Configuration.VRHandConfiguration.HandToAnimate;
        if (!handToAnimate.Equals(HandSide))
        {
            return; // we sholudn't animate this hand, so return and save your energy
        }

        ////
        //GameObject go = Instantiate(myPrefab) as GameObject;

        ////

        mExperimentType = ConfigurationManager.Instance.Configuration.ExperimentType;
        mExperimentStrategy = ExperimentStrategyFactory.GetOrCreate(mExperimentType);
        mExperimentStrategy.Init(this);
    }
    
    // Update is called once per frame
    void Update () {
        mExperimentStrategy.MoveHand();
    }

    public void SetConfiguredHandAppearance()
    {
        var handModel = CommonUtilities.FindObjectWithName(transform, CommonUtilities.GetRendererParentObjectName(HandGender));
        Renderer rend = handModel.GetComponent<Renderer>();
        rend.material.color = ConfigurationManager.Instance.Configuration.VRHandConfiguration.HandColor;
    }

    private void OnDestroy()
    {
        mExperimentStrategy.Close();
    }

}