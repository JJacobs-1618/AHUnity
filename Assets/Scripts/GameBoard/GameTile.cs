using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTile : MonoBehaviour
{
    [SerializeField] protected string tileName;
    [SerializeField] protected LocationType locationType;
    [SerializeField] protected List<GameTile> connectedLocations;
    [SerializeField] protected GameTile blackConnection;
    [SerializeField] protected GameTile whiteConnection;
    [SerializeField] private GameObject tileUI;
    [SerializeField] TextMeshProUGUI tileText;
    [SerializeField] bool isClicked;

    public GameTile()
    {
        tileName = "Unset";
        isClicked = false;
    }

    private void Start()
    {
        tileText.text = tileName;
        tileUI.SetActive(false);
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
