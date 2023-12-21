using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public List<GameObject> _enemyPrefabs;

    public event Action StartSpawn;
    public event Action StopSpawn;

    [SerializeField] Animator _animator;

    void Start()
    {
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {
        while (true)
        {

            yield return new WaitForSeconds(10.0f);


            if (GameObject.FindGameObjectsWithTag("Enemy").Length < 8)
            {
                StartSpawn?.Invoke();

                yield return new WaitForSeconds(2.0f);

                Instantiate(_enemyPrefabs[UnityEngine.Random.Range(0, _enemyPrefabs.Count)], (transform.position + new Vector3(4, 0, 0)), Quaternion.identity);
                Instantiate(_enemyPrefabs[UnityEngine.Random.Range(0, _enemyPrefabs.Count)], (transform.position + new Vector3(-4, 0, 0)), Quaternion.identity);
                Instantiate(_enemyPrefabs[UnityEngine.Random.Range(0, _enemyPrefabs.Count)], (transform.position + new Vector3(0, 4, 0)), Quaternion.identity);
                Instantiate(_enemyPrefabs[UnityEngine.Random.Range(0, _enemyPrefabs.Count)], (transform.position + new Vector3(0, -4, 0)), Quaternion.identity);

                yield return new WaitForSeconds(1.0f);

                StopSpawn?.Invoke();
            }
        }
    }
}
