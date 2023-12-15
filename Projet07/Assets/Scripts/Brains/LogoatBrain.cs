using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class LogoatBrain : MonoBehaviour
{
    [SerializeField] GameObject _logoat;
    [SerializeField] SpriteRenderer renderer;
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
        Debug.Log(collision.collider.name);

        if (collision.collider.name == "UpDownEnemyWalls")
        {
            direction.y *= -1;
        }

        if (collision.collider.name == "SideEnemyWalls")
        {
            direction.x *= -1;

            if (renderer.flipX == true)
            {
                renderer.flipX = false;
            }
            else if (renderer.flipX == false)
            {
                renderer.flipX = true;
            }
        }
    }
}
