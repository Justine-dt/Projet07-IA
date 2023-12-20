using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class EntityShoot : MonoBehaviour
{
    [SerializeField] private Transform _root; // Must be define as "NONE"
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private EntityStats _entity;
    [SerializeField] private Brain _brain;
    [SerializeField] private GameObject _render;
    private Vector2 _targetPosition;
    private Vector2 _targetDirection;
    private float _shootRate;

    Coroutine _shootRoutine;

    private void Start()
    {
        _root = new GameObject("AllBullets").GetComponent<Transform>();
        _root.parent = _render.transform;
    }

    public void StartShoot(float shootRate)
    {
        _shootRate = shootRate;
        _shootRoutine = StartCoroutine(Shoot());
    }

    public void StopShoot()
    {
        StopCoroutine(_shootRoutine);
    }

    private void GetTarget()
    {
        if(_entity.IsPlayer)
        {
            // If entity is a player target will be the player's mouse
            _targetPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }
        else
        {
            // If entity is an ennemy target will be the player
            _targetPosition = _brain.Target.transform.position;
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            // Manage if it's a "playerShoot" or a "ennemyShoot" -> asign your shoot target
            GetTarget();
            // Normalized will prevent bullets from accelerating
            _targetDirection = (_targetPosition - (Vector2)transform.position).normalized;
            float angle = Mathf.Atan2(_targetDirection.y, _targetDirection.x);
            transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
            // Create a bullet
            // TODO: Instantiate should be done by the GameManager
            GameObject _bullet  = Instantiate(_bulletPrefab, transform.position, transform.rotation, _root);
            BulletScript bulletScript = _bullet.GetComponent<BulletScript>();
            bulletScript.Direction = _targetDirection;
            if (_entity.IsPlayer)
            {
                // Prevents collision between player's bullets and himself
                _bullet.layer = LayerMask.NameToLayer("PlayerProjectile");
            }
            else
            {
                // Prevents enemy bullets from colliding with itself
                _bullet.layer = LayerMask.NameToLayer("EnemyProjectile");
            }     
            // Wait before shooting again
            yield return new WaitForSeconds(_shootRate);
        }
    }
}
