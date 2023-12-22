using UnityEngine;

public class BossKill : MonoBehaviour
{
    [SerializeField] private EntityStats _entityStats;

    private void Update()
    {
        if (_entityStats.IsDead) Destroy(gameObject);
    }
}