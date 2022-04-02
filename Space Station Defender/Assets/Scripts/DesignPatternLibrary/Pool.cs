using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Brijen.ObjectPooling
{
    public class Pool<T> : IPool<T> where T : MonoBehaviour, IPoolObject
    {
        private Stack<T> m_ObjectPool = new Stack<T>();
        private Func<T> m_GetFunc = default;
        private Transform m_PoolParent = default;

        public void Init(Func<T> poolGetFunc, Transform poolParent, int initializeObjectCount = 20)
        {
            m_GetFunc = poolGetFunc;
            m_PoolParent = poolParent;
            for (int i = 0; i < initializeObjectCount; i++)
                CreatePoolObject();
        }
        #region IPoolInterface
        public T GetPoolObject()
        {
            if (m_ObjectPool.Count == 0)
                CreatePoolObject();

            T l_PoolObject = m_ObjectPool.Pop();
            l_PoolObject.gameObject.SetActive(true);
            return l_PoolObject;
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
            T l_object = m_GetFunc.Invoke();
            l_object.gameObject.SetActive(false);
            m_ObjectPool.Push(l_object);
        }
    }
}