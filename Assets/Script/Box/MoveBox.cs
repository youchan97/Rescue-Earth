using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    Vector3 originPosition;
    public Vector3 axis;
    public float speed;
    public float maxDistance;
    float distance;
    void Start()
    {
        originPosition = transform.position;
    }
    void Update()
    {
        transform.Translate(axis * speed * Time.deltaTime, Space.World);
        if(axis == Vector3.up)
        {
            distance = (transform.position - originPosition).y;
        }
        else
        {
            distance = (transform.position - originPosition).x;;
        }
        if (distance >= maxDistance)
            speed *= -1;
        else if (distance <= -maxDistance)
            speed *= -1;
    }
}
