using UnityEngine;

public class ChaseState : State
{
    public override void OnEnter(Brain brain)
    {
        Collision.OnCollide += OnCollide;
        Collision.OnStopCollide += OnStopCollide;

        base.OnEnter(brain);
        _chasing = true;
        _brain.Destination.target = _brain.Target.transform;
    }

    public override void OnExit()
    {
        Collision.OnCollide -= OnCollide;
        Collision.OnStopCollide -= OnStopCollide;

        base.OnExit();
    }

    public override void OnUpdate()
    {
        if (!_chasing && _brain.DealDamageOnCollide && WaitFor(_stats[Attribute.ATKSPEED])) Attack();
    }

    public override void OnCollide(Transform source)
    {
        base.OnCollide(source);
        _chasing = false;
    }

    public override void OnStopCollide(Transform source)
    {
        base.OnStopCollide(source);
        _chasing = true;
    }

    private void Attack()
    {
        _brain.GetTargetStats().TakeDamage(_stats[Attribute.ATTACK]);
        _brain.EntityStats.TakeDamage(1); //For testing only
        ResetCooldown();
    }
}