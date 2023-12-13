using UnityEngine;
using System.Collections;
public abstract class State
{
    protected Brain _brain;

    public virtual void OnEnter(Brain brain)
    {
        Collision.OnHurt += OnHurt;
        _brain = brain;
    }

    public virtual void OnHurt()
    {
        _brain.ClearTarget();
    }

    public virtual void OnUpdate() { }

    public virtual void OnExit()
    {
        Collision.OnHurt -= OnHurt;
    }
}