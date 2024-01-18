using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBox : MonoBehaviour
{
    public int count;
    public int originCount;
    BoxCollider2D boxCollider;
    SpriteRenderer boxSpriteRenderer;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        originCount = count;
        GameManager.instance.ReStart += () =>
        {
            if (boxCollider.enabled == false)
            {
                boxCollider.enabled = true;
                boxSpriteRenderer.enabled = true;
                count = originCount;
            }
        };
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Bullet>() != null)
        {
            count--;
            if(count == 0)
            {
                boxCollider.enabled = false;
                boxSpriteRenderer.enabled = false;
            }
        }
    }
}
