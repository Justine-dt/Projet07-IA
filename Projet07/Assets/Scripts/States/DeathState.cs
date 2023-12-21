using UnityEngine;

public class DeathState : State
{
    public override void OnEnter(Brain brain)
    {
        base.OnEnter(brain);

        //TODO -> Add death animation
        Object.Destroy(_brain.transform.parent.gameObject);
    }
}