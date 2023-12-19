using UnityEngine;

public class IdleState : State
{
    private float _random;
    private Vector2 _randomDestination;

    public override void OnEnter(Brain brain)
    {
        base.OnEnter(brain);
        _random = -1;
        _brain.Destination.target = _brain.Waypoint;
    }

    public override void OnUpdate()
    {
        if (_random == -1 || WaitFor(_random)) NewDestination();

        //if (Vector2.Distance(_brain.Render.position, _randomDestination) > 1f)
        //{
        //    _brain.EntityMove.Move(_randomDestination - (Vector2)_brain.Render.position);
        //}
    }

    private void NewDestination()
    {
        _random = Random.Range(1f, 3f);
        _brain.Waypoint.Translate(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
        //_brain.Waypoint.position = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        //Debug.Log(_brain.Waypoint.position);
        //_randomDestination = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));

        if (_randomDestination.x < 0)
        {
            _brain.Sprite.flipX = true;
        }
        else if (_brain.Sprite.flipX = true && _randomDestination.x > 0)
        {
            _brain.Sprite.flipX = false;
        }

        ResetCooldown();
    }
}