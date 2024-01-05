using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public Warp warp;
    public float speed = 0.5f;
    public bool isUse = true;

    private void Start()
    {
        StartCoroutine(CoolTimeCo());
    }

    IEnumerator CoolTimeCo()
    {
        while (true)
        {
            if (isUse == false)
            {
                yield return new WaitForSeconds(1);
                isUse = true;
            }
            yield return null;
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }

    public void WarpPortal(Bullet bullet)
    {
        isUse = false;
        bullet.transform.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Bullet>() != null)
        {
            if(isUse)
            {
                warp.WarpPortal(other.GetComponent<Bullet>());
                isUse = false;
            }
        }
    }

}
