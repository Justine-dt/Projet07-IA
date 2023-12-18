using UnityEngine;

public class EntityMove : MonoBehaviour
{
    private PlayerControls _controls;

    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] GameObject _player;
    [SerializeField] EntityStats _entityStats;

    public void Move(Vector2 direction)
    {
        //Debug.Log(direction.x + ", " + direction.y);
        //_player.transform.Translate(direction * Time.deltaTime * _entityStats.Stats[Attribute.SPEED]);

        
        
        float speed = _entityStats.Stats[Attribute.SPEED]; // Assure-toi d'avoir la vitesse correcte

        // Calcule la vélocité
        Vector3 velocity = direction * speed;

        // Applique la vélocité au Rigidbody
        _rigidbody.velocity = velocity;

    }
}