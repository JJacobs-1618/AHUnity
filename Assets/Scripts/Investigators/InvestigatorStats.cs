using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigatorStats : MonoBehaviour
{
    [SerializeField] int maxSanity;
    [SerializeField] int currentSanity;
    [SerializeField] int maxStamina;
    [SerializeField] int currentStamina;
    [SerializeField] int focus;
    [SerializeField] public int speedStart;
    [SerializeField] public int sneakStart;
    [SerializeField] public int fightStart;
    [SerializeField] public int willStart;
    [SerializeField] public int loreStart;
    [SerializeField] public int luckStart;
    [SerializeField] int currSpeed;
    [SerializeField] int currSneak;
    [SerializeField] int currFight;
    [SerializeField] int currWill;
    [SerializeField] int currLore;
    [SerializeField] int currLuck;

    public int GetMaxSanity() { return maxSanity; }
    public int GetCurrentSanity() { return currentSanity; }
    public void updateCurrentSanity(int delta) { currentSanity += delta; }
    public int GetMaxStamina() { return maxStamina; }
    public int GetCurrentStamina() { return currentStamina; }
    public void updateCurrentStamina(int delta) { currentStamina += delta; }
    public int GetFocus() {  return focus; }
    public int GetSpeed() { return currSpeed; }
    public void SetSpeed(int newSpeed) { currSpeed = newSpeed; }
    public int GetSneak() { return currSneak; }
    public void SetSneak(int newSneak) { currSneak = newSneak; }
    public int GetFight() { return currFight; }
    public void SetFight(int newFight) { currFight = newFight; }
    public int GetWill() { return currWill; }
    public void SetWill(int newWill) { currWill = newWill; }
    public int GetLore() { return currLore; }
    public void SetLore(int newLore) { currLore = newLore; }
    public int GetLuck() { return currLuck; }
    public void SetLuck(int newLuck) { currLuck = newLuck; }

}

