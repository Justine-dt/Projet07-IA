using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField] InputActionReference _moveAction;

    Coroutine _move;

    void Start()
    {
        _moveAction.action.started += StartMove;
        _moveAction.action.canceled += CancelMove;
    }

    private void CancelMove(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void StartMove(InputAction.CallbackContext obj)
    {
        //
    }
}