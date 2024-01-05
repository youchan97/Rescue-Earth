using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Planet : MonoBehaviour
{
    BulletManager blManager;
    Bullet bullet;
    PlayerManager plManager;

    private void Start()
    {
        blManager = FindObjectOfType<BulletManager>();
        bullet = FindObjectOfType<Bullet>();
        plManager = FindObjectOfType<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.GetComponent<ClearMethod>().Clear(other);
    }
}

