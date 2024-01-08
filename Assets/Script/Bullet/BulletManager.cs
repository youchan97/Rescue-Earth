using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public int collisionCount; //ÃÑ¾ËÀÇ Ãæµ¹ °¡´É È½¼ö

    public int CollisionCount
    {
        get { return collisionCount; }
        set
        {
            collisionCount = value;
            if( collisionCount <= 0 )
            {
                collisionCount = 0;
            }
        }
    }

}
