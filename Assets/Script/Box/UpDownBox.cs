using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownBox : MonoBehaviour
{
    Vector3 originPosition;
    public Vector3 axis;
    public float speed;
    public float maxDistance;
    void Start()
    {
        originPosition = transform.position;
    }
    void Update()
    {

        transform.Translate(axis * speed * Time.deltaTime, Space.World);

        float distance = (transform.position - originPosition).y;

        if (distance >= maxDistance)
            speed *= -1;
        else if (distance <= -maxDistance)
            speed *= -1;
    }
}
