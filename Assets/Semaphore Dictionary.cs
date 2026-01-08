using UnityEngine;
using System.Collections.Generic;

public class SemaphoreDictionary
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
}
