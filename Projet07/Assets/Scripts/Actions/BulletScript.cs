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
        GameObject shooter = GetComponentInParent<Collision>().gameObject;
        bool isPlayer = shooter.layer == 9;
        int targetLayer = other.gameObject.layer;

        if ((isPlayer && targetLayer == 7) || (!isPlayer && other.gameObject.CompareTag("Player")))
        {
            Attack(other, shooter);
        }
    }

    private void Attack(Collider2D target, GameObject shooter)
    {
        target.gameObject.GetComponentInParent<EntityStats>().TakeDamage(1, shooter);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 0) return;
        Destroy(gameObject);
    }
}