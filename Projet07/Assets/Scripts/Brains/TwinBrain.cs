using UnityEngine;
//TODO -> les rapprocher parfois de façon random ?

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

    protected override void Update()
    {
        base.Update();
        if (_twin.EntityStats.IsDead && !_isAlwaysChasing) Berserk();
    }

    public void SetTwin(TwinBrain twin)
    {
        _twin = twin;
    }

    private void Protect(Transform source)
    {
        if (source == transform || source == _twin.transform)
        {
            ChangeState(_chaseState);
            ProtectiveState.OnAllyHurt -= Protect;
        }
    }

    private void Berserk()
    {
        _isAlwaysChasing = true;
        //TODO -> boost attack and speed
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (_isAlwaysChasing && !IsTriggerValid(collision)) return;
        ChangeState(_protectiveState);
        ProtectiveState.OnAllyHurt += Protect;
    }
}