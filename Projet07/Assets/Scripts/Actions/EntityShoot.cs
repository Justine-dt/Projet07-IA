using System;
using System.Collections;
using System.Collections.Generic;
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

    Coroutine _shootRoutine;
    public void StartShoot()
    {
        _shootRoutine = StartCoroutine(ShootRoutine());
        IEnumerator ShootRoutine()
        {
            while (true)
            {
                // Create a bullet
                GameObject bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation, _root);
                BulletScript bulletScript = bullet.GetComponent<BulletScript>();
                // Vérifie si le script de la balle est présent
                if (bulletScript != null)
                {
                    // Définir la direction de la balle 
                    bulletScript.SetDirection(transform.up);
                }

                // Attendre avant de tirer à nouveau
                yield return new WaitForSeconds(1f);
            }
        }
    }

    public void StopShoot()
    {
        StopCoroutine(_shootRoutine);
        _shootRoutine = null;
    }
    IEnumerator Cooldown(float duration)
    {
        float startTime = Time.time;

        while (Time.time < startTime + duration)
        {
            var current = Time.time;

            //current - startTime

            yield return null;
        }
    }
}
