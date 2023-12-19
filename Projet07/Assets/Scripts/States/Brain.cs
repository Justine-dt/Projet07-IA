using NaughtyAttributes;
using UnityEngine;

public abstract class Brain : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer _sprite;
    [SerializeField] protected EntityMove _entityMove;
    [SerializeField] protected EntityShoot _entityShoot;
    [SerializeField] protected EntityStats _entityStats;
    [SerializeField] protected Transform _render;
    [SerializeField] protected bool _isAggressive;
    [SerializeField] protected bool _canAttackAnybody;
    [SerializeField, Tag] protected string[] _additionalTargets;
    [SerializeField] protected bool _isAlwaysChasing;

    public EntityMove EntityMove => _entityMove;
    public EntityShoot EntityShoot => _entityShoot;
    public EntityStats EntityStats => _entityStats;
    public Transform Render => _render;
    public GameObject Target => _target;
    public SpriteRenderer Sprite => _sprite;

    protected GameObject _target;

    protected State _currentState;
    protected IdleState _idleState = new();
    protected ChaseState _chaseState = new();
    protected DetonateState _detonateState = new();
    protected DeathState _deathState = new();

    protected virtual void Awake()
    {
        ChangeState(_idleState);
    }

    protected virtual void Update()
    {
        _currentState?.OnUpdate();
        if (_entityStats.IsDead) ChangeState(_deathState);
    }

    protected void ChangeState(State newState)
    {
        if (_currentState != null && _currentState is DeathState) return;
        _currentState?.OnExit();
        _currentState = newState;
        _currentState.OnEnter(this);
    }

    protected virtual void ChangeState(State newState, GameObject target)
    {
        _target = target;
        ChangeState(newState);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isAggressive || !IsTriggerValid(collision)) return;
        ChangeState(_chaseState, collision.gameObject);
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (!_isAlwaysChasing && !IsTriggerValid(collision)) return;
        ChangeState(_idleState);
    }

    protected bool IsTriggerValid(Collider2D collision)
    {
        if (collision.gameObject.name == "Brain") return false;

        string tag = collision.gameObject.tag;
        bool targetIsValid = tag == "Player" || _canAttackAnybody;

        foreach (var target in _additionalTargets)
        {
            if (target == tag) targetIsValid = true;
        }

        return targetIsValid;
    }

    public EntityStats GetTargetStats()
    {
        return _target.GetComponentInParent<EntityStats>();
    }
}