using UnityEngine;

public abstract class GameTileSO : ScriptableObject
{
    [Header("Game Tile Information", order = 0)]
    public string gameTileName;
    public GameTileType gameTileType;
    public bool InArkham;
}
