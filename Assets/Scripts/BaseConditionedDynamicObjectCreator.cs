using JasHandExperiment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseConditionedDynamicObjectCreator <T>
{
    #region Data Members
    /// <summary>
    /// prefab for female hands
    /// </summary>
    private GameObject mTrueGameObject;

    /// <summary>
    /// prefab for female hands
    /// </summary>
    private GameObject mFalseGameObject;

    #endregion

    #region Ctor
    public BaseConditionedDynamicObjectCreator(GameObject trueGO, GameObject falseGO)
    {

    }
    #endregion

    #region Functions

    public GameObject GetObjectToCreate(Predicate<T> pred, T obj)
    {
        if (pred(obj))
        {
            return mTrueGameObject;
        }
        else
        {
            return mFalseGameObject;
        }
    }

    #endregion
}
