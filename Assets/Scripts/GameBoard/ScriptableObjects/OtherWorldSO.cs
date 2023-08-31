using UnityEngine;

[CreateAssetMenu(fileName = "OtherWorldTileSO", menuName = "Scriptables/GameBoard/OtherWorldTile")]
public class OtherWorldSO : GameTileSO
{
    [Header("Other World Information", order = 2)]
    public bool hasRed;
    public bool hasBlue;
    public bool hasGreen;
    public bool hasYellow;

    public OtherWorldSO()
    {
        // Game Tile Info
        gameTileName = "Default Other World";
        gameTileType = GameTileType.OtherWorld;
        //Other World Info
        hasRed = false;
        hasBlue = false;
        hasGreen = false;
        hasYellow = false;
    }
}
