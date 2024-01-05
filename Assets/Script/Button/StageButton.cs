using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    public static int currentStageNum = 1;
    public GameObject[] stage = new GameObject[10];

    public void StageOne()
    {
        currentStageNum = 1;
        LoadScene(currentStageNum);
    }
    public void StageTwo()
    {
        currentStageNum = 2;
        LoadScene(currentStageNum);
    }
    public void StageThree()
    {
        currentStageNum = 3;
        LoadScene(currentStageNum);
    }
    public void StageFour()
    {
        currentStageNum = 4;
        LoadScene(currentStageNum);
    }
    public void StageFive()
    {
        currentStageNum = 5;
        LoadScene(currentStageNum);
    }
    public void StageSix()
    {
        currentStageNum = 6;
        LoadScene(currentStageNum);
    }
    public void StageSeven()
    {
        currentStageNum = 7;
        LoadScene(currentStageNum);
    }
    public void StageEight()
    {
        currentStageNum = 8;
        LoadScene(currentStageNum);
    }
    public void StageNine()
    {
        currentStageNum = 9;
        LoadScene(currentStageNum);
    }
    public void StageTen()
    {
        currentStageNum = 10;
        LoadScene(currentStageNum);
    }

    public void LoadScene(int stageNum)
    {
        SceneManager.LoadScene("Stage" + stageNum);
    }

    public void Sound()
    {
        GetComponent<AudioSource>().Play();
        Debug.Log("µþ±ï½ºÅ×ÀÌÁö");
    }

    private void Update()
    {
        for(int i = 0; i < stage.Length; i++)
        {
            if (i < currentStageNum)
            {
                stage[i].SetActive(true);
            }
            else
            {
                stage[i].SetActive(false);
            }
        }
    }
}
