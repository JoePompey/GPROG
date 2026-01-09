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
    Dictionary<string, ArmPositions> SemaphoreTranslations;
    //-.

    void Start()
    {
        //Initialising dictionary.
        SemaphoreTranslations = new Dictionary<string, ArmPositions>();
        //.

        //Adding all the values where each number is a cardinal direction starting up at 0, and going 45 degrees clockwise.
        SemaphoreTranslations.Add("A", new ArmPositions(5, 4));
        SemaphoreTranslations.Add("B", new ArmPositions(6, 4));
        SemaphoreTranslations.Add("C", new ArmPositions(7, 4));
        SemaphoreTranslations.Add("D", new ArmPositions(0, 4));
        SemaphoreTranslations.Add("E", new ArmPositions(4, 1));
        SemaphoreTranslations.Add("F", new ArmPositions(4, 2));
        SemaphoreTranslations.Add("G", new ArmPositions(4, 3));
        SemaphoreTranslations.Add("H", new ArmPositions(6, 5));
        SemaphoreTranslations.Add("I", new ArmPositions(7, 5));
        SemaphoreTranslations.Add("J", new ArmPositions(0, 2));
        SemaphoreTranslations.Add("K", new ArmPositions(5, 0));
        SemaphoreTranslations.Add("L", new ArmPositions(5, 1));
        SemaphoreTranslations.Add("M", new ArmPositions(5, 2));
        SemaphoreTranslations.Add("N", new ArmPositions(5, 3));
        SemaphoreTranslations.Add("O", new ArmPositions(6, 7));
        SemaphoreTranslations.Add("P", new ArmPositions(6, 0));
        SemaphoreTranslations.Add("Q", new ArmPositions(6, 1));
        SemaphoreTranslations.Add("R", new ArmPositions(6, 2));
        SemaphoreTranslations.Add("S", new ArmPositions(6, 3));
        SemaphoreTranslations.Add("T", new ArmPositions(7, 0));
        SemaphoreTranslations.Add("U", new ArmPositions(7, 1));
        SemaphoreTranslations.Add("V", new ArmPositions(0, 3));
        SemaphoreTranslations.Add("W", new ArmPositions(1, 2));
        SemaphoreTranslations.Add("X", new ArmPositions(1, 3));
        SemaphoreTranslations.Add("Y", new ArmPositions(7, 2));
        SemaphoreTranslations.Add("Z", new ArmPositions(3, 2));
        SemaphoreTranslations.Add(" ", new ArmPositions(4, 4));
        //.
    }
    //.
}
