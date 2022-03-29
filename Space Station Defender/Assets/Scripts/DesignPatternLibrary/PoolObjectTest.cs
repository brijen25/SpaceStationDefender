using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Brijen.ObjectPooling;

public class PoolObjectTest : MonoBehaviour
{
    [SerializeField] Transform m_parent = default;
    [SerializeField] PoolObject m_PoolObject = default;

    private Pool<PoolObject> m_LocalPool = new Pool<PoolObject>();

    private void Awake()
    {
        m_LocalPool.Init(m_PoolObject, m_parent);
        StartCoroutine(Particle());
    }
    IEnumerator Particle()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            var l_object = m_LocalPool.GetPoolObject();
            l_object.transform.position = Vector3.zero;
        }
    }
}
