using UnityEngine;

using BehaviorTree;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BossMovement : Node
{
    UnityEngine.Transform _bossTransform;
    SpriteRenderer _bossRenderer;
    UnityEngine.Vector2 direction;

    float _speed = 1.5f;

    bool canMove = true;

    public BossMovement(UnityEngine.Transform transform, SpriteRenderer renderer)
    {
        direction.Set(1.0f, 1.0f);
        _bossTransform = transform;
        _bossRenderer = renderer;

        _bossTransform.GetComponent<Rebond>().OnReboundY += ChangeDirectionY;
        _bossTransform.GetComponent<Rebond>().OnReboundX += ChangeDirectionX;

        _bossTransform.GetComponent<SpawnEnemies>().StartSpawn += StopMovement;
        _bossTransform.GetComponent<SpawnEnemies>().StopSpawn += ContinueMovement;
    }


    public override NodeState Evaluate()
    {
        if(canMove)
        {
            _bossTransform.Translate(direction * Time.deltaTime * _speed);
        }

        state = NodeState.RUNNING;
        return state;
    }

    void ChangeDirectionY()
    {
        direction.y *= -1;
    }

    void ChangeDirectionX()
    {
        direction.x *= -1;
        _bossRenderer.flipX = !_bossRenderer.flipX;
    }

    void StopMovement()
    {
        canMove = false;
    }

    void ContinueMovement()
    {
        canMove = true;
    }

}
