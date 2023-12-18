using System;
using System.Collections.Generic;
using UnityEngine;

public enum Stats
{
    HP,
    ATTACK,
    SPEED
};

public class EntityStats : MonoBehaviour
{
    public Dictionary<Stats, int> Stats => _stats;
    private Dictionary<Stats, int> _stats;

    private void Awake()
    {
        _stats = new();
        foreach (Stats stat in Enum.GetValues(typeof(Stats)))
        {
            _stats[stat] = 4;
        }
    }
}
