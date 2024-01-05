using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    public Potal exitPotal;
    public bool isInable = true;

    private void Start()
    {
        StartCoroutine(CoolTimeCo());
    }

    IEnumerator CoolTimeCo()
    {
        while(true)
        {
            if(isInable == false)
            {
                yield return new WaitForSeconds(1);
                isInable = true;
            }
            yield return null;
        }
    }

    public void InPotal(PotalTarget target)
    {
        isInable = false;
        target.transform.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PotalTarget>() != null)
        {
            if(isInable)
            {
                exitPotal.InPotal(other.GetComponent<PotalTarget>());
                isInable = false;
            }
        }
    }
}
