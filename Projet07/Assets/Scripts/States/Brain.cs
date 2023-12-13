using UnityEngine;

public abstract class Brain : MonoBehaviour
{
    protected State _currentState;

    private void Update()
    {
        _currentState?.OnUpdate();
    }

    protected void ChangeState(State newState)
    {
        _currentState?.OnExit();
        _currentState = newState;
        _currentState.OnEnter(this);
    }
}