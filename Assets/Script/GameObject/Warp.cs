using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public Warp warp; //�ٸ� ���� ����
    public float speed = 0.5f;
    public bool isUse = true;

    public void WarpPortal(Bullet bullet) //�Ѿ��� ��ġ�� ���� �������� ����
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
                warp.WarpPortal(other.GetComponent<Bullet>()); //����
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
