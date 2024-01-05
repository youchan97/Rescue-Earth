using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusItem : MonoBehaviour
{
    BulletManager bulletManager;

    private void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }
    public void Minus()
    {
        bulletManager.CollisionCount--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            gameObject.SetActive(false);
            Minus();
        }
    }
}
