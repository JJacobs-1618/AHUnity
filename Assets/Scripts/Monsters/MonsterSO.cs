using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSO", menuName = "Arkham/Monster Data")]
public class MonsterSO : ScriptableObject
{
    public string MonsterName;
    [TextArea(5, 10)]
    public string FlavorText;
    public int Awareness;
    public DimensionSymbolType Symbol;
    public MovementType movementType;
    [Header("Monster Abilities")]
    public bool Ambush;
    public bool Endless;
    public bool PhysicalResistance;
    public bool MagicalResistance;
    public bool PhysicalImmunity;
    public bool MagicalImmunity;
    public bool Nightmarish;
    public int NightmarishDamage;
    public bool Overwhelming;
    public int OverwhelmingDamage;
    public bool Undead;
    [Header("Combat Stats")]
    public int HorrorRating;
    public int HorrorDamage;
    public int Toughness;
    public int CombatDamage;
    public int CombatRating;
}

public enum MovementType
{
    Normal,
    Stationary,
    Fast,
    Unique,
    Flying,
    Stalker, // Later expansions
    Aquatic, // Later expansions
    MovementType
}