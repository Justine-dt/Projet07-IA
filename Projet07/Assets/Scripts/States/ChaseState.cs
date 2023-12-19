using UnityEngine;

public class ChaseState : State
{
    public override void OnEnter(Brain brain)
    {
        base.OnEnter(brain);
        _chasing = true;
        _brain.Destination.target = _brain.Target.transform;
    }

    public override void OnUpdate()
    {
        //OnCollide();
    }

    public override void OnCollide()
    {
        base.OnCollide();
        _chasing = false;

        if (_brain.DealDamageOnCollide && WaitFor(_stats[Attribute.ATKSPEED])) Attack();
    }

    private void Attack()
    {
        _brain.GetTargetStats().TakeDamage(_stats[Attribute.ATTACK]);
        ResetCooldown();
    }
}