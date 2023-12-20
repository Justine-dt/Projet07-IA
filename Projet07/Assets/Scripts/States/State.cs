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
        EntityStats.OnHurt += OnHurt;
        Debug.Log(GetType().Name);
        //Collision.OnCollide += OnCollide;
        _brain = brain;
        _cooldown = Time.time + _stats[Attribute.ATKSPEED];
    }

    public virtual void OnCollide(Transform source)
    {
        if (source != _brain.Render) return;
    }

    public virtual void OnStopCollide(Transform source)
    {
        if (source != _brain.Render) return;
    }

    public virtual void OnHurt(SpriteRenderer source, GameObject damageDealer)
    {
        if (source != _brain.Sprite) return;
    }

    public virtual void OnUpdate() { }

    public virtual void OnExit()
    {
        EntityStats.OnHurt -= OnHurt;
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