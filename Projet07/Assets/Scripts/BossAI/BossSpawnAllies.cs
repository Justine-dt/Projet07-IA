using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class BossSpawnAllies : Node
{
    Transform _bossTransform;

    public BossSpawnAllies(Transform transform)
    {
        _bossTransform = transform;
    }

    public override NodeState Evaluate()
    {
        //Instantiate 4 prefabs al�atoires dans une liste pr�d�finies de chaque c�t� du boss

        Debug.Log("yiipeeeee");

        state = NodeState.RUNNING;
        return state;
    }

}
