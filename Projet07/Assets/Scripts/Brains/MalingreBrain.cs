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

    }

    void Update()
    {

    }

    
}
