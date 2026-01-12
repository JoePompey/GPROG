using JetBrains.Annotations;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapBuilder : MonoBehaviour
{
    private void Start()
    {
        AssignTiles();
        VisualiseTiles();
    }

    //Making an empty array that will be the positions of the islands.
    string[,] IslandPositions = new string[8, 8];
    //.

    void AssignTiles()
    {
        //Making an array of all the available island types.
        string[] AvailableIslands = new string[8];
        AvailableIslands[0] = "PLAIN";
        AvailableIslands[1] = "PALM";
        AvailableIslands[2] = "PINE";
        AvailableIslands[3] = "STONY";
        AvailableIslands[4] = "VOLCANO";
        AvailableIslands[5] = "HOLIDAY";
        AvailableIslands[6] = "PARTY";
        AvailableIslands[7] = "CITY";
        //.

        //Adding the islands to random positions and tries again if position is taken.
        for (int i = 0; i < 8; i++) { 
            bool PositionConfirmed = false;
            while (PositionConfirmed == false)
            {
                int x = Random.Range(0, 8);
                int y = Random.Range(0, 8);
                if (IslandPositions[x, y] == null)
                {
                    IslandPositions[x, y] = AvailableIslands[i];
                    PositionConfirmed = true;
                }
            }
        }
        //.
        
        //Fills in empty tiles with water.
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (IslandPositions[i, j] == null)
                {
                    IslandPositions[i, j] = "WATER";
                }
            }
        }
        //.
    }

    //Gets the inspector ready to know who the tilemap an tiles are.
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase[] tiles;
    private Dictionary<string, TileBase> tileLookup;
    //.
    void VisualiseTiles()
    {
        //Gets the components given in inspector ready.
        tilemap = GetComponent<Tilemap>();
        tileLookup = new Dictionary<string, TileBase>();
        
        foreach (var tile in tiles)
        {
            tileLookup[tile.name] = tile;
        }
        //.

        //Sets the correct tile for position.
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0;j < 8; j++)
            {
                Vector3Int CurrentTilePosition = new Vector3Int(j, 8 - i, 0);
                TileBase CurrentTileType = tileLookup[IslandPositions[i, j]];
                
                tilemap.SetTile(CurrentTilePosition, CurrentTileType);
            }
        }
        //.
    }
}
