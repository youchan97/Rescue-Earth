using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int lifeCount;

    public int LifeCount
    {
        get
        {
            return lifeCount;
        }
        set
        {
            lifeCount = value;
        }
    }
}
