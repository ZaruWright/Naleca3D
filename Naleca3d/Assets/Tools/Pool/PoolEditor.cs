using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEditor : MonoBehaviour {

    public GameObject m_objectToPool;
    public int m_poolSize;
    private Pool m_pool;

	// Use this for initialization
	void Start () {
        m_pool = new Pool(m_objectToPool, m_poolSize);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
