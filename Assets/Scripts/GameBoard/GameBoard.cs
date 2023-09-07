using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public static GameBoard instance;
    [Header("Game Tiles")]
    public List<GameObject> locations;
    public List<GameObject> streets;
    public List<GameObject> otherWorlds;
    public List<GameObject> cityLimits;
    [Header("Card Decks")] // TODO: This may be better in a DeckManager.... 
    public MythosDeck mythos;

    // public Dictionary<NeighborhoodTile, LocationEncounterDeck> locationEncounters;
    // public OtherWorldEncounterDeck otherWorldEncounters;
    // public CommonItemDeck commonItems;
    // public UniqueItemDeck uniqueItems;
    // public SpellDeck spells;
    // public SkillDeck skills;
    // public AllyDeck allies;

    private MonsterFactory mf;
    private GateFactory gf;
    private List<Location> locationRefs;
    private List<Street> streetRefs;
    //private List<> otherWorlds;
    //private List<> cityLimits;


    public List<Monster> monstersInPlay;
    public List<Monster> monstersInOutskirts;


    private bool isInitialized;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        monstersInPlay = new();
        monstersInOutskirts = new();
    }

    private void Start()
    {
        gf = GateFactory.instance;
        mf = MonsterFactory.instance;
    }

    public void GetReachableTiles(NeighborhoodTile tile, int movementPoints, int currStep, ref Dictionary<NeighborhoodTile, int> returnDict)
    { 
        if (((NeighborhoodTileSO)tile.data).neighborhoodTileType == NeighborhoodTileType.Location)
        {
            if (((LocationTileSO)tile.data).isClosed) return;
        }
        returnDict.Add(tile, currStep);
        currStep++;
        if (currStep > movementPoints) return;

        NeighborhoodTileSO tileData = (NeighborhoodTileSO)tile.data;

        switch (tileData.neighborhoodTileType)
        {
            case NeighborhoodTileType.Location:
                if (returnDict.ContainsKey(tile.blackConnection))
                {
                    if (returnDict.GetValueOrDefault(tile.blackConnection) > currStep)
                    {
                        returnDict.Remove(tile.blackConnection);
                    }
                    else
                        break;
                }
                GetReachableTiles(tile.blackConnection, movementPoints, currStep, ref returnDict);
                break;
            case NeighborhoodTileType.Street:
                foreach (NeighborhoodTile nt in ((Street)tile).connectedLocations)
                {
                    if (returnDict.ContainsKey(nt))
                    {
                        if (returnDict.GetValueOrDefault(nt) > currStep)
                        {
                            returnDict.Remove(nt);
                        }
                        else
                            continue;
                    }
                    GetReachableTiles(nt, movementPoints, currStep, ref returnDict);
                }
                break;
            case NeighborhoodTileType.NeighborhoodTile:
                break;
        }        
    }

    public void SetupBoard()
    {
        if (isInitialized)
        {
            Debug.LogWarning("Game Board is already initialized. Press Init Button again to re-initialize.");
            isInitialized = false;
            return;
        }
        GetGameTileReferences();
        SetCluesOnUnstableLocations();
        // InitDecks();
        mythos.Init();
        isInitialized = true;
    }

    private void GetGameTileReferences()
    {
        locationRefs = new();
        streetRefs = new();
        foreach (GameObject go in locations)
            locationRefs.Add(go.GetComponent<Location>());
            
        foreach (GameObject go in streets)
            streetRefs.Add(go.GetComponent<Street>());

        foreach (Location lts in locationRefs)
        {
            ((LocationTileSO)lts.data).isGateAtLocation = false;
            ((LocationTileSO)lts.data).isClosed = false;
        }
            
        //foreach (GameObject go in otherWorlds)
        //streetRefs.Add(go.GetComponent<Street>());
    }

    public Location GetLocation(string home)
    {
        return locationRefs.Find(x => x.data.gameTileName.Contains(home));
    }

    public Street GetStreet(string street)
    {
        return streetRefs.Find(x => x.data.gameTileName.Contains(street));
    }
    /*public OtherWorld GetOtherWorld(string ow)
    {
        return otherWorldRefs.Find(x => x.data.gameTileName.Contains(ow));
    }*/

    public GameTile GetGameTile(string tile)
    {
        return null;
    }

    private void SetCluesOnUnstableLocations()
    {
        try
        {
            foreach (Location l in locationRefs)
            {
                LocationTileSO lData = (LocationTileSO)l.data;
                lData.clueTokens = 0;                                           // Due to the fact that ScriptableObjects will save data after PlayMode ends, this re-inits these guys to 0 as we come across.
                if (lData.stability == LocationStabilityType.Stable) continue;
                lData.clueTokens++;
            }
        }
        catch
        {
            Debug.LogError("Unable to locate references in GameBoard.");
        }
    }

    public void CloseLocation(string location)
    {
        Location l = GetLocation(location);
        LocationTileSO tileData = (LocationTileSO)l.data;
        if (tileData.isClosed) return;
        tileData.isClosed = true;
        // Kick out everything in the location
        
    }

    public void OpenLocation(string location)
    {
        Location l = GetLocation(location);
        LocationTileSO tileData = (LocationTileSO)l.data;
        if (tileData.isClosed) tileData.isClosed = false;
    }

    internal bool SpawnGate(MythosCardSO mythos)
    {
        Location l = GetLocation(mythos.GateAppears.gameTileName);
        LocationTileSO tileData = (LocationTileSO)l.data;
        if (tileData.isGateAtLocation)
        {
            Debug.Log("Monster Surge.");
            return false; // false indicates monster surge
        }
        

        Gate gate = gf.GetNewInstance();
        gate.gameObject.name = $"Gate ({gate.data.gateName}";
        Debug.Log($"Gate Spawning at {mythos.GateAppears.gameTileName})");
        gate.gameObject.transform.position = l.transform.position + new Vector3(0, 1, 0);
        tileData.isGateAtLocation = true;

        return true;
    }
    public void SpawnMonster(Location location)
    {
        // Create a new gameobject to hold the monster
        GameObject monsterGO = mf.GetNewInstance().gameObject;
        Monster monster = monsterGO.GetComponent<Monster>();
        monsterGO.name = $"Monster ({monster.data.MonsterName})";
        monsterGO.transform.position = location.transform.position + new Vector3(0, 1, 0); //TODO: Spawn Where Needed
        monster.CurrentLocation = location;
        monstersInPlay.Add(monster);
    }
}
    /*
    public static GameBoard instance;
    [Header("Game Tiles")]
    [SerializeField] List<GameObject> locations;
    [SerializeField] List<GameObject> streets;
    [SerializeField] List<GameObject> otherWorlds;
    [Header("Arkham Encounters")]
    Dictionary<LocationType, ArkhamEncounters> arkhamEncounters;
    [SerializeField] List<ArkhamEncounters> encounters;

    

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
    */
