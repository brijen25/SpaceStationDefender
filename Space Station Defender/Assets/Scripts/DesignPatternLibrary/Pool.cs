using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Brijen.ObjectPooling
{
    public class Pool<T> : MonoBehaviour, IPool<T> where T : MonoBehaviour, IPoolObject
    {
        private Stack<T> m_ObjectPool = new Stack<T>();
        private T m_PoolObject = default;
        private Transform m_PoolParent = default;

        public void Init(T poolObject, Transform poolParent, int initializeObjectCount = 20)
        {
            m_PoolObject = poolObject;
            m_PoolParent = poolParent;
            for (int i = 0; i < initializeObjectCount; i++)
                CreatePoolObject();
        }
        #region IPoolInterface
        public T GetPoolObject()
        {
            if (m_ObjectPool.Count == 0)
                CreatePoolObject();
            var l_poolObject = m_ObjectPool.Pop();
            l_poolObject.gameObject.SetActive(true);
            return l_poolObject;
        }
        public void ReturnPoolObject(T poolObject)
        {
            poolObject.transform.SetParent(m_PoolParent);
            poolObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            poolObject.gameObject.SetActive(false);
            m_ObjectPool.Push(poolObject);
        }
        #endregion

        private void CreatePoolObject()
        {
            var l_object = Instantiate(m_PoolObject, m_PoolParent);
            l_object.gameObject.SetActive(false);
            m_ObjectPool.Push(l_object);
        }
    }
}