using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BatBrain : Brain
{

    protected override void Update()
    {
          base.Update();
    }

    protected override void ChangeState(State newState, GameObject target)
    {
        base.ChangeState(newState, target);

        //if (newState is ChaseState)
        //{
        //    Bat[] bats = FindObjectOfType<Bat>
        //}

        //foreach (Bat)
    }
}