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
            LifeCount--; //������ ����
            if (LifeCount == 0)
            {
                SceneManager.LoadScene("Defeat"); //������ 0�Ͻ� �й�
            }
        };
    }
}
