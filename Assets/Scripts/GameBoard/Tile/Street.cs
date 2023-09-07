using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
 * Street Data Fields
 * connectedLocations: Connected locations for Investigator movement
 */


public class Street : NeighborhoodTile
{
    public List<NeighborhoodTile> connectedLocations;
    public override void Setup()
    {
        
    }

    public override void Configure()
    {
        
    }
}
