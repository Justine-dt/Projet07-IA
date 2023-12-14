using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class MalingreBrain : MonoBehaviour
{
    [SerializeField] GameObject _malingre;
    [SerializeField] SpriteRenderer renderer;
    GameObject _player;

    UnityEngine.Vector2 target;

    public GameObject[] obstacles;
    GameObject nearestObstacle;

    Vector2 playerPosition;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        //Find every obstacles
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        float baseMagnitude = 100.0f;

        //Find the nearest obstacle
        if (obstacles.Length > 0)
        {
            foreach (GameObject obstacle in obstacles)
            {
                //If the current obstacle is nearer than the previous one, update the variable nearestObstacle
                if(obstacle.transform.position.magnitude < baseMagnitude)
                {
                    nearestObstacle = obstacle;
                    baseMagnitude = obstacle.transform.position.magnitude;
                }
            }
        }

        //Put the direction of movement to the nearest obstacle
        target = nearestObstacle.transform.position;


        //Check position of player to go to the best side of the nearest obstacle to hide
        playerPosition = _player.transform.position - _malingre.transform.position;

        if(Mathf.Abs(playerPosition.x) > Mathf.Abs(playerPosition.y))
        {
            if(playerPosition.x > 0)
            {
                target.x -= 1;
            }
            else
            {
                target.x += 1;
            }
        }
        else
        {
            if (playerPosition.y > 0)
            {
                target.y -= 1.4f;
            }
            else
            {
                target.y += 1.4f;
            }
        }


    }


    void Update()
    {
        _malingre.transform.position = Vector2.MoveTowards(_malingre.transform.position, target, Time.deltaTime * 4);
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);

        if (collision.collider.name == "UpDownEnemyWalls")
        {
            target.y *= -1;
        }

        if (collision.collider.name == "SideEnemyWalls")
        {
            target.x *= -1;

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
