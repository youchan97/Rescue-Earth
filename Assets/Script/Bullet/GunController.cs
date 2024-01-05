using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bullet;
    private PlayerManager plManager;
    Cannon cannon;

    private void Start()
    {
        plManager = FindObjectOfType<PlayerManager>();
        bullet.SetActive(false);
        cannon = FindObjectOfType<Cannon>();
    }
    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(bullet.GetComponent<Bullet>().bulletActiveTransform != null)
                {
                    Debug.Log("∆„");
                    bullet.transform.position = bullet.GetComponent<Bullet>().bulletActiveTransform.position;
                    cannon.ChildsHit(false);
                    cannon.GetComponent<AudioSource>().Play();
                    bullet.SetActive(true);
                    cannon.isUse = false;
                    bullet.GetComponent<Bullet>().bulletActiveTransform = null;
                }
                else
                {
                    Debug.Log("≈¡");
                    bullet.transform.position = bullet.GetComponent<Bullet>().obj.transform.position;
                    bullet.SetActive(true);
                    return;
                }
            }
        }
    }
}
