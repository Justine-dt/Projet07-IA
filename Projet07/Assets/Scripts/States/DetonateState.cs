using System;
using UnityEngine;

public class DetonateState : State
{
    public static event Action<Transform> OnDetonate;
    public static event Action<Transform> OnStopDetonate;

    public override void OnEnter(Brain brain)
    {
        base.OnEnter(brain);
        OnDetonate?.Invoke(_brain.Render);
    }

    public override void OnExit()
    {
        base.OnExit();
        OnStopDetonate?.Invoke(_brain.Render);
    }
}