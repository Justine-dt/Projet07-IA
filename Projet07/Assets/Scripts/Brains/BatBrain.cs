using System;
using UnityEngine;

public class BatBrain : Brain
{
    private static event Action<GameObject> OnFirstChase;
    private static bool isAnyBatInChaseState;

    protected override void Awake()
    {
        base.Awake();
        OnFirstChase += ChasePlayer;
    }

    private void OnDestroy()
    {
        OnFirstChase -= ChasePlayer;
    }

    protected override void ChangeState(State newState, GameObject target)
    {
        base.ChangeState(newState, target);

        if (newState is ChaseState && !isAnyBatInChaseState)
        {
            isAnyBatInChaseState = true;
            OnFirstChase?.Invoke(target);
        }
    }

    private void ChasePlayer(GameObject target)
    {
        if (CurrentState is not ChaseState) ChangeState(_chaseState, target);
    }
}
