using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Rebond : MonoBehaviour
{
    public event Action OnReboundY;
    public event Action OnReboundX;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(collision.collider.tag);

        if (collision.collider.CompareTag("UDWall"))
        {
            OnReboundY?.Invoke();
        }

        if (collision.collider.CompareTag("LRWall"))
        {
            OnReboundX?.Invoke();
        }
    }
}
