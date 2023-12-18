using System;
using UnityEngine;

public class BatBrain : Brain
{
    private static event Action<GameObject> OnFirstChase;
    private static bool isAnyBatInChaseState = false;
    private Animator batAnimator;

    protected override void Awake()
    {
        base.Awake();
        batAnimator = GetComponent<Animator>();
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

    //private void ChangeSpriteAnimation(string animationName)
    //{
    //    if (batAnimator != null)
    //    {
    //        batAnimator.Play(animationName);
    //    }
    //}

    private void ChasePlayer(GameObject target)
    {
        if (CurrentState is ChaseState) return;
        ChangeState(_chaseState, target);
    }
}
