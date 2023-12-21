using UnityEngine;

public class BossMovement : Node
{
    Transform _bossTransform;
    SpriteRenderer _bossRenderer;
    UnityEngine.Vector2 direction;

    float _speed = 2f;
    

    public BossMovement(Transform transform, SpriteRenderer renderer)
    {
        direction.Set(1.0f, 1.0f);
        _bossTransform = transform;
        _bossRenderer = renderer;
    }


    public override NodeState Evaluate()
    {
        _bossTransform.Translate(direction * Time.deltaTime * _speed);

        _state = NodeState.RUNNING;
        return _state;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.name == "UpDownEnemyWalls")
        {
            direction.y *= -1;
        }

        if (collision.collider.name == "SideEnemyWalls")
        {
            direction.x *= -1;

            if (_bossRenderer.flipX == true)
            {
                _bossRenderer.flipX = false;
            }
            else if (_bossRenderer.flipX == false)
            {
                _bossRenderer.flipX = true;
            }
        }

        //Rajouter tremblements de caméra

    }

}
