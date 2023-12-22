using UnityEngine;

public class DeathState : State
{
    public override void OnEnter(Brain brain)
    {
        base.OnEnter(brain);

        //TODO -> Add death animation
        if (brain is PlayerBrain)
        {
            GameManager.Instance.GameOver();
            brain.Sprite.color = Color.black;
            return;
        }

        Object.Destroy(_brain.transform.parent.gameObject);
    }
}