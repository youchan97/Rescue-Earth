using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBox : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    float changeNumber = -0.005f;
    Color colorAlpha;
    public float coolTime;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorAlpha = spriteRenderer.color;
        StartCoroutine(AppearCo());
    }

    public void Disappear()
    {
        colorAlpha.a += changeNumber;
        spriteRenderer.color = colorAlpha;
    }

    IEnumerator AppearCo()
    {
        while(true)
        {
            Disappear();
            if (colorAlpha.a < 0.003f)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                yield return new WaitForSeconds(coolTime * Time.deltaTime);
                changeNumber *= -1;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            else if(colorAlpha.a > 0.99f)
            { 
                yield return new WaitForSeconds(coolTime * Time.deltaTime);
                changeNumber *= -1;              
            }
            yield return null;
        }
    }
}
