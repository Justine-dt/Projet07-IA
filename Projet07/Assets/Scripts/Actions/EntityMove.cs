using UnityEngine;

public class EntityMove : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] private int _speed = 4;

    public void Move(Vector2 direction)
    {
        //Debug.Log(direction.x + ", " + direction.y);
        _player.transform.Translate(direction * Time.deltaTime * _speed);
    }
}