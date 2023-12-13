using System.Drawing;
using System.Numerics;
using UnityEngine;

public class LogoatBrain : MonoBehaviour
{
    [SerializeField] GameObject _logoat;
    UnityEngine.Vector2 direction;

    public BoxCollider2D collider;

    void Start()
    {
        direction.Set(-1.0f, -1.0f);
    }


    void Update()
    {
        //entityMove.Move(direction);
        _logoat.transform.Translate(direction * Time.deltaTime * 3);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {




    }
}
