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
    [SerializeField] public int speed;
    [SerializeField] public int sneak;
    [SerializeField] public int fight;
    [SerializeField] public int will;
    [SerializeField] public int lore;
    [SerializeField] public int luck;

    public int GetMaxSanity() { return maxSanity; }
    public int GetCurrentSanity() { return currentSanity; }
    public void updateCurrentSanity(int delta) { currentSanity += delta; }
    public int GetMaxStamina() { return maxStamina; }
    public int GetCurrentStamina() { return currentStamina; }
    public void updateCurrentStamina(int delta) { currentStamina += delta; }
    public int GetFocus() {  return focus; }
}

