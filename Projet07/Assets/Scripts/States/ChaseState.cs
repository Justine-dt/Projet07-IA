using UnityEngine;

public class ChaseState : State
{
    public override void OnEnter(Brain brain)
    {
        base.OnEnter(brain);
        _chasing = true;
    }

    public override void OnUpdate()
    {
        var pos = _brain.Render.transform.position;
        var targetPos = _brain.Target.transform.position;

        if (Vector2.Distance(pos, targetPos) > 1f)
        {
            _brain.EntityMove.Move(targetPos - pos);
            return;
        }

        OnCollide();
    }

    public override void OnCollide()
    {
        base.OnCollide();
        _chasing = false;
    }
}