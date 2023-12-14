using UnityEngine;

public class CreeperBrain : Brain
{
    protected override void Update()
    {
        base.Update();

        if (_currentState == _chaseState && !_currentState.Chasing)
        {
            ChangeState(_detonateState);
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (!_isAlwaysChasing && !IsTriggerValid(collision)) return;

        if (_currentState.Chasing)
        {
            ChangeState(_idleState);
            return;
        }

        ChangeState(_chaseState);
    }
}