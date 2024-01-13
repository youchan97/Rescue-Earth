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
        //�Ѿ��� Ȱ��ȭ �ɶ��� ���콺 ��ġ�� �������� ���ư��� ��
        bulletDir = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, -Camera.main.transform.position.z)) - transform.position; //�Ѿ��� ����
        if (bulletActiveTransform != null)
        {
            AudioSource bulletSound = GetComponent<AudioSource>();
            bulletSound.Play();
        }
        bulletManager = FindObjectOfType<BulletManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(bulletDir.x + 0.2f, bulletDir.y-0.2f, bulletDir.z).normalized * bulletSpeed;// �Ѿ��� �ӵ�
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
            GameManager.instance.ReStart(); // ���н� �ٽ� ����
        }
        //�ݻ簢�� ���� Contacts2D.Normal(���� ����)�� �̿�
        Vector3 reflect = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = reflect * bulletSpeed;        
    }
}
