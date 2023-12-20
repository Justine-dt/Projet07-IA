using UnityEngine;

public class TwinBrain : Brain
{
    private TwinBrain _twin;

    protected override void Awake()
    {
        ProtectiveState.OnAllyHurt += Protect;
        ChangeState(_protectiveState);
    }

    private void OnDestroy()
    {
        ProtectiveState.OnAllyHurt -= Protect;
    }

    public void SetTwin(TwinBrain twin)
    {
        _twin = twin;
    }

    private void Protect(Transform source)
    {
        if (source == transform)
        {
            _twin.ChangeState(_chaseState);
            ChangeState(_chaseState);
            ProtectiveState.OnAllyHurt -= Protect;
        }
    }
}