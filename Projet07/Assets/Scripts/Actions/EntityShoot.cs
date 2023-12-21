using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class EntityShoot : MonoBehaviour
{
    /* utiliser la date actuelle ou fonction asyncrone
         -> coroutine 2 instruction pour attendre puis reprend son fil
            1) crée une bullet 
            2) déclanche une attente
    */
    [SerializeField] private Transform _root;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private EntityStats _entity;
    [SerializeField] private Brain _brain;
    [SerializeField] private GameObject _render;
    private Vector2 _targetPosition;
    public Vector2 TargetPosition => _targetPosition;
    private Vector2 _targetDirection;
    public Vector2 TargetDirection => _targetDirection;

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
            // player donc aim la souris 
            _targetPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }
        else
        {
            // ennemy donc aim le player 
            _targetPosition = _brain.Target.transform.position;
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            // GetTarget qui tu est et ce sur quoi tu souhaite tirer joueur ou cursor = aim
            // TODO: manage if it's a "playerShoot" or a "entityShoot"
            GetTarget();
            // pour pas tirer comme dans valo
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
                // empeche collision entre les balles du joueur et lui meme
                _bullet.layer = LayerMask.NameToLayer("PlayerProjectile");
            }
            else
            {
                // empeche collision entre les balles de l'ennemi et lui meme
                _bullet.layer = LayerMask.NameToLayer("EnemyProjectile");
            }     
            // Attendre avant de tirer à nouveau
            yield return new WaitForSeconds(_shootRate);
        }
    }
    /*IEnumerator Cooldown(float duration)
    {
        float startTime = Time.time;

        while (Time.time < startTime + duration)
        {
            var current = Time.time;

            //current - startTime

            yield return null;
        }
    }*/
}
