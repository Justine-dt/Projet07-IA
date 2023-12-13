using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TEST : MonoBehaviour
{
    [SerializeField] GameObject _logoat;
    [SerializeField] Rigidbody2D rgdBody;
    Vector2 direction;

    public CircleCollider2D collider;


    void Start()
    {
        direction.Set(-1.0f, -1.0f);
    }


    void Update()
    {
        //entityMove.Move(direction);
        //_logoat.transform.Translate(direction * Time.deltaTime * 3);
        rgdBody.MovePosition(rgdBody.position + direction * Time.fixedDeltaTime * 3);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("cercle");

        direction.y *= -1;

    }
}
