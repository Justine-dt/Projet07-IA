using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField] InputActionReference _moveAction;
    [SerializeField] EntityMove _entityMove;

    Coroutine _move;

    void Start()
    {
        _moveAction.action.started += StartMove;
        _moveAction.action.canceled += CancelMove;
    }

    private void CancelMove(InputAction.CallbackContext obj)
    {
        StopCoroutine(_move);
    }

    private void StartMove(InputAction.CallbackContext obj)
    {
        _move = StartCoroutine(Move(obj.ReadValue<Vector2>()));
    }

    private IEnumerator Move(Vector2 dir)
    {
        while (true)
        {
            _entityMove.Move(dir);
            yield return null;
        }
    }
}