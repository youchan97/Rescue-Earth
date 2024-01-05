using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayer : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector3 lastVelocity;
    float rotateSpeed = 0.3f;
    float speed = 5;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.up * speed;
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed);
        lastVelocity = rigid.velocity;
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        var speed = lastVelocity.magnitude;
        var dir = Vector2.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

        rigid.velocity = dir * Mathf.Max(speed, 0f);
    }
}
