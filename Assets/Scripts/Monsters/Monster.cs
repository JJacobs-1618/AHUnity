using System;
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
        SetMovementColor();
    }

    private void Update()
    {
        if (monsterDetails.detailsPane.activeInHierarchy) monsterDetails.detailsPane.transform.rotation = Camera.main.transform.rotation;
    }

    private void SetMovementColor()
    {
        Color setColor = Color.gray;
        switch (data.MovementType)
        {
            case MonsterMovementType.Normal:
                setColor = Color.black;
                break;
            case MonsterMovementType.Stationary:
                setColor = Color.yellow;
                break;
            case MonsterMovementType.Fast:
                setColor = Color.red;
                break;
            case MonsterMovementType.Unique:
                setColor = Color.green;
                break;
            case MonsterMovementType.Flying:
                setColor = Color.blue;
                break;
            case MonsterMovementType.Stalker:
                setColor = new Color(1, 0, 1, 1);
                break;
            case MonsterMovementType.Aquatic:
                setColor = new Color(1, .5f, .5f, 1);
                break;
            case MonsterMovementType.MovementType:
                break;
            default:
                break;
        }
        this.gameObject.GetComponent<MeshRenderer>().material.color = setColor;
    }

    public NeighborhoodTile CurrentLocation
    {
        get => currentLocation;
        set => currentLocation = value;
    }
    public void MoveBlack()
    {
        // if there is an investigator in this area, stay put.
        NeighborhoodTile dest = null;
        switch (data.MovementType)
        {
            case MonsterMovementType.Normal:
                dest = CurrentLocation.blackConnection;
                break;
            case MonsterMovementType.Stationary:
                return;
            case MonsterMovementType.Fast:
                dest = CurrentLocation.blackConnection.blackConnection;
                break;
            case MonsterMovementType.Unique:
                PerformUniqueMovement();
                return;
            case MonsterMovementType.Flying:
                // check if they are in the sky or if there is an investigator in an adjacent street/location.
                    // if so, move to investigator with lowest sneak                
                // otherwise, move to the sky.
                break;
            case MonsterMovementType.Stalker:
                break;
            case MonsterMovementType.Aquatic:
                break;
            case MonsterMovementType.MovementType:
                break;
            default:
                Debug.LogWarning($"No Monster Movement. Check monster {this.gameObject.name}");
                break;
        }
        this.transform.position = dest.transform.position + new Vector3(0, 1, 0);
        CurrentLocation = dest;
    }

    private void PerformUniqueMovement()
    {
        data.ability.Execute(this.gameObject);
    }

    public void MoveWhite()
    {
        // if there is an investigator in this area, stay put.
        NeighborhoodTile dest = null;
        switch (data.MovementType)
        {
            case MonsterMovementType.Normal:
                dest = CurrentLocation.whiteConnection;
                break;
            case MonsterMovementType.Stationary:
                return;
            case MonsterMovementType.Fast:
                dest = CurrentLocation.whiteConnection.whiteConnection;
                break;
            case MonsterMovementType.Unique:
                PerformUniqueMovement();
                return;
            case MonsterMovementType.Flying:
                // check if they are in the sky or if there is an investigator in an adjacent street/location.
                // if so, move to investigator with lowest sneak                
                // otherwise, move to the sky.
                break;
            case MonsterMovementType.Stalker:
                break;
            case MonsterMovementType.Aquatic:
                break;
            case MonsterMovementType.MovementType:
                break;
            default:
                Debug.LogWarning($"No Monster Movement. Check monster {this.gameObject.name}");
                break;
        }
        this.transform.position = dest.transform.position + new Vector3(0, 1, 0);
        CurrentLocation = dest;
    }
}
