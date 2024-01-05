using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusItem : MonoBehaviour
{
    BulletManager bulletManager;

    private void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }
    public void Plus()
    {
        bulletManager.CollisionCount++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Bullet>() != null)
        {
            gameObject.SetActive(false);
            Plus();
        }
    }
}
