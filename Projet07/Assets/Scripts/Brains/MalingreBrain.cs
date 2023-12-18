using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class MalingreBrain : Brain
{
    [SerializeField] GameObject _malingre;
    [SerializeField] SpriteRenderer renderer;

    GameObject _player;
    GameObject[] obstacles;
    GameObject nearestObstacle;
    int numberOfObstacles;

    Vector2 playerPosition;
    Vector2 target;

    bool coroutineHasStarted = false;

    void Start()
    {

    }

    void Update()
    {
        //Recherche si le nombre d'obstacles a baissé | Si oui, refaire la recherche
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        if(obstacles.Length > 0)
        {
            SetTarget();
            numberOfObstacles = obstacles.Length;
        }
        else if (obstacles.Length != numberOfObstacles)
        {
            SetTarget();
            numberOfObstacles = obstacles.Length;
        }
        else if (obstacles.Length == 0 && coroutineHasStarted == false)
        {
            StartCoroutine(Panick());
            coroutineHasStarted = true;
        }

        _malingre.transform.position = Vector2.MoveTowards(_malingre.transform.position, target, Time.deltaTime * 4);
    }

    void SetTarget()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        //Find every obstacles
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        numberOfObstacles = obstacles.Length;

        //Find the nearest obstacle
        if (obstacles.Length > 0)
        {
            nearestObstacle = obstacles[0];
            for (int i = 0; i < obstacles.Length; i++)
            {
                GameObject currentObstacle = obstacles[i];

                //If the current obstacle is nearer than the previous one, update the variable nearestObstacle
                if ((_malingre.transform.position - currentObstacle.transform.position).magnitude < (_malingre.transform.position - nearestObstacle.transform.position).magnitude)
                {
                    nearestObstacle = currentObstacle;
                }
            }
        }

        //Put the direction of movement to the nearest obstacle
        target = nearestObstacle.transform.position;


        //Check position of player to go to the best side of the nearest obstacle to hide
        playerPosition = _player.transform.position - _malingre.transform.position;

        if (Mathf.Abs(target.x - playerPosition.x) > Mathf.Abs(target.y - playerPosition.y))
        {
            if (target.x - playerPosition.x > 0)
            {
                Debug.Log("Right");
                target.x += 1;
            }
            else
            {
                Debug.Log("Left");
                target.x -= 1;
            }
        }
        else
        {
            if (target.y - playerPosition.y > 0)
            {
                Debug.Log("Up");
                target.y += 1.4f;
            }
            else
            {
                Debug.Log("Down");
                target.y -= 1.4f;
            }
        }
    }

    IEnumerator Panick()
    {
        while (true)
        {
            Vector3 randomVector = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);

            target = _malingre.transform.position + randomVector;

            yield return new WaitForSeconds(0.25f);
        }
    }
}
