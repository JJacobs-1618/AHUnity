using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncientOneStats : MonoBehaviour
{
    [SerializeField] int maxDoom;
    [SerializeField] int currentDoom;
    [SerializeField] int combatRating;
    [SerializeField] string worshippersText;
    [SerializeField] List<Monster> worshippers;
    [SerializeField] string powerName;
    [SerializeField] string powerDescription;
    [SerializeField] string startOfBattle;
    [SerializeField] string attackDescription;
}
