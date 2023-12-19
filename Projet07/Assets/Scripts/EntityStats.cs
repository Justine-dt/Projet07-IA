using UnityEngine;
using AYellowpaper.SerializedCollections;

public enum Attribute
{
    HP,
    ATTACK,
    SPEED
};

public class EntityStats : MonoBehaviour
{
    public bool IsDead => _stats[Attribute.HP] <= 0;
    [SerializeField] private bool _isPlayer;
    public bool IsPlayer => _isPlayer;
    public SerializedDictionary<Attribute, int> Stats => _stats;
    [SerializeField] private SerializedDictionary<Attribute, int> _stats = new();

    public void TakeDamage(int damage)
    {
        _stats[Attribute.HP] -= damage;
    }

    public void Kill()
    {
        _stats[Attribute.HP] = 0;
    }
}