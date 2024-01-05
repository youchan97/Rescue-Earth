using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearMethodOne : ClearMethod
{
    private void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();    
    }

    public override void Clear(Collider2D other)
    {
        if (other.GetComponent<Bullet>() != null)
        {
            if (bulletManager.collisionCount == 0)
            {
                if(StageButton.currentStageNum == 10)
                {
                    SceneManager.LoadScene("FinalVictory");
                }
                else
                {
                    SceneManager.LoadScene("Clear");
                    StageButton.currentStageNum++;
                }
            }
            else
            {
                other.GetComponent<Bullet>().ReStart();
            }
        }
    }
}
