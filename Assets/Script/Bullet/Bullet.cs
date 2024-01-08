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
    public GameObject[] setBox;
    public GameObject plusItem;
    public GameObject minusItem;
    public int colCount;
    PlayerManager plManager;
    public CountBox countBox;
    public Transform bulletActiveTransform;
    public AudioSource sound;


    private void Start()
    {
        plManager = FindObjectOfType<PlayerManager>();
        colCount = bulletManager.collisionCount;
        pos = obj.transform.position;
        countBox = FindObjectOfType<CountBox>();
    }
    private void OnEnable()
    {
        //�Ѿ��� Ȱ��ȭ �ɶ��� ���콺 ��ġ�� �������� ���ư��� ��
        bulletDir = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, -Camera.main.transform.position.z)) - transform.position; //�Ѿ��� ����
        rb.velocity = 
            new Vector3(bulletDir.x + 0.2f, bulletDir.y-0.2f, bulletDir.z).normalized * bulletSpeed;// �Ѿ��� �ӵ�
        if (bulletActiveTransform != null)
        {
            AudioSource bulletSound = GetComponent<AudioSource>();
            bulletSound.Play();
        }
        bulletManager = FindObjectOfType<BulletManager>();
        rb = GetComponent<Rigidbody2D>();
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ReStart();
            }
            return;
        }
    }

    public void Defeat()
    {
        SceneManager.LoadScene("Defeat");
    }

    public void ReStart()
    {
        plManager.LifeCount--; //������ ����
        if(plManager.LifeCount == 0)
        {
            Defeat(); //������ 0�Ͻ� �й�
        }

        if(countBox != null)
            countBox.count = countBox.originCount; //�μ����� �ڽ� ����
        if(setBox != null) //�������� �μ����� �ڽ� ����
            for(int i = 0; i<setBox.Length; i++)
            {
                setBox[i].SetActive(true);
                setBox[i].GetComponent<CountBox>().count = setBox[i].GetComponent<CountBox>().originCount;
            }
        // �浹Ƚ�� ����/���� ������ ����
        if(plusItem != null)
            plusItem.SetActive(true);
        if(minusItem != null)
            minusItem.SetActive(true);
        //�Ѿ� ������ �� �浹 Ƚ�� ����
        gameObject.SetActive(false);        
        gameObject.transform.position = pos;
        bulletManager.collisionCount = colCount;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        sound.GetComponent<AudioSource>().Play();
        bulletManager.collisionCount--;
        if (bulletManager.collisionCount < 0)
        {
            ReStart(); // ���н� �ٽ� ����
        }
        //�ݻ簢�� ���� Contacts2D.Normal(���� ����)�� �̿�
        Vector3 reflect = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = reflect * bulletSpeed;        
    }
}
