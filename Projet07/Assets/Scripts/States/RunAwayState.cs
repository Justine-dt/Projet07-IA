using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class RunAwayState : State
{
    private GameObject _waypoint;
    private Vector2 _playerPosition;
    private Vector2 _waypointPosition;
    private Vector2 _cowardPosition;
    ChaseState _chaseState = new();

    public override void OnEnter(Brain brain)
    {
        Debug.Log("RunAwayState");
        base.OnEnter(brain);
        _waypoint = new GameObject("Waypoint");
        // Get all positions
        _playerPosition = _brain.Target.transform.position;
        _waypointPosition = _waypoint.transform.position;
        _cowardPosition = _brain.Render.transform.position;
        //Debug.Log("PlayerPosition" + _playerPosition);
        //Debug.Log("CowardPosition 1 " + _cowardPosition);

        // Make the coward flee in the opposite direction to the player
        _waypointPosition.x = _cowardPosition.x + (_cowardPosition.x - _playerPosition.x);
        _waypointPosition.y = _cowardPosition.y + (_cowardPosition.y - _playerPosition.y);

        _brain.Destination.target = _waypoint.GetComponent<Transform>();
        _brain.Destination.target.position = _waypointPosition;
        //Debug.Log("WaypointPosition" + _waypointPosition);

    }
    public override void OnUpdate()
    {
        // si atteint waypoint
        _cowardPosition = _brain.Render.transform.position; 
        float distance = Vector3.Magnitude(_waypointPosition - _cowardPosition);
        //Debug.Log("Distance " + distance);
        if (distance < 1)
        {
            Debug.Log("Changed back to ChaseState");
            _brain.ChangeState(_chaseState);
        }   
    }
}
