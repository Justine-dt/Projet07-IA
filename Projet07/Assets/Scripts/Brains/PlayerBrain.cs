using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBrain : Brain
{
    [SerializeField] InputActionReference _moveAction;
    [SerializeField] InputActionReference _shootAction;
    [SerializeField] EntityShoot _entityShoot;

    Coroutine _move;

    void Start()
    {
        _moveAction.action.started += StartMove;
        _moveAction.action.canceled += CancelMove;

        /*_shootAction.action.started += StartShoot;
        _shootAction.action.canceled += CancelShoot;*/
    }

    private void StartMove(InputAction.CallbackContext obj)
    {
        _move = StartCoroutine(Move(obj));
    }

    private void CancelMove(InputAction.CallbackContext obj)
    {
        StopCoroutine(_move);
    }

    /*private void StartShoot(InputAction.CallbackContext obj)
    {
        _shootRoutine = StartCoroutine(StartShoot());
    }

    private void CancelShoot(InputAction.CallbackContext obj)
    {
        _shootRoutine = StartCoroutine(StopShoot());
    }*/


    private IEnumerator Move(InputAction.CallbackContext obj)
    {
        while (true)
        {
            _entityMove.Move(obj.ReadValue<Vector2>());
            yield return null;
        }
    }
}