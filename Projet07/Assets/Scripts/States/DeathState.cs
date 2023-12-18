using UnityEngine;

public class DeathState : State
{
    public override void OnEnter(Brain brain)
    {
        base.OnEnter(brain);
        //Add death animation
        _brain.Sprite.color = Color.black;
    }
}