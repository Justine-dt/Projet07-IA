using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public bool Chasing => _chasing;

    protected Brain _brain;
    protected bool _chasing;
    protected float _cooldown;
    protected bool _hurted;
    protected bool _collided;

    protected Dictionary<Attribute, int> _stats => _brain.EntityStats.Stats;

    public virtual void OnEnter(Brain brain)
    {
        EntityStats.OnHurt += OnHurt;
        _brain = brain;
        _cooldown = Time.time + _stats[Attribute.ATKSPEED];
        _hurted = false;
        _collided = false;

        if (this is IdleState) return;
        Debug.Log($"New state for {_brain.transform.parent.name} : {GetType().Name}");
    }

    public virtual void OnCollide(Transform source)
    {
        if (source == _brain.Render) _collided = true;
    }

    public virtual void OnStopCollide(Transform source)
    {
        if (source == _brain.Render) _collided = true;
    }

    public virtual void OnHurt(SpriteRenderer source, GameObject damageDealer)
    {
        if (source == _brain.Sprite) _hurted = true;
    }

    public virtual void OnUpdate() { }

    public virtual void OnExit()
    {
        EntityStats.OnHurt -= OnHurt;
    }

    protected bool WaitFor(float time)
    {
        return Time.time >= _cooldown + time;
    }

    protected void ResetCooldown()
    {
        _cooldown = Time.time;
    }
}