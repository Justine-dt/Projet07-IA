using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public List<GameObject> _enemyPrefabs;

    public event Action StartSpawn;
    public event Action StopSpawn;

    bool areEnemiesInstantiated = false;

    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Debug.Log("avant le premier wait");

            yield return new WaitForSeconds(2.0f);

            Debug.Log("boucle");

            if (GameObject.FindGameObjectsWithTag("Enemy").Length < 8)
            {
                StartSpawn?.Invoke();

                yield return new WaitForSeconds(2.0f);

                if(areEnemiesInstantiated == false)
                {
                    Debug.Log("Wtf les amis");

                    Instantiate(_enemyPrefabs[UnityEngine.Random.Range(0, _enemyPrefabs.Count)], (transform.position + new Vector3(3, 0, 0)), Quaternion.identity);
                    Instantiate(_enemyPrefabs[UnityEngine.Random.Range(0, _enemyPrefabs.Count)], (transform.position + new Vector3(-3, 0, 0)), Quaternion.identity);
                    Instantiate(_enemyPrefabs[UnityEngine.Random.Range(0, _enemyPrefabs.Count)], (transform.position + new Vector3(0, 4, 0)), Quaternion.identity);
                    Instantiate(_enemyPrefabs[UnityEngine.Random.Range(0, _enemyPrefabs.Count)], (transform.position + new Vector3(0, -4, 0)), Quaternion.identity);

                    areEnemiesInstantiated = true;
                }


                yield return new WaitForSeconds(1.0f);

                StopSpawn?.Invoke();
            }
        }
    }
}
