using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float MaxDistance;
    Vector3 mouseVec;
    CursorManager cursor;

    private void Start()
    {
        cursor = FindObjectOfType<CursorManager>();
    }

    private void Update()
    {
        mouseVec = cursor.cursorPosition;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseVec, MaxDistance);
        Debug.DrawLine(transform.position, mouseVec, Color.red);
    }
}
