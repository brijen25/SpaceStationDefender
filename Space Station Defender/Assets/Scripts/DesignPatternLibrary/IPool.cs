namespace Brijen.ObjectPooling
{
    internal interface IPool<T>
    {
        public T GetPoolObject();
        public void ReturnPoolObject(T poolObject);
    }
}