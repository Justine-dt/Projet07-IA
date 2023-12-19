using UnityEngine;

public class DeathState : State
{
    public override void OnEnter(Brain brain)
    {
        base.OnEnter(brain);

        //TODO -> Add death animation

        _brain.Sprite.color = Color.black;
        _brain.ClearDestinationTarget();

        //TODO -> delete object
        _brain.Render.gameObject.SetActive(false);
    }
}