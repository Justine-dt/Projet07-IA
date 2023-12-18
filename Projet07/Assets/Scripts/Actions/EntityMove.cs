using UnityEngine;

public class EntityMove : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] EntityStats _entityStats;

    public void Move(Vector2 direction)
    {
        //Debug.Log(direction.x + ", " + direction.y);
        _player.transform.Translate(direction * Time.deltaTime * _entityStats.Stats[Stats.SPEED]);
    }
}