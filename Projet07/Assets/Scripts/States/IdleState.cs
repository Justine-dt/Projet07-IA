using UnityEngine;

public class IdleState : State
{
    private float _random;
    private GameObject _waypoint;

    public override void OnEnter(Brain brain)
    {
        base.OnEnter(brain);
        if (!_brain.Ismoving) return;
        _random = -1;
        //_waypoint = new GameObject("Waypoint");
        _brain.Destination.target = _waypoint.GetComponent<Transform>();
        _brain.Destination.target.position = _brain.Render.position;
    }

    public override void OnUpdate()
    {
        if (!_brain.Ismoving) return;
        if (_random == -1 || WaitFor(_random)) NewDestination();
    }

    public override void OnHurt(SpriteRenderer source, GameObject damageDealer)
    {
        base.OnHurt(source, damageDealer);
        if (!_hurted) return;
        Debug.Log($"=> HURTED : {source.transform.parent.name}");

        if (_brain.IsFleeing)
        {
            _brain.ChangeState(new RunAwayState(), damageDealer);
            return;
        }

        if (!_brain.Ismoving) return;
        _brain.ChangeState(new ChaseState(), damageDealer);
    }

    private void NewDestination()
    {
        _random = Random.Range(2f, 4f);
        Vector2 destination = new(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        _brain.Destination.target.Translate(destination);
        _brain.Sprite.flipX = destination.x < 0;

        ResetCooldown();
    }
}