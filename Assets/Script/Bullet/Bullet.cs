using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D rb;
    Vector3 lastVelocity;
    Vector3 bulletDir;
    BulletManager bulletManager;
    public Vector3 pos;
    public GameObject obj;
    public Transform bulletActiveTransform;
    public AudioSource sound;


    private void Start()
    {
        pos = obj.transform.position;
        GameManager.instance.ReStart += () =>
        {
            gameObject.SetActive(false);
            gameObject.transform.position = pos;
            bulletActiveTransform = null;
        };
    }
    private void OnEnable()
    {
        //총알이 활성화 될때의 마우스 위치의 방향으로 날아가게 함
        bulletDir = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, -Camera.main.transform.position.z)) - transform.position; //총알의 방향
        if (bulletActiveTransform != null)
        {
            AudioSource bulletSound = GetComponent<AudioSource>();
            bulletSound.Play();
        }
        bulletManager = FindObjectOfType<BulletManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(bulletDir.x + 0.2f, bulletDir.y-0.2f, bulletDir.z).normalized * bulletSpeed;// 총알의 속도
    }

    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    private void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        else
        {
            return;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        sound.GetComponent<AudioSource>().Play();
        bulletManager.collisionCount--;
        if (bulletManager.collisionCount < 0)
        {
            GameManager.instance.ReStart(); // 실패시 다시 시작
        }
        //반사각을 위해 Contacts2D.Normal(법선 벡터)을 이용
        Vector3 reflect = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = reflect * bulletSpeed;        
    }
}
