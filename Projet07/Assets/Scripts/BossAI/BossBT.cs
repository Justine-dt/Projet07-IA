using UnityEngine;

public class GuardBT : Tree
{
    public Transform _bossTransform;
    public SpriteRenderer _bossRenderer;
    public float speed = 2f;

    public static bool hasPlayerEnteredRoom = false;

    
    protected override Node SetupTree()
    {
        /*
        Node root = new Sequence(new List<Node>
        {
            new BossMovement(_bossTransform, _bossRenderer),
            new BossSpawnAllies(_bossTransform)
        });
        */

        Node root = new BossMovement(_bossTransform, _bossRenderer);

        return root;
    }
    
}