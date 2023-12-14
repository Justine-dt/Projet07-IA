using UnityEngine;

public class CreeperBrain : Brain
{
    private IdleState _idleState = new();

    private void Awake()
    {
        ChangeState(_idleState);
    }
}