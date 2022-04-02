using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Brijen.ObjectPooling;

public class Bullet : MonoBehaviour, IPoolObject
{
    Pool<Bullet> m_MyPool = default;

    public void Init(Pool<Bullet> backToPool)
    {
        m_MyPool = backToPool;
        this.transform.SetPositionAndRotation(new Vector3(5, 5, 5), Quaternion.identity);
    }

}
