using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{
    [SerializeField] int awareness;
    [SerializeField] int horrorRating;
    [SerializeField] int sanityDamage;
    [SerializeField] int combatRating;
    [SerializeField] int staminaDamage;
    [SerializeField] int toughness;

    public MonsterStats()
    {
        awareness = 0;
        horrorRating = 0;
        sanityDamage = 0;
        combatRating = 0;
        staminaDamage = 0;
        toughness = 0;
    }

    public int GetAwareness()
    {
        return awareness;
    }
    public int GetHorrorRating()
    {
        return horrorRating;
    }
    public int GetSanityDamage()
    {
        return sanityDamage;
    }
    public int GetCombatRating()
    {
        return combatRating;
    }
    public int GetStaminaDamage()
    {
        return staminaDamage;
    }
    public int GetToughness()
    {
        return toughness;
    }
}
