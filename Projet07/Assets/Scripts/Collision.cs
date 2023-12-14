using System;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public static event Action OnHurt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Brain") return;
        Debug.Log("trigger");
        OnHurt?.Invoke();
    }
}