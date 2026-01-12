using UnityEngine;

public class Sailor : MonoBehaviour
{
    private void Start()
    {
        DecideIsland();
    }
    
    //Decides what island they want to go to.
    string DesiredIsland;
    void DecideIsland()
    {
        //Gets choosable options.
        string[] IslandOptions = new string[8];
        IslandOptions[0] = "PLAIN";
        IslandOptions[1] = "PALM";
        IslandOptions[2] = "PINE";
        IslandOptions[3] = "STONY";
        IslandOptions[4] = "VOLCANO";
        IslandOptions[5] = "HOLIDAY";
        IslandOptions[6] = "PARTY";
        IslandOptions[7] = "CITY";
        //.

        //Picks random choice from available options.
        DesiredIsland = IslandOptions[Random.Range(0, 8)];
        //.

        print(DesiredIsland);
    }
    //.
}
