using System;
using UnityEngine;

public class DetonateState : State
{
    public static event Action<Transform> OnDetonate;
    public static event Action<Transform> OnStopDetonate;

    public override void OnEnter(Brain brain)
    {
        DetonateAction.OnExplode += Detonate;

        base.OnEnter(brain);
        OnDetonate?.Invoke(_brain.Render);

        _brain.ClearDestinationTarget();
    }

    public override void OnExit()
    {
        DetonateAction.OnExplode -= Detonate;
        base.OnExit();
        OnStopDetonate?.Invoke(_brain.Render);
    }

    public void Detonate()
    {
        _brain.GetTargetStats().TakeDamage(_stats[Attribute.ATTACK], _brain.Sprite.gameObject);
        _brain.EntityStats.Kill();
    }
}