using UnityEngine;

public class LookTarget : MonoBehaviour
{
    [SerializeField] Transform _target;
    private Vector3 _targetDirection;
    private float _angle;

    void Update()
    {
        _targetDirection = _target.position - transform.position;
        _angle = Mathf.Atan2(_targetDirection.y, _targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
}