using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public Image[] Life = new Image[3];
    PlayerManager playerManager;

    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Life[playerManager.LifeCount - 1].enabled = false;
            }
        }
    }
}
