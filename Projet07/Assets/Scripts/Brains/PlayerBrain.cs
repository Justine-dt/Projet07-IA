using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBrain : Brain
{
    [SerializeField] InputActionReference _moveAction;
    [SerializeField] InputActionReference _shootAction;
    [SerializeField] InputActionReference _aim;

    [SerializeField] private float _shootRate;
    public float ShootRate => 1 / _shootRate;

    private bool _canShoot = true;

    Coroutine _move;
    Coroutine _shoot;

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
    }

    private void CancelMove(InputAction.CallbackContext obj)
    {
        // Stop the movement coroutine when the move action is canceled (button released)
        StopCoroutine(_move);
        // Reset direction
        _entityMove._direction = Vector2.zero;
        // Send reset to the function
        _entityMove.UpdateMove();
    }

    private void StartShoot(InputAction.CallbackContext obj)
    {
        // Start the shooting coroutine when the shoot action is initiated
        _shoot = StartCoroutine(Shoot(obj));
    }

    private void StopShoot(InputAction.CallbackContext obj)
    {
        StopCoroutine(_shoot);
        // Reset mousePosition
        _entityShoot._mousePosition = Vector2.zero;
        // Send reset to the function
        _entityShoot.UpdateShoot(ShootRate);
    }
    private IEnumerator Shoot(InputAction.CallbackContext obj)
    {
        _canShoot = false;
        // Start the shooting coroutine in the EntityShoot component
        _entityShoot._mousePosition = (obj.ReadValue<Vector2>());
        _entityShoot.UpdateShoot(ShootRate);
        yield return null;
        // Stop the shooting coroutine in the EntityShoot component
        _entityShoot.StopShoot();
    }

    private IEnumerator Move(InputAction.CallbackContext obj)
    {
        while (true)
        {
            // Continuously update the player's position based on the input direction
            _entityMove._direction = (obj.ReadValue<Vector2>());
            _entityMove.UpdateMove();
            yield return null;
        }
    }
}