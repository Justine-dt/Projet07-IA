using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public static event Action OnHurt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        OnHurt?.Invoke();
    }
}