using UnityEngine;

[CreateAssetMenu(fileName = "LocationTileSO", menuName = "Scriptables/GameBoard/LocationTile")]
public class LocationTileSO : NeighborhoodTileSO
{
    [Header("Location Information", order = 2)]
    public LocationStabilityType stability;
    public int clueTokens;
    public bool isGateAtLocation;
    public bool hasLocationAbility;
    public bool isClosed;

    public LocationTileSO()
    {
        // Tile Info
        gameTileName = "Default LocationTile";
        gameTileType = GameTileType.Neighborhood;
        // Neighborhood Info
        neighborhoodTileType = NeighborhoodTileType.Location;
        neighborhoodLocationType = NeighborhoodLocationType.NeighborhoodLocation;
        // Location Info
        stability = LocationStabilityType.LocationStability;
        clueTokens = 0;
        isGateAtLocation = false;
        hasLocationAbility = false;
        isClosed = false;
    }
}
