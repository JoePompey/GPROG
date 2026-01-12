using System.Collections;
using UnityEngine;

public class Sailor : MonoBehaviour
{
    private void Start()
    {
        //Gets sprite ready.
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = ArmSprites[26];
        //.

        DecideIsland();
        NameSplitter();
        StartCoroutine(MoveArms());
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


    //Gets the correct sprites ready in inspector.
    public Sprite[] ArmSprites;
    private SpriteRenderer spriteRenderer;
    //.

    //Sets correct sprite for letter.
    int delay = 1;
    IEnumerator MoveArms()
    {
        bool Repeat = true;
        while (Repeat == true)
        {
            for (int i = 0; i < SplitName.Length; i++)
            {
                //Gets index of the letter in the sprites.
                int SpriteIndex = 26;
                for (int j = 0; j < ArmSprites.Length; j++)
                { 
                    if (ArmSprites[j].name == SplitName[i])
                    {
                        SpriteIndex = j;
                        break;
                    }
                }
                //.

                //Changes sprite to correct arms.
                spriteRenderer.sprite = ArmSprites[SpriteIndex];
                //.

                yield return new WaitForSeconds(delay);
            }
        }
    }
    //.
}
