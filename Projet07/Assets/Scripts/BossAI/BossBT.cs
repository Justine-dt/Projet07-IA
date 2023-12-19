using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class GuardBT : BehaviorTree.Tree
{
    public Transform _bossTransform;
    public SpriteRenderer _bossRenderer;
    public static float speed = 2f;

    protected override Node SetupTree()
    {
        Node root = new BossMovement(_bossTransform, _bossRenderer);
        return root;
    }

}