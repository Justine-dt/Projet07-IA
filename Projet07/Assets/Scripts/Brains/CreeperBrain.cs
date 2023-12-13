using UnityEngine;

public class CreeperBrain : Brain
{
    private IdleState _idleState = new();
    private ChaseState _chaseState = new();

    private void Awake()
    {
        ChangeState(_idleState);
    }

    private void Update()
    {
        //
    }
}