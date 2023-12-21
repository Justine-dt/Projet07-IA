using UnityEngine;
using System.Collections.Generic;

using BehaviorTree;

public class BossBT : BehaviorTree.Tree
{
    [SerializeField] Transform _bossTransform;
    [SerializeField] SpriteRenderer _bossRenderer;

    public static bool hasPlayerEnteredRoom = false;

    
    protected override Node SetupTree()
    {

        Node root = new BossMovement(_bossTransform, _bossRenderer);
        //new BossSpawnAllies(_bossTransform, _enemyprefabs)

        return root;
    }
    


}