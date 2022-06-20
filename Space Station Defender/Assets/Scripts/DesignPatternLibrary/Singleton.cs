using UnityEngine;

namespace Brijen.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        public static T INSTANCE;

        protected virtual void Awake()
        {
            if (INSTANCE != null)
            {
                Destroy(gameObject);
            }
            else
            {
                INSTANCE = GetT();
            }
            Debug.Log("Awake");
        }

        private T GetT()
        {
            if (INSTANCE == null)
            {
                INSTANCE = FindObjectOfType<T>();
                if (INSTANCE == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    INSTANCE = obj.AddComponent<T>();
                }
            }
            return INSTANCE;
        }
    }
}
