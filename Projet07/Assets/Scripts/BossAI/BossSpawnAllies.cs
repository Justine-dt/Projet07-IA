using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

using BehaviorTree;
using System.Collections;

public class BossSpawnAllies : Node
{
    Transform _bossTransform;
    List<GameObject> _enemyPrefabs;
    UnityEvent _event;

    public BossSpawnAllies(Transform transform, List<GameObject> prefabs)
    {
        _bossTransform = transform;
        _enemyPrefabs = prefabs;
    }

    public override NodeState Evaluate()
    {
        //Instantiate 4 prefabs aléatoires dans une liste prédéfinies de chaque côté du boss s'il y a strictement moins de 8 ennemis dans la salle
        if(GameObject.FindGameObjectsWithTag("Enemy").Length < 8)
        {
            //Instantiate(_enemyPrefabs[Random.Range(0, _enemyPrefabs.Count)], (_bossTransform.position + new Vector3(3, 0, 0)), Quaternion.identity);
            Debug.Log("Spawn enemies");
        }



        Debug.Log("yiipeeeee");

        state = NodeState.RUNNING;
        return state;
    }
}
