using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int lifeCount;

    public int LifeCount
    {
        get
        {
            return lifeCount;
        }
        set
        {
            lifeCount = value;
        }
    }

    private void Start()
    {
        GameManager.instance.ReStart += () =>
        {
            LifeCount--; //라이프 감소
            if (LifeCount == 0)
            {
                SceneManager.LoadScene("Defeat"); //라이프 0일시 패배
            }
        };
    }
}
