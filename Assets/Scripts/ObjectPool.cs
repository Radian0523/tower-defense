using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private uint initPoolSize;
    [SerializeField] private PooledObject objectToPool;

    // stackに入ってるものは、SetActive(false)状態のもの。
    private Stack<PooledObject> stack;

    void Start()
    {
        SetUpPool();
    }

    void SetUpPool()
    {
        if (objectToPool == null) return;

        stack = new Stack<PooledObject>();

        PooledObject instance = null;

        for (int i = 0; i < initPoolSize; i++)
        {
            instance = Instantiate(objectToPool);
            instance.Pool = this;
            instance.gameObject.SetActive(false);
            stack.Push(instance);
        }
    }

    public PooledObject GetPooledObject()
    {
        if (objectToPool == null) return null;

        // stackが限界の場合、新しいものをInstantiateする。消されたときにstackに追加される。
        // つまり、限界を一回でも超えれば、その分stackの限界値は増える。
        if (stack.Count == 0)
        {
            PooledObject newInstance = Instantiate(objectToPool);
            newInstance.Pool = this;
            return newInstance;
        }

        PooledObject nextInstance = stack.Pop();
        nextInstance.gameObject.SetActive(true);
        return nextInstance;
    }

    public void ReturnToPool(PooledObject pooledObject)
    {
        stack.Push(pooledObject);
        pooledObject.gameObject.SetActive(false);
    }
}