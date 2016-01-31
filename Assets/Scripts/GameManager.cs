﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    private GameObject LightObject;

    private bool slowTime = false;

    private bool transition = false;

    public static GameManager GetInstance()
    {
        return Instance;
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject); return;
        }
        else {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        slowTime = false;
        transition = false; 
        LightObject = GameObject.Find("Light");
    }

    /**
    void FixedUpdate()
    {
        if(slowTime && transition)
        {
            if (Time.timeScale < 0.1f)
            {
                Time.timeScale = 0.1f;
                LightObject.GetComponent<Light>().intensity = .1f;
                transition = false;
            }
            else {
                Time.timeScale -= 0.01f;
                LightObject.GetComponent<Light>().intensity = -0.01f;
            }
        }
    }
    **/
    public void PlayerDeath()
    {
        if (!slowTime)
        {
            slowTime = true;
            Time.timeScale = 0.1f;
            LightObject.GetComponent<Light>().intensity = .1f;
        }
    }

    public void PlayerItsAlive()
    {
        if (slowTime)
        {
            slowTime = false;
            Time.timeScale = 1f;
            LightObject.GetComponent<Light>().intensity = 1;
        }
    }

}
