using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotate : MonoBehaviour // 캐논 기믹의 회전 기능
{
    float angle;
    Vector2 target, mouse;
    public bool isHit;

    private void Start()
    {
        target = transform.position;
        isHit = false;
    }
    private void Update()
    {
        if (!isHit) return;
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스 위치 좌표
        // 아크탄젠트를 통해 회전 각도 조정
        angle = Mathf.Atan2(target.y - mouse.y, target.x - mouse.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
