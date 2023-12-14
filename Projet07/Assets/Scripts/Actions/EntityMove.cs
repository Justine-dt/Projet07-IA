using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMove : MonoBehaviour
{

    [SerializeField] GameObject _player;

    public void Move(Vector2 direction)
    {
        _player.transform.Translate(direction * Time.deltaTime * 1);
    }
}