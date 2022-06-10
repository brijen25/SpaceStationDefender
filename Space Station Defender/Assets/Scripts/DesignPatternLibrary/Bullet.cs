using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Brijen.ObjectPooling;

public class Bullet : MonoBehaviour, IPoolObject
{
    private Pool<Bullet> m_MyPool;

    public void Init(Pool<Bullet> l_LocalPool)
    {
        m_MyPool = l_LocalPool;
    }

    private void Distroy()
    {
        //Reset All physics
        m_MyPool.ReturnPoolObject(this);
    }
}
