using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 6f;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private Rigidbody2D _rigidbodyBullet;
    [SerializeField] private float _lifeTime = 0.01f;

    public Vector2 Direction { get => _direction; set => _direction = value; }

    private void Start()
    {
        // Movement
        _rigidbodyBullet.velocity = _direction * _bulletSpeed;
        Destroy(gameObject, _lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Détruire la balle lorsqu'elle entre en collision avec un ennemi
        if (other.gameObject.layer == 7)
        {
            Debug.Log("destroy");
            Destroy(gameObject);
            other.gameObject.GetComponentInParent<EntityStats>().TakeDamage(1);
        }
    }
}