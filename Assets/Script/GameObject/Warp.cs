using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public Warp warp; //다른 워프 지점
    public float speed = 0.5f;
    public bool isUse = true;

    public void WarpPortal(Bullet bullet) //총알의 위치를 워프 지점으로 변경
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
                warp.WarpPortal(other.GetComponent<Bullet>()); //워프
                isUse = false;
            }
        }
    }
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


}
