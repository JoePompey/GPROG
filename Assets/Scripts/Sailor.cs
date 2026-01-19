using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sailor : MonoBehaviour
{
    private void Start()
    {
        //Loading references.
        SpriteSetterFile = GetComponent<SpriteSetter>();
        MapScript = GameObject.Find("Tilemap").GetComponent<MapBuilder>();

        Alphabet = new Sprite[26];
        Alphabet = Resources.LoadAll<Sprite>("Alphabet_Spritesheet");

        HeartsSetter = GameObject.Find("HeartsSprite").GetComponent<SpriteSetter>();
        EmotionSetter = GameObject.Find("EmotionSprite").GetComponent<SpriteSetter>();
        HundredsSetter = GameObject.Find("Hundreds").GetComponent<SpriteSetter>();
        TensSetter = GameObject.Find("Tens").GetComponent<SpriteSetter>();
        UnitsSetter = GameObject.Find("Units").GetComponent<SpriteSetter>();
        //.

        DecideIsland();
        NameSplitter();
        MoveArmsCoroutine = StartCoroutine(MoveArms());
        EmotionSetter.SetEmotion(0, false);
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

    //Sets correct sprite for letter.
    private SpriteSetter SpriteSetterFile;
    [SerializeField] int delay = 2;
    Coroutine MoveArmsCoroutine;
    IEnumerator MoveArms()
    {
        bool Repeat = true;
        while (Repeat == true)
        {
            for (int i = 0; i < SplitName.Length; i++)
            {
                SpriteSetterFile.SetArms(SplitName[i]);

                yield return new WaitForSeconds(delay);
            }
        }
    }
    //.

    //Resets sailor for next round.
    IEnumerator ResetSailor()
    {
        yield return new WaitForSeconds(2);

        StopCoroutine(MoveArmsCoroutine);
        MoveArmsCoroutine = null;

        EmotionSetter.SetEmotion(0, false);
        DecideIsland();
        NameSplitter();
        MoveArmsCoroutine = StartCoroutine(MoveArms());
    }
    //.

    //Confirms if destination is correct.
    MapBuilder MapScript;
    Sprite[] Alphabet;
    int XCoordIndex = -1;
    int YCoordIndex = -1;

    public void ConfirmDestination(string XCoord, string YCoord)
    {
        //Gets index number of co-ords to check easier.
        for (int i = 0; i < 26; i++)
        {
            if (XCoord == Alphabet[i].name)
            {
                XCoordIndex = i;
                break;
            }
        }
        for (int i = 0; i < 26; i++)
        {
            if (YCoord == Alphabet[i].name)
            {
                YCoordIndex = i;
                break;
            }
        }
        //.

        //Compares selected co-ords to desired name.
        if (XCoordIndex < 8 && YCoordIndex < 8){
            string SelectedIsland = MapScript.IslandPositions[YCoordIndex, XCoordIndex];
            if (SelectedIsland == DesiredIsland)
            {
                GainPoint();
            }
            else
            {
                LoseLife();
            }
        }
        else
        {
            LoseLife();
        }
        //.
    }
    //.

    //Gain point and display.
    int CurrentPoints = 0;
    SpriteSetter EmotionSetter;
    void GainPoint()
    {
        CurrentPoints += 1;
        EmotionSetter.SetEmotion(1, true);

        SetPointsVisual();
        StartCoroutine(ResetSailor());
    }

    //.

    //Lose life and display.
    SpriteSetter HeartsSetter;
    int CurrentHearts = 3;
    void LoseLife()
    {
        CurrentHearts -= 1;
        HeartsSetter.SetHearts(CurrentHearts);
        EmotionSetter.SetEmotion(0, true);

        //Game overs if all lives lost.
        if (CurrentHearts == 0)
        {
            SceneManager.LoadScene("GameOverScreen");
        }
        //.

        StartCoroutine(ResetSailor());
    }
    //.

    //Sets up points display.
    SpriteSetter HundredsSetter;
    SpriteSetter TensSetter;
    SpriteSetter UnitsSetter;
    void SetPointsVisual()
    {
        //Calculates individual digits.
        int Remainder = CurrentPoints;
        
        int Hundreds = Remainder / 100;
        Remainder -= Hundreds;

        int Tens = Remainder / 10;
        Remainder -= Tens;

        int Units = Remainder;
        //.

        //Calls the SpriteSetters.
        HundredsSetter.SetNumber(Hundreds);
        TensSetter.SetNumber(Tens);
        UnitsSetter.SetNumber(Units);
        //.
    }
    //.
}
