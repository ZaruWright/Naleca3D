using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEditor : MonoBehaviour {

    public GameObject m_objectToPool;
    public int m_poolSize;
    private Pool m_pool;

	// Use this for initialization
	void Start ()
    {
        m_pool = new Pool(m_objectToPool, m_poolSize);

    } // PoolEditor::Start

    public Pool GetPool()
    {
        return m_pool;

    } // PoolEditor::GetPool

} // class PoolEditor
