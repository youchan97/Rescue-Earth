using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearMethodTwo : ClearMethod
{
    private void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    public override void Clear(Collider2D other)
    {
        if (other.GetComponent<Bullet>() != null)
        {
            if (bulletManager.collisionCount >= 0)
            {
                SceneManager.LoadScene("Clear");
                StageButton.currentStageNum++;
            }
            else
            {
                GameManager.instance.ReStart();
            }
        }
    }
}
