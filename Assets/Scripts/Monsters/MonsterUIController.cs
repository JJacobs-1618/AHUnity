using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterUIController : MonoBehaviour
{
    public Monster _monster;

    public GameObject detailsPane;

    public TextMeshProUGUI _monsterName;
    public TextMeshProUGUI _flavorText;
    public TextMeshProUGUI _horrorRating;
    public TextMeshProUGUI _horrorDamage;
    public TextMeshProUGUI _toughness;
    public TextMeshProUGUI _combatDamage;
    public TextMeshProUGUI _combatRating;

    public void Init(MonsterSO data)
    {
        _monsterName.text = $"{data.MonsterName}";
        _flavorText.text = $"{data.FlavorText}";
        _horrorRating.text = $"{data.HorrorRating}";
        _horrorDamage.text = $"{data.HorrorDamage}";
        _toughness.text = $"{data.Toughness}";
        _combatDamage.text = $"{data.CombatDamage}";
        _combatRating.text = $"{data.CombatRating}";

        detailsPane.SetActive(false);
    }


    private void OnMouseOver()
    {
        detailsPane.SetActive(true);
    }

    private void OnMouseExit()
    {
        detailsPane.SetActive(false);
    }
}
