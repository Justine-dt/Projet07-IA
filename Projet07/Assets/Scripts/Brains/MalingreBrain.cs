using System.Collections;
using UnityEngine;
using TMPro;

public class MalingreBrain : Brain
{
    [SerializeField] GameObject _malingre;
    [SerializeField] SpriteRenderer renderer;

    GameObject _player;
    GameObject[] obstacles;
    GameObject nearestObstacle;
    int numberOfObstacles;

    Vector3 playerPosition;
    Vector3 target;

    bool isPanicking = false;
    bool isShooting = false;

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
        else if (obstacles.Length == 0 && isPanicking == false)
        {
            StartCoroutine(Panick());
            isPanicking = true;
        }

        /*
        //Si le malingre est caché, on lance la coroutine shoot
        if(_malingre.transform.position.x == target.x && _malingre.transform.position.y == target.y && isPanicking == false && isShooting == false)
        {
            StartCoroutine(Shoot());
            isShooting = true;
        }
        else
        {
            StopCoroutine(Shoot());
            isShooting = false;
        }
        */

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
                if ((transform.position - currentObstacle.transform.position).magnitude < (transform.position - nearestObstacle.transform.position).magnitude)
                {
                    nearestObstacle = currentObstacle;
                }
            }
        }

        //Put the direction of movement to the nearest obstacle
        target = nearestObstacle.transform.position;


        //Check position of player to go to the best side of the nearest obstacle to hide
        playerPosition = _player.transform.position - transform.position;

        if (Mathf.Abs(target.x - playerPosition.x) > Mathf.Abs(target.y - playerPosition.y))
        {
            if (target.x - playerPosition.x > 0)
            {
                target.x += 1.2f;
            }
            else
            {
                target.x -= 1.2f;
            }
        }
        else
        {
            if (target.y - playerPosition.y > 0)
            {
                target.y += 1.5f;
            }
            else
            {
                target.y -= 1.5f;
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

    IEnumerator Shoot()
    {
        while (true)
        {
            Debug.Log("TIIIIR");

            yield return new WaitForSeconds(1f);
        }
    }
}
