using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public CardSO data;
    CardUIController infoController;

    private void Start()
    {
        this.gameObject.TryGetComponent<CardUIController>(out infoController);
        

        infoController.Init(data);
        infoController.enabled = true;
    }
}
