using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBrain : Brain
{
    [SerializeField] InputActionReference _moveAction;
    [SerializeField] InputActionReference _shootAction;
    [SerializeField] InputActionReference _aim;

    [SerializeField] private float _shootRate;
    public float ShootPerSec => 1 / _shootRate;

    private bool _isShooting = true;

    Coroutine _move;

    protected override void Awake()
    {
        // Set up event handlers for movement and shooting actions
        _moveAction.action.started += StartMove;
        _moveAction.action.canceled += CancelMove;

        _shootAction.action.performed += StartShoot;
        _shootAction.action.canceled += CancelShoot;
    }

    private void OnDestroy()
    {
        // Unsubscribe from event handlers to avoid memory leaks
        _moveAction.action.started -= StartMove;
        _moveAction.action.canceled -= CancelMove;

        _shootAction.action.performed -= StartShoot;
        _shootAction.action.canceled -= CancelShoot;
    }

    protected override void Update()
    {
        base.Update();

        if (_currentState != null && _currentState is DeathState)
        {
            CancelMove();
            _moveAction.action.started -= StartMove;
            _moveAction.action.canceled -= CancelMove;

            _shootAction.action.performed -= StartShoot;
            _shootAction.action.canceled -= CancelShoot;
        }
    }

    private void StartMove(InputAction.CallbackContext obj)
    {
        // Start the coroutine for continuous movement
        _move = StartCoroutine(Move(obj));
    }

    private void CancelMove(InputAction.CallbackContext obj) => CancelMove();

    private void CancelMove()
    {
        // Stop the movement coroutine when the move action is canceled (button released)
        StopCoroutine(_move);
        // Reset direction
        _entityMove.Direction = Vector2.zero;
        // Send reset to the function
        _entityMove.UpdateMove();
    }

    private void StartShoot(InputAction.CallbackContext obj)
    {
        // recupere l'état de ta touche ici le clique de la souris
        _isShooting = obj.ReadValue<float>() > 0;
        _entityShoot.StartShoot(ShootPerSec);
    }

    private void CancelShoot(InputAction.CallbackContext obj)
    {
        _isShooting = false;
        _entityShoot.StopShoot();
    }

    private IEnumerator Move(InputAction.CallbackContext obj)
    {
        while (true)
        {
            // Continuously update the player's position based on the input direction
            _entityMove.Direction = (obj.ReadValue<Vector2>());
            _entityMove.UpdateMove();
            yield return null;
        }
    }
}