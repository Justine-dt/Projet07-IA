using UnityEngine;

public class IdleState : State
{
    private float _startTime;
    private float _random;
    private Vector2 _randomDestination;

    public override void OnEnter(Brain brain)
    {
        base.OnEnter(brain);

        _startTime = Time.time;
        _random = -1;
    }

    public override void OnUpdate()
    {
        if (_random == -1 || Time.time >= _startTime + _random) NewDestination();

        if (Vector2.Distance(_brain.Render.position, _randomDestination) > 1f)
        {
            _brain.EntityMove._direction = _randomDestination - (Vector2)_brain.Render.position;
        }
    }

    private void NewDestination()
    {
        _random = Random.Range(1f, 3f);
        _randomDestination = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));

        if (_randomDestination.x < 0)
        {
            _brain.Sprite.flipX = true;
        }
        else if (_brain.Sprite.flipX = true && _randomDestination.x > 0)
        {
            _brain.Sprite.flipX = false;
        }

        _startTime = Time.time;
    }
}