using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FortTresseBrain : Brain
{
    //Idle state = static
    //Shoot state
    //Death state

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsTriggerValid(collision)) return;
        ChangeState(new ShootState(), collision.gameObject);
    }
}
