using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Count : MonoBehaviour
{
    public TextMeshProUGUI temp;
    public int bulletNumber;
    private BulletManager bullet;

    private void Start()
    {
        temp = GetComponent<TextMeshProUGUI>();
        bullet = FindObjectOfType<BulletManager>();
    }

    private void Update()
    {
        bulletNumber = bullet.collisionCount;
        temp.text = bulletNumber.ToString();
    }

}
