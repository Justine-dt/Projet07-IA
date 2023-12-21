using NaughtyAttributes;
using Pathfinding;
using UnityEngine;

public abstract class Brain : MonoBehaviour
{
    [SerializeField] protected AIDestinationSetter _destination;
    [SerializeField] protected SpriteRenderer _sprite;
    [SerializeField] protected EntityMove _entityMove;
    [SerializeField] protected EntityShoot _entityShoot;
    [SerializeField] protected EntityStats _entityStats;
    [SerializeField] protected Transform _render;
    [SerializeField] protected bool _isAggressive;
    [SerializeField] protected bool _isFleeing;
    [SerializeField] protected bool _isCoward;
    [SerializeField] protected bool _canAttackAnybody;
    [SerializeField, Tag] protected string[] _additionalTargets;
    [SerializeField] protected bool _isAlwaysChasing;
    [SerializeField] protected bool _dealDamageOnCollide;

    public AIDestinationSetter Destination => _destination;
    public bool DealDamageOnCollide => _dealDamageOnCollide;
    public bool IsFleeing => _isFleeing;
    public bool IsCoward => _isCoward;
    public EntityMove EntityMove => _entityMove;
    public EntityShoot EntityShoot => _entityShoot;
    public EntityStats EntityStats => _entityStats;
    public Transform Render => _render;
    public GameObject Target => _target;
    public SpriteRenderer Sprite => _sprite;
    public State CurrentState => _currentState;

    protected GameObject _target;

    protected State _currentState;
    protected IdleState _idleState = new();
    protected ChaseState _chaseState = new();
    protected DetonateState _detonateState = new();
    protected DeathState _deathState = new();
    protected ProtectiveState _protectiveState = new();

    protected virtual void Awake()
    {
        ChangeState(_idleState);
        Debug.Log("First IdleState");
    }

    protected virtual void Update()
    {
        _currentState?.OnUpdate();
        if (_entityStats.IsDead) ChangeState(_deathState);
    }

    public void ChangeState(State newState)
    {
        if (this is PlayerBrain) return;
        if (_currentState != null && _currentState is DeathState) return;
        if (_currentState != null && _currentState.GetType() == newState.GetType()) return;
        
        _currentState?.OnExit();
        _currentState = newState;
        _currentState.OnEnter(this);
    }

    public virtual void ChangeState(State newState, GameObject target)
    {
        _target = target;
        ChangeState(newState);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsTriggerValid(collision)) return;
        if (!_isAggressive) return;
        Debug.Log("COLLISION");
        ChangeState(_chaseState, collision.gameObject);
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (!IsTriggerValid(collision)) return;
        if (_isAlwaysChasing) return;
        ChangeState(_idleState);
    }

    protected bool IsTriggerValid(Collider2D collision)
    {
        if (collision.gameObject.name == "Brain") return false;
        if (collision.gameObject.layer == 8) return false;

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

    public void ClearDestinationTarget()
    {
        _destination.target = null;
    }
}