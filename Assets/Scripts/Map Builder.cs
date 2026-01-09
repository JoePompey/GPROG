using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    private void Start()
    {
        AssignTiles();
    }
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

        //Making an empty array that will be the positions of the islands.
        string[,] IslandPositions = new string[8, 8];
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
}
