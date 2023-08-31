using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StreetTileSO", menuName = "Scriptables/GameBoard/StreetTile")]
public class StreetTileSO : NeighborhoodTileSO
{
    public StreetTileSO()
    {
        gameTileName = "Default StreetTile";
        gameTileType = GameTileType.Neighborhood;
        
        neighborhoodTileType = NeighborhoodTileType.Street;
        neighborhoodLocationType = NeighborhoodLocationType.NeighborhoodLocation;
    }
}
