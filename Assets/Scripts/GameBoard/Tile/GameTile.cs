using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class GameTile : MonoBehaviour
{
    public GameTileSO data;

    [Header("UI Information")]
    public GameObject mainCanvas;
    public TextMeshProUGUI distText;


    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        Setup();
        Configure();
    }

    public abstract void Setup();
    public abstract void Configure();

    internal void DisplayMovementIcon(int dist)
    {
        distText.text = $"{dist}";
        mainCanvas.SetActive(!mainCanvas.activeSelf);
    }
}
    /*
    [SerializeField] protected string tileName;
    [SerializeField] protected LocationType locationType;
    [SerializeField] protected List<GameTile> connectedLocations;
    [SerializeField] protected GameTile blackConnection;
    [SerializeField] protected GameTile whiteConnection;
    [SerializeField] protected GameObject tileUI;
    [SerializeField] protected TextMeshProUGUI tileText;

    public GameTile()
    {
        tileName = "Unset";
    }

    private void Start()
    {
        tileText.text = tileName;
        HideUI();
    }

    private void OnMouseEnter()
    {
        //tileUI.SetActive(true);
    }    

    private void OnMouseUpAsButton()
    {
        //isClicked = !isClicked;
    }

    private void OnMouseExit()
    {
        //if(!isClicked) tileUI.SetActive(false);
    }
    public string GetName()
    {
        return tileName;
    }
    public LocationType GetLocationType()
    {
        return locationType;
    }

    public List<GameTile> GetConnectedLocations()
    {
        return connectedLocations;
    }
    public void ShowUI()
    {
        tileUI.SetActive(true);
    }
    public void HideUI()
    {
        tileUI.SetActive(false);
    }

}



public enum LocationType
{
    Downtown,
    Easttown,
    FrenchHill,
    MerchantDistrict,
    MiskatonicUniveristy,
    Northside,
    Rivertown,
    Southside,
    Uptown
}
    */