using UnityEngine;

public class Sailor : MonoBehaviour
{
    private void Start()
    {
        DecideIsland();
        NameSplitter();
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
    }
    //.

    //Splits word into an array of letters that can be translated.
    string[] SplitName;
    void NameSplitter()
    {
        SplitName = new string[DesiredIsland.Length + 1];
        for (int i = 0; i < DesiredIsland.Length; i++)
        {
            SplitName[i] = DesiredIsland[i].ToString();
        }
        SplitName[^1] = "New Word";
    }
    //.
}
