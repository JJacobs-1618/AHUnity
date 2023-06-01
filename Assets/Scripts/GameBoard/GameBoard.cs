using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public static GameBoard instance;
    [Header("Game Tiles")]
    [SerializeField] List<GameObject> locations;
    [SerializeField] List<GameObject> streets;
    [SerializeField] List<GameObject> otherWorlds;
    [Header("Arkham Encounters")]
    Dictionary<LocationType, ArkhamEncounters> arkhamEncounters;
    [SerializeField] List<ArkhamEncounters> encounters;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void InitGameBoard()
    {
        SetClueTokens();
        SetupArkhamEncounterDictionary();
    }

    private void SetupArkhamEncounterDictionary()
    {
        arkhamEncounters = new Dictionary<LocationType, ArkhamEncounters>();
        arkhamEncounters.TryAdd(LocationType.Downtown, encounters.Find(x => x.name == "Downtown"));
        arkhamEncounters.TryAdd(LocationType.Easttown, encounters.Find(x => x.name == "Easttown"));
        arkhamEncounters.TryAdd(LocationType.FrenchHill, encounters.Find(x => x.name == "FrenchHill"));
        arkhamEncounters.TryAdd(LocationType.MerchantDistrict, encounters.Find(x => x.name == "MerchantDistrict"));
        arkhamEncounters.TryAdd(LocationType.MiskatonicUniveristy, encounters.Find(x => x.name == "MiskatonicUniveristy"));
        arkhamEncounters.TryAdd(LocationType.Northside, encounters.Find(x => x.name == "Northside"));
        arkhamEncounters.TryAdd(LocationType.Rivertown, encounters.Find(x => x.name == "Rivertown"));
        arkhamEncounters.TryAdd(LocationType.Southside, encounters.Find(x => x.name == "Southside"));
        arkhamEncounters.TryAdd(LocationType.Uptown, encounters.Find(x => x.name == "Uptown"));
    }

    private void SetClueTokens()
    {
        foreach (GameObject go in locations)
        {
            Location l = go.GetComponent<Location>();
            if (!l.GetStability()) l.AddToken();
        }
    }

    public GameObject GetLocation(string location)
    {
        GameObject retVal = null;
        foreach(GameObject go in locations)
        {
            if (location == go.GetComponent<Location>().GetName())
            {
                retVal = go;
                break; ;
            }
        }
        return retVal;
    }

    public List<GameTile> GetLocationsInRange(GameTile starting, int movementPoints)
    {
        List<GameTile> retVal = new List<GameTile>();
        retVal.Add(starting);

        for(int i = 0; i < movementPoints; i++)
        {
            int retValCount = retVal.Count;
            for(int j = 0; j < retValCount; j++)
            {
                foreach (GameTile tile in retVal[j].GetConnectedLocations())
                {
                    if (!retVal.Contains(tile)) retVal.Add(tile);
                }
            }
        }

        return retVal;
    }

    public ArkhamEncounters GetArkhamEncounters(LocationType type)
    {
        ArkhamEncounters retVal;
        if (!arkhamEncounters.TryGetValue(type, out retVal))
            Debug.LogError("GameBoard: Unable to locate Arkham Encounters.");
        return retVal;        
    }
}
