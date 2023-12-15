using UnityEngine;

public class EntityMove : MonoBehaviour
{
    [SerializeField] GameObject _player;

    public void Move(Vector2 direction)
    {
        //Debug.Log(direction.x + ", " + direction.y);
        _player.transform.Translate(direction * Time.deltaTime * 4);
    }
}