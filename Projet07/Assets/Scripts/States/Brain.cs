using UnityEngine;

public abstract class Brain : MonoBehaviour
{
    [SerializeField] protected EntityMove _entityMove;
    [SerializeField] protected Transform _render;

    public EntityMove EntityMove => _entityMove;
    public Transform Render => _render;
    public GameObject Target => _target;

    private GameObject _target;
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

    protected void ChangeState(State newState, GameObject target)
    {
        _target = target;
        ChangeState(newState);
    }

    public void ClearTarget()
    {
        _target = null;
    }
}