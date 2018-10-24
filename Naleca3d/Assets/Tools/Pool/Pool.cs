using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool {

    #region PoolAuxiliarStructures

    struct PoolElement
    {
        public UnityEngine.GameObject m_objectToPool;
        public bool m_isUsed;
    } // struct PoolElement

    #endregion // PoolAuxiliarStructures

    #region InitializeVariables

    private UnityEngine.GameObject m_objectToPool;
    private UnityEngine.GameObject m_parentGameobject;
    private readonly int m_poolSize;
    private Dictionary<string, PoolElement> m_pool;

    #endregion // InitializeVariables

    public Pool(UnityEngine.GameObject objectToPool, int poolSize)
    {
        m_objectToPool = objectToPool;
        m_poolSize = poolSize;

        m_parentGameobject = new GameObject(m_objectToPool.name + "Pool");

        m_pool = new Dictionary<string, PoolElement>();
        for (int i = 0; i < m_poolSize; ++i)
        {
            string elementName = m_objectToPool.name + "_" + i;
            PoolElement newElement;
            newElement.m_isUsed = false;
            newElement.m_objectToPool = Object.Instantiate(m_objectToPool);
            newElement.m_objectToPool.SetActive(false);
            newElement.m_objectToPool.transform.SetParent(m_parentGameobject.transform);
            newElement.m_objectToPool.name = elementName;

            m_pool[elementName] = newElement;
        }

    } // Pool::Pool

    private int m_searchingIndex;
    // Returns the next pooled gameobject available. If all of them are used
    // we will return a null gameobject
    private PoolElement GetPooledGameObject()
    {
        PoolElement result;
        result.m_objectToPool = null;
        result.m_isUsed = true;

        int itemsCovered = 0;
        bool found = false;
        string elementNamePrefix = m_objectToPool.name + "_";
        while (!found && itemsCovered < m_poolSize)
        {
            PoolElement possibleElement = m_pool[elementNamePrefix + m_searchingIndex];

            if (!possibleElement.m_isUsed) { found = true; result = possibleElement; }

            ++itemsCovered;
            m_searchingIndex = (m_searchingIndex + 1) % m_poolSize;
        }

        return result;

    } // Pool::GetPooledGameObject

    public UnityEngine.GameObject Instantiate()
    {
        PoolElement poolElement = GetPooledGameObject();

        if (poolElement.m_objectToPool != null)
        {
            poolElement.m_isUsed = true;
            poolElement.m_objectToPool.SetActive(true);
            m_pool[poolElement.m_objectToPool.name] = poolElement;
            return poolElement.m_objectToPool;
        }
        else
        {
            NalecaDebug.Log("I can't instantiate an object because you are using whole of them",
                            NalecaDebug.Severity.Error);
        }

        return null;

    } // Pool::Instantiate

    public void Destroy(UnityEngine.GameObject gameObject)
    {
        if (m_pool.ContainsKey(gameObject.name))
        {
            PoolElement poolElement = m_pool[gameObject.name];
            poolElement.m_isUsed = false;
            poolElement.m_objectToPool.SetActive(false);

            m_pool[gameObject.name] = poolElement;
        }
        else
        {
            NalecaDebug.Log("I can't find the object you are trying to destroy (" + gameObject.name + ")", 
                            NalecaDebug.Severity.Error);
        }

    } // Pool::Destroy

} // class Pool 
