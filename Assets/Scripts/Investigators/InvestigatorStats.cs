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
    [SerializeField] int speed;
    [SerializeField] int sneak;
    [SerializeField] int fight;
    [SerializeField] int will;
    [SerializeField] int lore;
    [SerializeField] int luck;

    public void updateCurrentStamina(int delta)
    {
        currentStamina += delta;
    }
    public void updateCurrentSanity(int delta)
    {
        currentSanity += delta;
    }

    public void updateSpeed(int delta)
    {
        speed += delta;
    }
    public void updateSneak(int delta)
    {
        sneak += delta;
    }
    public void updateFight(int delta)
    {
        fight += delta;
    }
    public void updateWill(int delta)
    {
        will += delta;
    }
    public void updateLore(int delta)
    {
        lore += delta;
    }
    public void updateLuck(int delta)
    {
        luck += delta;
    }
}

