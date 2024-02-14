using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected BulletManager bulletManager;
    [SerializeField]
    protected int point;
    CircleCollider2D itemCol;
    SpriteRenderer itemSpriteRenderer;
    void Start()
    {
        itemCol = this.gameObject.GetComponent<CircleCollider2D>();
        itemSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        bulletManager = FindObjectOfType<BulletManager>();
        GameManager.instance.ReStart += () =>
        {
            if (itemCol == false)
            {
                itemCol.enabled = true;
                itemSpriteRenderer.enabled = true;
            }
        };
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            bulletManager.CollisionCount += point;
            itemCol.enabled = false;
            itemSpriteRenderer.enabled = false;
        }
    }
}
