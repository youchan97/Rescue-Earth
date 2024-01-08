using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    Bullet bullet;
    public GameObject bulletStart;
    public GameObject[] childs = new GameObject[3];
    public GameObject test;
    public bool isUse = true;
    public float coolTime;

    private void Start()
    {
        bullet = FindObjectOfType<Bullet>();
        SetChilds();
        StartCoroutine(CoolTimeCo());
    }

    IEnumerator CoolTimeCo() //총알이 쏴지자마자 닿는 오류를 막기 위함
    {
        while (true)
        {
            if (isUse == false)
            {
                yield return new WaitForSeconds(coolTime * Time.deltaTime);
                isUse = true;
            }
            yield return null;
        }
    }

    public void SetChilds() //회전해야하는 오브젝트만 가져옴
    {
        childs[0] = transform.GetChild(0).GetChild(0).gameObject;
        childs[1] = transform.GetChild(0).GetChild(3).gameObject;
        childs[2] = transform.GetChild(0).GetChild(4).gameObject;
    }

    public void ChildsHit(bool type) // 조건부 회전 기능
    {
        for(int i=0; i<childs.Length; i++)
            childs[i].GetComponent<CannonRotate>().isHit = type;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bullet>() != null)
        {
            if (isUse)
            {
                ChildsHit(true);
                other.gameObject.SetActive(false);
                // 총알이 활성화 되는 위치 저장
                other.GetComponent<Bullet>().bulletActiveTransform = bulletStart.transform;
            }
        }
    }
    private void Update()
    {
        if(isUse == false)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
