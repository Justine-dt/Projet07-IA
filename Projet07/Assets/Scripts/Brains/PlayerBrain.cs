using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBrain : Brain
{
    [SerializeField] InputActionReference _moveAction;
    [SerializeField] InputActionReference _shootAction;
    [SerializeField] InputActionReference _aim;
    [SerializeField] EntityShoot _entityShoot;

    Coroutine _move;
    Coroutine _shootRoutine;

    protected override void Awake()
    {
        // Set up event handlers for movement and shooting actions
        _moveAction.action.started += StartMove;
        _moveAction.action.canceled += CancelMove;

        _shootAction.action.started += StartShoot;
        _shootAction.action.canceled += StopShoot;
    }

    private void OnDestroy()
    {
        // Unsubscribe from event handlers to avoid memory leaks
        _moveAction.action.started -= StartMove;
        _moveAction.action.canceled -= CancelMove;

        _shootAction.action.started -= StartShoot;
        _shootAction.action.canceled -= StopShoot;
    }

    private void StartMove(InputAction.CallbackContext obj)
    {
        // Start the coroutine for continuous movement
        _move = StartCoroutine(Move(obj));
        //_move = StartCoroutine(Move(obj));
    }

    private void CancelMove(InputAction.CallbackContext obj)
    {
        // Stop the movement coroutine when the move action is canceled (button released)
        StopCoroutine(_move);
    }

    private void StartShoot(InputAction.CallbackContext obj)
    {
        // Start the shooting coroutine when the shoot action is initiated
        _shootRoutine = StartCoroutine(Shoot());
    }

    private void StopShoot(InputAction.CallbackContext obj)
    {
        // Stop the shooting coroutine when the shoot action is canceled (button released)
        if (_shootRoutine != null)
        {
            StopCoroutine(_shootRoutine);
            _shootRoutine = null;
        }
    }
    private IEnumerator Shoot()
    {
        // Start the shooting coroutine in the EntityShoot component
        _entityShoot.StartShoot();

        // Wait until the shoot action is canceled (button released)
        yield return new WaitUntil(() => _shootAction.action.phase == InputActionPhase.Canceled);

        // Stop the shooting coroutine in the EntityShoot component
        _entityShoot.StopShoot();
    }

    private IEnumerator Move(InputAction.CallbackContext obj)
    {
        while (true)
        {
            // Continuously update the player's position based on the input direction
            //_entityMove.Move(dir);
            _entityMove.Move(obj.ReadValue<Vector2>());
            yield return null;
        }
    }
}