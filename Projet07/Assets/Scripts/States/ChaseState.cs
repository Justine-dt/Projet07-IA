using UnityEngine;

public class ChaseState : State
{
    public override void OnEnter(Brain brain)
    {
        base.OnEnter(brain);
        Collision.OnCollide += OnCollide;
        Collision.OnStopCollide += OnStopCollide;

        _chasing = true;
        _brain.Destination.target = _brain.Target.transform;
        //Debug.Log($"Chasing {_brain.Target.transform.parent.name} at {_brain.Target.transform.position}");
    }

    public override void OnExit()
    {
        base.OnExit();
        Collision.OnCollide -= OnCollide;
        Collision.OnStopCollide -= OnStopCollide;
    }

    public override void OnUpdate()
    {
        if (!_chasing && _brain.DealDamageOnCollide && WaitFor(_stats[Attribute.ATKSPEED])) Attack();
    }

    public override void OnCollide(Transform source)
    {
        base.OnCollide(source);
        if (_collided) _chasing = false;
    }

    public override void OnStopCollide(Transform source)
    {
        base.OnStopCollide(source);
        if (_collided) _chasing = true;
    }

    private void Attack()
    {
        _brain.GetTargetStats().TakeDamage(_stats[Attribute.ATTACK], _brain.Sprite.gameObject);
        //_brain.EntityStats.TakeDamage(1, _brain.Target); //For testing only
        ResetCooldown();
    }
}