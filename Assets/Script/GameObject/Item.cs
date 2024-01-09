using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected BulletManager bulletManager;
    [SerializeField]
    protected int point;
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
        GameManager.instance.ReStart += () =>
        {
            if (this.gameObject.GetComponent<CircleCollider2D>().enabled == false)
            {
                this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        };
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            bulletManager.CollisionCount += point;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
