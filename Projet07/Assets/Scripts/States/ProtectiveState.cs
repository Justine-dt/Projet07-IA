using System;
using UnityEngine;

public class ProtectiveState : IdleState
{
    public static event Action<Transform> OnAllyHurt;

    public override void OnHurt()
    {
        base.OnHurt();

        OnAllyHurt?.Invoke(_brain.transform);
    }
}