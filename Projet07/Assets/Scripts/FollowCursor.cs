using UnityEngine;
using UnityEngine.InputSystem;

public class FollowCursor : MonoBehaviour
{
    [SerializeField] InputActionReference _mouseInput;

    void Update()
    {
        var pos = Camera.main.ScreenToWorldPoint(_mouseInput.action.ReadValue<Vector2>());
        pos.z = 0;
        transform.position = pos;
    }
}