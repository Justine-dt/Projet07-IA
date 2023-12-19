using UnityEngine;

public class IdleState : State
{
    private float _random;
    private GameObject _waypoint;

    public override void OnEnter(Brain brain)
    {
        base.OnEnter(brain);
        _random = -1;
        _waypoint = new GameObject("Waypoint");
        _brain.Destination.target = _waypoint.GetComponent<Transform>();
        _brain.Destination.target.position = _brain.Render.position;
    }

    public override void OnExit()
    {
        base.OnExit();
        Object.Destroy(_waypoint);
    }

    public override void OnUpdate()
    {
        if (_random == -1 || WaitFor(_random)) NewDestination();
    }

    private void NewDestination()
    {
        _random = Random.Range(2f, 4f);
        Vector2 destination = new(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        _brain.Destination.target.Translate(destination);

        if (destination.x < 0)
        {
            _brain.Sprite.flipX = true;
        }
        else if (_brain.Sprite.flipX = true && destination.x > 0)
        {
            _brain.Sprite.flipX = false;
        }

        ResetCooldown();
    }
}