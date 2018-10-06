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

    private UnityEngine.GameObject m_objectToPool = null;
    private UnityEngine.GameObject m_parentGameobject = null;
    private int m_poolSize = 0;
    private PoolElement[] m_pool;

    #endregion // InitializeVariables

    public Pool(UnityEngine.GameObject objectToPool, int poolSize)
    {
        m_objectToPool = objectToPool;
        m_poolSize = poolSize;

        m_parentGameobject = new GameObject(m_objectToPool.name + "Pool");

        m_pool = new PoolElement[m_poolSize];
        for (int i = 0; i < m_poolSize; ++i)
        {
            PoolElement newElement;
            newElement.m_isUsed = false;
            newElement.m_objectToPool = Object.Instantiate(m_objectToPool);
            newElement.m_objectToPool.SetActive(false);
            newElement.m_objectToPool.transform.SetParent(m_parentGameobject.transform);

            m_pool[i] = newElement;
        }

        // TODO: instantiate method, destroy method and think about how many structures you need to 
        // achieve the pool (i think that with only one with in which you save the free elements is
        // enought to do it)

    } // Pool::Pool

} // class Pool 
