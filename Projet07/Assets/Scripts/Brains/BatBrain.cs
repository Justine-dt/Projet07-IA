using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BatBrain : Brain
{
    [SerializeField] float idleBatSpeed = 1.0f;
    [SerializeField] float chaseBatSpeed = 5.0f;

    protected override void Update()
    {
          base.Update();
    }

    protected override void ChangeState(State newState, GameObject target)
    {
        base.ChangeState(newState, target);

        if (newState is ChaseState)
        {
            //
        }
    }
}