using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterSO data;
    MonsterController controller;
    MonsterUIController monsterDetails;
    NeighborhoodTile currentLocation;

    private void Awake()
    {
        
    }

    private void Start()
    {
        this.gameObject.TryGetComponent<MonsterUIController>(out monsterDetails);
        monsterDetails.Init(data);
        monsterDetails.enabled = false;
    }

    public NeighborhoodTile CurrentLocation
    {
        get => currentLocation;
        set => currentLocation = value;
    }
    public void MoveBlack()
    {
        this.transform.position = CurrentLocation.blackConnection.transform.position + new Vector3(0, 1, 0);
        CurrentLocation = CurrentLocation.blackConnection;
    }

    public void MoveWhite()
    {
        this.transform.position = CurrentLocation.whiteConnection.transform.position + new Vector3(0, 1, 0);
        CurrentLocation = CurrentLocation.whiteConnection;
    }
}
