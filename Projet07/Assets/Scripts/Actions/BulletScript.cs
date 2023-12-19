using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 5f;
    [SerializeField] private Vector3 _direction;

    IEnumerable DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private void MoveBullet()
    {
        // Déplace la balle dans la direction spécifiée à une vitesse constante
        transform.Translate(Vector3.up * _bulletSpeed * Time.deltaTime, Space.World);
    }

    void Update()
    {
        MoveBullet();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Gère la logique de collision ici si nécessaire
        // Par exemple, détruire la balle lorsqu'elle entre en collision avec un ennemi
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}

