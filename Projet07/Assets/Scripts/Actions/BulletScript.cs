using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 5f;

    Vector3 _direction;

    public void SetDirection(Vector3 direction)
    {
        // Normalize la direction pour s'assurer que la vitesse est constante
        _direction = direction.normalized;
    }

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        // D�place la balle dans la direction sp�cifi�e � une vitesse constante
        transform.Translate(_direction * _bulletSpeed * Time.deltaTime, Space.World);
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        // G�re la logique de collision ici si n�cessaire
        // Par exemple, d�truire la balle lorsqu'elle entre en collision avec un ennemi
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }*/
}

