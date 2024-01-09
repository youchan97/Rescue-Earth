using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPause;
    public GameObject menu;
    ButtonManager btnManager;
    public Action ReStart;

    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        isPause = false;
        btnManager = FindObjectOfType<ButtonManager>();
        Screen.SetResolution(1920, 1080, true);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                if(btnManager.isRule)
                {
                    btnManager.ruleScene.SetActive(false);
                    btnManager.isRule = false;
                }
                else
                {
                    menu.SetActive(false);
                    Time.timeScale = 1.0f;
                    isPause = false;
                }               
            }
            else
            {
                menu.SetActive(true);
                Time.timeScale = 0;
                isPause = true;
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReStart();
        }
    }
}
