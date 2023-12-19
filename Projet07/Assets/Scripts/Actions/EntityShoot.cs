using System;
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
    private Vector2 _mousePosition;
    private Vector2 _targetDirection;
    private float _shootRate;

    Coroutine _shootRoutine;

    private void Start()
    {
        _root = new GameObject("AllBullets").GetComponent<Transform>();
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

    IEnumerator Shoot()
    {
        while (true)
        {
            // GetTarget ce sur quoi tu souhaite tirer joueur ou cursor = aim
            // TODO: manage if it's a "playerShoot" or a "entityShoot"
            _mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            _targetDirection = (_mousePosition - (Vector2)transform.position);
            float angle = Mathf.Atan2(_targetDirection.y, _targetDirection.x);
            transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
            // Create a bullet
            // TODO: Instantiate should be done by the GameManager
            GameObject _bullet  = Instantiate(_bulletPrefab, transform.position, transform.rotation, _root);
            BulletScript bulletScript = _bullet.GetComponent<BulletScript>();
            bulletScript.Direction = _targetDirection;
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
