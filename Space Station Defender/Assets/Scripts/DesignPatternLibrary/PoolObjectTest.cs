using System.Collections;
using UnityEngine;
using Brijen.ObjectPooling;

public class PoolObjectTest : MonoBehaviour
{
    [SerializeField] Transform m_parent = default;
    [SerializeField] Bullet m_ObjectPrefab = default;

    private Pool<Bullet> m_LocalPool = new Pool<Bullet>();

    private void Awake()
    {
        m_LocalPool.Init(GetBullet, m_parent);
        StartCoroutine(Particle());
    }
    IEnumerator Particle()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Bullet l_object = m_LocalPool.GetPoolObject();
            l_object.Init(m_LocalPool);
            yield return new WaitForSeconds(1.5f);
        }
    }

    private Bullet GetBullet()
    {
        return Instantiate(m_ObjectPrefab, m_parent);
    }
}
