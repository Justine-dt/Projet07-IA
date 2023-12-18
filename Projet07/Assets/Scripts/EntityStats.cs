using UnityEngine;
using AYellowpaper.SerializedCollections;
using System;

public enum Attribute
{
    HP,
    ATTACK,
    SPEED,
    ATKSPEED
};

public class EntityStats : MonoBehaviour
{
    public static event Action OnHurt;
    public bool IsDead => _stats[Attribute.HP] <= 0;
    public SerializedDictionary<Attribute, int> Stats => _stats;
    [SerializeField] private SerializedDictionary<Attribute, int> _stats = new();

    public void TakeDamage(int damage)
    {
        _stats[Attribute.HP] -= damage;
        OnHurt?.Invoke();
    }

    public void Kill()
    {
        _stats[Attribute.HP] = 0;
    }
}