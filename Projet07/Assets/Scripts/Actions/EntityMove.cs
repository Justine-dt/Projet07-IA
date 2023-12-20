using UnityEngine;

public class EntityMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] GameObject _player;
    [SerializeField] EntityStats _entityStats;
    public Vector2 _direction;

    /*public void Move(Vector2 _direction)
    {
        //Debug.Log(direction.x + ", " + direction.y);
        //_player.transform.Translate(direction * Time.deltaTime * _entityStats.Stats[Attribute.SPEED]);
    }*/

    public void UpdateMove()
    {
        float speed = _entityStats.Stats[Attribute.SPEED];
        // Calcule la v�locit�
        Vector3 velocity = _direction * speed;
        // Applique la v�locit� au Rigidbody
        _rigidbody.velocity = velocity;
    }
}