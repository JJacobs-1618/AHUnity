using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : GameTile
{
    [SerializeField] bool hasActiveEffect;

    private void Start()
    {
        tileText.text = tileName;
        HideUI();
    }
}
