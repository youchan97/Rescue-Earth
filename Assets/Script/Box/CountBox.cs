using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBox : MonoBehaviour
{
    public int count;
    public int originCount;

    private void Start()
    {
        originCount = count;
        GameManager.instance.ReStart += () =>
        {
            if (this.gameObject.GetComponent<BoxCollider2D>().enabled == false)
            {
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
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
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
