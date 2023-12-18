using System;
using System.Collections.Generic;
using UnityEngine;

public enum Attribute
{
    HP,
    ATTACK,
    SPEED
};

public class EntityStats : MonoBehaviour
{
    public bool IsDead => _stats[Attribute.HP] <= 0;
    public Dictionary<Attribute, int> Stats => _stats;
    private Dictionary<Attribute, int> _stats;

    private void Awake()
    {
        _stats = new();

        foreach (Attribute stat in Enum.GetValues(typeof(Attribute)))
        {
            _stats[stat] = 4;
        }
    }

    public void TakeDamage(int damage)
    {
        _stats[Attribute.HP] -= damage;
    }

    public void Kill()
    {
        _stats[Attribute.HP] = 0;
    }
}