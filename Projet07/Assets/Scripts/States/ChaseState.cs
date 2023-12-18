using UnityEngine;

public class ChaseState : State
{
    public override void OnEnter(Brain brain)
    {
        base.OnEnter(brain);
        _chasing = true;

        var pos = _brain.Render.transform.position;
        var targetPos = _brain.Target.transform.position;
        //Debug.Log($"bat pos : {pos}");
        //Debug.Log($"player pos : {targetPos}");
        //Debug.Log(Vector2.Distance(pos, targetPos));
    }

    public override void OnUpdate()
    {
        var pos = _brain.Render.transform.position;
        var targetPos = _brain.Target.transform.position;
        //Debug.Log(Vector2.Distance(pos, targetPos));

        if (Vector2.Distance(pos, targetPos) > 1f)
        {
            _brain.EntityMove.Move(targetPos - pos);
            return;
        }

        //Debug.Log($"bat pos : {pos}");
        //Debug.Log($"player pos : {targetPos}");
        Debug.Log(Vector2.Distance(pos, targetPos));

        OnCollide();
    }

    public override void OnCollide()
    {
        base.OnCollide();
        _chasing = false;
        _brain.EntityStats.Kill();
        //Debug.Log("collide, stop chasing");
    }
}