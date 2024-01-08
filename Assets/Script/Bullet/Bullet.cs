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
        //총알이 활성화 될때의 마우스 위치의 방향으로 날아가게 함
        bulletDir = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, -Camera.main.transform.position.z)) - transform.position; //총알의 방향
        rb.velocity = 
            new Vector3(bulletDir.x + 0.2f, bulletDir.y-0.2f, bulletDir.z).normalized * bulletSpeed;// 총알의 속도
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
        plManager.LifeCount--; //라이프 감소
        if(plManager.LifeCount == 0)
        {
            Defeat(); //라이프 0일시 패배
        }

        if(countBox != null)
            countBox.count = countBox.originCount; //부서지는 박스 리셋
        if(setBox != null) //여러개의 부서지는 박스 리셋
            for(int i = 0; i<setBox.Length; i++)
            {
                setBox[i].SetActive(true);
                setBox[i].GetComponent<CountBox>().count = setBox[i].GetComponent<CountBox>().originCount;
            }
        // 충돌횟수 증가/감소 아이템 리셋
        if(plusItem != null)
            plusItem.SetActive(true);
        if(minusItem != null)
            minusItem.SetActive(true);
        //총알 원상태 및 충돌 횟수 리셋
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
            ReStart(); // 실패시 다시 시작
        }
        //반사각을 위해 Contacts2D.Normal(법선 벡터)을 이용
        Vector3 reflect = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = reflect * bulletSpeed;        
    }
}
