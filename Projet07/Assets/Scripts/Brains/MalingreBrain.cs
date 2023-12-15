using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class MalingreBrain : MonoBehaviour
{
    public GameObject _malingre;
    [SerializeField] SpriteRenderer renderer;

    public GameObject _player;
    public GameObject[] obstacles;
    public GameObject nearestObstacle;

    public Vector2 target;
    public Vector2 playerPosition;

    IState currentState;

    void Start()
    {
        #region Recherche d'obstacles et calcul de target,,,,
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
                if (obstacle.transform.position.magnitude < baseMagnitude)
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

        if (Mathf.Abs(target.x - _player.transform.position.x) > Mathf.Abs(target.y - _player.transform.position.y))
        {
            if (target.x - _player.transform.position.x > 0)
            {
                target.x += 1;
            }
            else
            {
                target.x -= 1;
            }
        }
        else
        {
            if (target.y - _player.transform.position.y > 0)
            {
                target.y += 1.4f;
            }
            else
            {
                target.y -= 1.4f;
            }
        }
        #endregion

    }

    void Update()
    {
        _malingre.transform.position = Vector2.MoveTowards(_malingre.transform.position, target, Time.deltaTime * 4);
    }

    
}
