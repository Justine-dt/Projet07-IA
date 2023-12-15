using UnityEngine;

public class LookTarget : MonoBehaviour
{
    [SerializeField] Transform _target;
    //Bullet -> direction up

    void Start()
    {
        
    }

    void Update()
    {
        var dir = _target.position - transform.position;
        var deg = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, deg);
    }
}