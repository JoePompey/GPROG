using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using static SemaphoreDictionary;

public class Player : MonoBehaviour
{
    public InputActionAsset controls;
    private InputActionMap ArmControls;
    
    private SemaphoreDictionary SemaphoreDictionaryFile;
    Dictionary<string, ArmPositions> SemaphoreTranslations;
    
    private int PurplePos = 4;
    private int BluePos = 4;

    private void Start()
    {
        ArmControls = controls.FindActionMap("ArmMovements");

        SemaphoreDictionaryFile = GetComponent<SemaphoreDictionary>();
        SemaphoreTranslations = SemaphoreDictionaryFile.GetTranslations();
    }

    //Controls.
    private void Update()
    {
        if (ArmControls.FindAction("PurpleClock").WasPressedThisFrame())
        {
            CheckValidArms("Purple", 1);
        }
        if (ArmControls.FindAction("PurpleAnti").WasPressedThisFrame())
        {
            CheckValidArms("Purple", -1);
        }
        if (ArmControls.FindAction("BlueClock").WasPressedThisFrame())
        {
            CheckValidArms("Blue", 1);
        }
        if (ArmControls.FindAction("BlueAnti").WasPressedThisFrame())
        {
            CheckValidArms("Blue", -1);
        }
    }
    //.

    //Checks if there is an arm position in next movement. If not, find the next position available.
    void CheckValidArms(string ArmToCheck, int MoveDirection) //MoveDirection is 1 for clockwise, -1 for anticlockwise.
    {
        if (ArmToCheck == "Purple")
        {
            bool NextPosFound = false;
            while (NextPosFound == false)
            {
                PurplePos += MoveDirection;
                if (PurplePos == 8)
                {
                    PurplePos = 0;
                }
                else if (PurplePos == -1)
                {
                    PurplePos = 7;
                }

                if (SemaphoreTranslations.ContainsValue(new ArmPositions(PurplePos, BluePos)))
                {
                    NextPosFound = true;
                }
            }
        }

        if (ArmToCheck == "Blue")
        {
            bool NextPosFound = false;
            while (NextPosFound == false)
            {
                BluePos += MoveDirection;
                if (BluePos == 8)
                {
                    BluePos = 0;
                }
                else if (BluePos == -1)
                {
                    BluePos = 7;
                }

                if (SemaphoreTranslations.ContainsValue(new ArmPositions(PurplePos, BluePos)))
                {
                    NextPosFound = true;
                }
            }
        }
    }
    //.
}
