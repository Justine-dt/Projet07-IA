using System;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public static event Action<Transform> OnCollide;
    public static event Action<Transform> OnStopCollide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.name == "Brain") return;
        //Debug.Log("trigger");
        OnCollide?.Invoke(collision.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnStopCollide?.Invoke(collision.transform);
    }
}