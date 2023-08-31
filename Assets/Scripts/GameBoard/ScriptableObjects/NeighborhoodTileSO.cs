using UnityEngine;

public abstract class NeighborhoodTileSO : GameTileSO
{
    [Header("Neighborhood Information", order = 1)]
    public NeighborhoodTileType neighborhoodTileType;
    public NeighborhoodLocationType neighborhoodLocationType;
}
