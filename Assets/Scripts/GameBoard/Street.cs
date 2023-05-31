using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : GameTile
{
    [SerializeField] bool hasActiveEffect;
    [SerializeField] List<ArkhamEncounter> encounters;
}
