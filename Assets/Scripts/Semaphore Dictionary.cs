using UnityEngine;
using System.Collections.Generic;

public class SemaphoreDictionary : MonoBehaviour
{
    //Struct that stores the positions of both arms.
    public struct ArmPositions
    {
        public int PurpleArmPos;
        public int BlueArmPos;

        //Initialisation.
        public ArmPositions(int Purple, int Blue)
        {
            PurpleArmPos = Purple;
            BlueArmPos = Blue;
        }
        //.
    }
    //.

    //Declaring and initialising the dictionary.
    //-Declaring dictionary.
    Dictionary<ArmPositions, string> SemaphoreTranslations;
    //-.

    void Awake()
    {
        //Initialising dictionary.
        SemaphoreTranslations = new Dictionary<ArmPositions, string>();
        //.

        //Adding all the values where each number is a cardinal direction starting up at 0, and going 45 degrees clockwise.
        SemaphoreTranslations.Add(new ArmPositions(5, 4), "A");
        SemaphoreTranslations.Add(new ArmPositions(6, 4), "B");
        SemaphoreTranslations.Add(new ArmPositions(7, 4), "C");
        SemaphoreTranslations.Add(new ArmPositions(0, 4), "D");
        SemaphoreTranslations.Add(new ArmPositions(4, 1), "E");
        SemaphoreTranslations.Add(new ArmPositions(4, 2), "F");
        SemaphoreTranslations.Add(new ArmPositions(4, 3), "G");
        SemaphoreTranslations.Add(new ArmPositions(6, 5), "H");
        SemaphoreTranslations.Add(new ArmPositions(7, 5), "I");
        SemaphoreTranslations.Add(new ArmPositions(0, 2), "J");
        SemaphoreTranslations.Add(new ArmPositions(5, 0), "K");
        SemaphoreTranslations.Add(new ArmPositions(5, 1), "L");
        SemaphoreTranslations.Add(new ArmPositions(5, 2), "M");
        SemaphoreTranslations.Add(new ArmPositions(5, 3), "N");
        SemaphoreTranslations.Add(new ArmPositions(6, 7), "O");
        SemaphoreTranslations.Add(new ArmPositions(6, 0), "P");
        SemaphoreTranslations.Add(new ArmPositions(6, 1), "Q");
        SemaphoreTranslations.Add(new ArmPositions(6, 2), "R");
        SemaphoreTranslations.Add(new ArmPositions(6, 3), "S");
        SemaphoreTranslations.Add(new ArmPositions(7, 0), "T");
        SemaphoreTranslations.Add(new ArmPositions(7, 1), "U");
        SemaphoreTranslations.Add(new ArmPositions(0, 3), "V");
        SemaphoreTranslations.Add(new ArmPositions(1, 2), "W");
        SemaphoreTranslations.Add(new ArmPositions(3, 1), "X");
        SemaphoreTranslations.Add(new ArmPositions(7, 2), "Y");
        SemaphoreTranslations.Add(new ArmPositions(3, 2), "Z");
        SemaphoreTranslations.Add(new ArmPositions(4, 4), "New Word");
        //.
    }
    //.

    //Getter script to read the translations.
    public Dictionary<ArmPositions, string> GetTranslations()
    {
        return SemaphoreTranslations;
    }
    //.
}
