using UnityEngine;

public class ShootState : State
{
    [SerializeField] private float _shootRate;
    public float ShootPerSec => 1 / _shootRate;

    public override void OnEnter(Brain brain)
    {
        base.OnEnter(brain);
        _shootRate = 3f;
        _brain.EntityShoot.StartShoot(ShootPerSec);
    }

    public override void OnExit()
    {
        base.OnExit();
        _brain.EntityShoot.StopShoot();
    }
}