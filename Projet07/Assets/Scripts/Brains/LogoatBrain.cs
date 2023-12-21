using UnityEngine;

public class LogoatBrain : MonoBehaviour
{
    [SerializeField] GameObject _logoat;
    [SerializeField] SpriteRenderer _renderer;
    UnityEngine.Vector2 direction;

    void Start()
    {
        direction.Set(1.0f, 1.0f);
    }

    void Update()
    {
        //entityMove.Move(direction);
        _logoat.transform.Translate(direction * Time.deltaTime * 3);
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

            if (_renderer.flipX == true)
            {
                _renderer.flipX = false;
            }
            else if (_renderer.flipX == false)
            {
                _renderer.flipX = true;
            }
        }
    }
}
