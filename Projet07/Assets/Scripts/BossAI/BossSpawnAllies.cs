using UnityEngine;

public class BossSpawnAllies : Node
{
    Transform _bossTransform;

    public BossSpawnAllies(Transform transform)
    {
        _bossTransform = transform;
    }

    public override NodeState Evaluate()
    {
        //Instantiate 4 prefabs aléatoires dans une liste prédéfinies de chaque côté du boss

        Debug.Log("yiipeeeee");

        _state = NodeState.RUNNING;
        return _state;
    }

}
