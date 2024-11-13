using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPool<T> where T : MonoBehaviour
{
    private readonly T prefab;
    private readonly Queue<T> pool;
    private readonly Transform parent;

    public SimpleObjectPool(T prefab, int initialSize, Transform parent = null)
    {
        this.prefab = prefab;
        this.pool = new Queue<T>();
        this.parent = parent;

        for (int i = 0; i < initialSize; i++)
        {
            T newObj = Object.Instantiate(prefab, parent);
            newObj.gameObject.SetActive(false);
            pool.Enqueue(newObj);
        }
    }

    public T Get()
    {
        if (pool.Count > 0)
        {
            T obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            T newObj = Object.Instantiate(prefab, parent);
            return newObj;
        }
    }

    public void Release(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}
