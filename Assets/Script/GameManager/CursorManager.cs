using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Vector3 cursorPosition;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        cursorPosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z));
        transform.position = new Vector3(cursorPosition.x + 0.3f, cursorPosition.y - 0.3f, cursorPosition.z);
    }
}
