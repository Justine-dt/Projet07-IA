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
    public static event Action<SpriteRenderer, GameObject> OnHurt;

    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private bool _isPlayer;
    [SerializeField] private SerializedDictionary<Attribute, int> _stats = new();

    public bool IsDead => _stats[Attribute.HP] <= 0;
    public bool IsPlayer => _isPlayer;
    public SerializedDictionary<Attribute, int> Stats => _stats;

    public void TakeDamage(int damage, GameObject source)
    {
        _stats[Attribute.HP] -= damage;
        OnHurt?.Invoke(_sprite, source);
    }

    public void Kill()
    {
        _stats[Attribute.HP] = 0;
    }

    public void BoostStat(Attribute attr)
    {
        _stats[attr] += 5;
    }
}