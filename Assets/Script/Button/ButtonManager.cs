using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject ruleScene;
    public bool isRule = false;
    public void NextStage()
    {
        SceneManager.LoadScene("Stage"+ StageButton.currentStageNum);
    }

    public void StageMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StageMenu");
    }

    public void Rule()
    {
        SceneManager.LoadScene("Explain");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Stage"+StageButton.currentStageNum);
    }

    public void VictoryRetry()
    {
        StageButton.currentStageNum--;
        SceneManager.LoadScene("Stage" + StageButton.currentStageNum);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        StageButton.currentStageNum = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void GameRule()
    {
        ruleScene.SetActive(true);
        isRule = true;
    }

    public void Sound()
    {
        GetComponent<AudioSource>().Play();
        Debug.Log("µþ±ï");
    }
}
