using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Brijen.ObjectPooling;

public class PoolObjectTest : MonoBehaviour
{
    [SerializeField] Transform m_parent = default;
    [SerializeField] PoolObject m_ObjectPrefab = default;

    private Pool<PoolObject> m_LocalPool = new Pool<PoolObject>();

    private void Awake()
    {
        m_LocalPool.Init(m_ObjectPrefab, m_parent);
        StartCoroutine(Particle());
    }
    IEnumerator Particle()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            PoolObject l_object = m_LocalPool.GetPoolObject();
            yield return new WaitForSeconds(1.5f);
            m_LocalPool.ReturnPoolObject(l_object);
        }
    }
}
