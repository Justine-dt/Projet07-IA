using System;
using UnityEngine;

public class ProtectiveState : IdleState
{
    public static event Action<Transform, GameObject> OnAllyHurt;

    public override void OnHurt(SpriteRenderer source, GameObject damageDealer)
    {
        base.OnHurt(source, damageDealer);
        OnAllyHurt?.Invoke(_brain.transform, damageDealer);
    }
}