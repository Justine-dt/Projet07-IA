using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public bool Chasing => _chasing;

    protected Brain _brain;
    protected bool _chasing;

    protected Dictionary<Attribute, int> _stats => _brain.EntityStats.Stats;

    public virtual void OnEnter(Brain brain)
    {
        Debug.Log(GetType().Name);
        //Collision.OnCollide += OnCollide;
        _brain = brain;
    }

    public virtual void OnCollide() { }

    public virtual void OnHurt() { }

    public virtual void OnUpdate() { }

    public virtual void OnExit()
    {
        //Collision.OnCollide -= OnCollide;
    }
}