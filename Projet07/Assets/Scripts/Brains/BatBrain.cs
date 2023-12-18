using UnityEngine;

public class BatBrain : Brain
{
    private static bool isAnyBatInChaseState = false;
    private Animator batAnimator;

    private void Start()
    {
        batAnimator = GetComponent<Animator>();
    }

    protected override void ChangeState(State newState, GameObject target)
    {
        base.ChangeState(newState, target);

        if (newState is ChaseState chaseState)
        {
            if (!isAnyBatInChaseState)
            {
                isAnyBatInChaseState = true;
                ChangeSpriteAnimation("Bat_Angry_Idle_Move");
                ChangeAllBatBrainsState(new ChaseState(), target);
            }
        }
        else
        {
            isAnyBatInChaseState = false;
            ChangeSpriteAnimation("Bat_Idle_Move");
        }
    }

    private void ChangeAllBatBrainsState(State state, GameObject target)
    {
        BatBrain[] allBatBrains = FindObjectsOfType<BatBrain>();

        foreach (BatBrain batBrain in allBatBrains)
        {
            batBrain.ChangeState(state, target);
        }
    }

    private void ChangeSpriteAnimation(string animationName)
    {
        if (batAnimator != null)
        {
            batAnimator.Play(animationName);
        }
    }
}
