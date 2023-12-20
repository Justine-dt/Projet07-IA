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

    private void Protect(Transform source, GameObject target)
    {
        if (source == transform || source == _twin.transform)
        {
            ChangeState(_chaseState, target);
            ProtectiveState.OnAllyHurt -= Protect;
        }
    }

    private void Berserk()
    {
        _isAlwaysChasing = true;
        _entityStats.BoostStat(Attribute.ATTACK);
        _aiPath.maxSpeed *= 2;
        //TODO -> change animation or sprite color ?
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (!IsTriggerValid(collision)) return;
        if (_isAlwaysChasing) return;
        ChangeState(_protectiveState);
        ProtectiveState.OnAllyHurt += Protect;
    }
}