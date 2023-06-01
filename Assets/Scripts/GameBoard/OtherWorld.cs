using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherWorld : GameTile
{
    private void Start()
    {
        tileText.text = tileName;
        HideUI();
    }
}
