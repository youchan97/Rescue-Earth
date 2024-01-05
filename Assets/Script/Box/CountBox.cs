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
    }

/*    public int Count
    {
        get { return count; }
        set
        {
            count = value;
            if(count == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Bullet>() != null)
        {
            count--;
            if(count == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
