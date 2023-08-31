/*
 * GameTile Data Fields 
 * gameTileName: Name of GameTile
 * gameTileType: One of the following: Neighborhood, Gate, CityLimit. Default is GameTile and indicates unspecified location information.
 * 
 * Neighborhood Data Fields
 * neighborhoodTileType: One of the following: Location, Street. Default is NeighborhoodTile and indicates unspecified Tile setup.
 * neighborhoodLocationType: One of the 9 Neighborhoods in Arkham. Default is NeighborhoodLocation and indicates and unset neighborhood.
 * blackConnection: Monster movement to black
 * whiteConnection: Monster movement to white
 * 
 * Location Data Fields
 * stability: One of the following: Stable, Unstable, Sealed. Default is Unset
 * clueTokens: number of tokens at this location. 
 * isGateAtLocation: a boolean that indicates if there is a gate at the location
 */
public class Location : NeighborhoodTile
{

    public override void Setup()
    {
        
    }
    public override void Configure()
    {
        
    }
}
    /*
    [SerializeField] int cluesAtLocation;
    [SerializeField] bool isUnstable;
    [SerializeField] bool hasOpenGate;
    [SerializeField] bool isSealed;
    [SerializeField] bool hasLocationAbility;

    public Location()
    {
        cluesAtLocation = 0;
    }
    private void Start()
    {
        tileText.text = tileName;
        HideUI();
    }
    public bool GetStability()
    {
        return isUnstable;
    }

    public bool GetSealed()
    {
        return isSealed;
    }

    public bool GetOpenGate()
    {
        return hasOpenGate;
    }

    public void AddToken()
    {
        cluesAtLocation++;
    }

    public int GetTokens()
    {
        return cluesAtLocation;
    }

    public void ResetTokens()
    {
        cluesAtLocation = 0;
    }
}

    */