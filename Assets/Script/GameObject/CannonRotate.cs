using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotate : MonoBehaviour
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
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(target.y - mouse.y, target.x - mouse.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
