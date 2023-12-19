using System;
using System.Collections;
using UnityEngine;

public class EntityShoot : MonoBehaviour
{
    /* utiliser la date actuelle ou fonction asyncrone
         -> coroutine 2 instruction pour attendre puis reprend son fil
            1) crée une bullet 
            2) déclanche une attente
    */
    [SerializeField] Transform _root;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _bulletDirection;
    public Vector2 _mousePosition;
    public float _movementVelocity = 3f;
    public Vector2 _direction;
    public Vector2 _movement;
    //private float duration = 2.0f;
    private float _shootRate;

    Coroutine _shootRoutine;
    public void UpdateShoot(float shootRate)
    {
        _shootRate = shootRate;
        _direction = _movement;
        _shootRoutine = StartCoroutine(Shoot());
    }

    public void StopShoot()
    {
        StopCoroutine(_shootRoutine);
        _shootRoutine = null;
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            // TODO: manage if it's a "playerShoot" or a "entityShoot"
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);
            // Create a bullet
            // TODO: Instantiate should be done by the GameManager
            Instantiate(_bulletPrefab, _bulletDirection.position, _bulletDirection.rotation, _root);
            BulletScript bulletScript = _bulletPrefab.GetComponent<BulletScript>();
            // Vérifie si le script de la balle est présent
            /*if (bulletScript != null)
            {
                // Définir la direction de la balle 
                bulletScript.SetDirection(transform.up);
            }*/

            // Attendre avant de tirer à nouveau
            yield return new WaitForSeconds(1f);
        }
    }

    private void Update()
    {
        // Rotation 
        Vector2 mouseScreenPosition = _mousePosition;
        Vector3 mouseWorlPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 targetDirection = mouseWorlPosition - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // Movement
        Vector3 movement = _movement * _movementVelocity;
        transform.position += movement * Time.deltaTime;
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
