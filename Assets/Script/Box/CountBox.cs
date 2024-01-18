using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBox : MonoBehaviour
{
    public int count;
    public int originCount;
    BoxCollider2D boxCol;
    SpriteRenderer boxSpriteRenderer;

    private void Awake()
    {
        boxCol = GetComponent<BoxCollider2D>();
        boxSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        originCount = count;
        GameManager.instance.ReStart += () =>
        {
            if (boxCol.enabled == false)
            {
                boxCol.enabled = true;
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
                boxCol.enabled = false;
                boxSpriteRenderer.enabled = false;
            }
        }
    }
}
