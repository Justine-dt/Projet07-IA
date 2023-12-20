using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EntityMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] GameObject _player;
    [SerializeField] EntityStats _entityStats;
    public Vector2 _direction;

    public void UpdateMove()
    {
        float speed = _entityStats.Stats[Attribute.SPEED];
        // Calculate velocity
        Vector3 velocity = _direction * speed;
        // Apply velocity to Rigidbody
        _rigidbody.velocity = velocity;
    }
}