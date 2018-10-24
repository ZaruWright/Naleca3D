using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolEditor))]
public class PoolSpawnerByTime : MonoBehaviour {

    public float spawnTime;
    public float destroyTime;
    private PoolEditor m_poolEditor;

	// Use this for initialization
	void Start ()
    {
        m_poolEditor = GetComponent<PoolEditor>();
        InvokeRepeating("SpawnGameObject", spawnTime, spawnTime);

    } // PoolSpawnerByTime::Start

    void SpawnGameObject()
    {
        GameObject go = m_poolEditor.GetPool().Instantiate();

        if (go != null)
            StartCoroutine("DestroyGameObject", go);

    } // PoolSpawnerByTime::SpawnGameObject

    private IEnumerator DestroyGameObject(GameObject go)
    {
        yield return new WaitForSeconds(destroyTime);
        m_poolEditor.GetPool().Destroy(go);

    } // PoolSpawnerByTime::DestroyGameObject

} // class PoolSpawnerByTime
