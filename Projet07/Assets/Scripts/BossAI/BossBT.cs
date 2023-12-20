using UnityEngine;

public class GuardBT : Tree
{
    [SerializeField] Transform _bossTransform;
    [SerializeField] SpriteRenderer _bossRenderer;
    [SerializeField] float speed = 2f;

    [SerializeField] List<GameObject> _enemyprefabs;

    public static bool hasPlayerEnteredRoom = false;

    
    protected override Node SetupTree()
    {
        
        Node root = new Selector(new List<Node>
        {
            new BossMovement(_bossTransform, _bossRenderer),
            new BossSpawnAllies(_bossTransform, _enemyprefabs)
        });
        

        //Node root = new BossMovement(_bossTransform, _bossRenderer);

        return root;
    }
    
}