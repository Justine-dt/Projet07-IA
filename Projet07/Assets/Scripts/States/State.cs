using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public bool Chasing => _chasing;

    protected Brain _brain;
    protected bool _chasing;
    protected float _cooldown;

    protected Dictionary<Attribute, int> _stats => _brain.EntityStats.Stats;

    public virtual void OnEnter(Brain brain)
    {
        Debug.Log(GetType().Name);
        //Collision.OnCollide += OnCollide;
        _brain = brain;
        _cooldown = Time.time + _stats[Attribute.ATKSPEED];
    }

    public virtual void OnCollide() { }

    public virtual void OnHurt() { }

    public virtual void OnUpdate() { }

    public virtual void OnExit()
    {
        //Collision.OnCollide -= OnCollide;
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