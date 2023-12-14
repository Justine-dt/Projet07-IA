using UnityEngine;

public class ChaseState : State
{
    public override void OnUpdate()
    {
        var pos = _brain.Render.transform.position;
        var targetPos = _brain.Target.transform.position;

        while (Vector2.Distance(pos, targetPos) > 1f)
        {
            _brain.EntityMove.Move(targetPos - pos);
        }
    }
}