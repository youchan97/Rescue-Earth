using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClearMethod : MonoBehaviour
{
    protected BulletManager bulletManager;

    public abstract void Clear(Collider2D other);
}
