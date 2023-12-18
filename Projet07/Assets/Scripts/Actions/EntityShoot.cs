using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityShoot : MonoBehaviour
{
    /* utiliser la date actuelle ou fonction asyncrone
         -> coroutine 2 instruction pour attendre puis reprend son fil
            1) cr�e une bullet 
            2) d�clanche une attente
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
                // V�rifie si le script de la balle est pr�sent
                if (bulletScript != null)
                {
                    // D�finir la direction de la balle 
                    bulletScript.SetDirection(transform.up);
                }

                // Attendre avant de tirer � nouveau
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
