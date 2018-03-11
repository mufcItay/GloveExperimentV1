using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SceneManager : MonoBehaviour {
    
    static SceneManager sInstance;

    private void Start()
    {
        if (sInstance != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            sInstance = this;
        }

    }

    public static SceneManager Instance
    {
        get
        {
            return sInstance;
        }
    }
}

