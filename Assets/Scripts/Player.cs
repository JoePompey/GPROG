using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static SemaphoreDictionary;

public class Player : MonoBehaviour
{
    public InputActionAsset controls;
    private InputActionMap ArmControls;
    
    private SemaphoreDictionary SemaphoreDictionaryFile;
    Dictionary<ArmPositions, string> SemaphoreTranslations;
    private SpriteSetter SpriteSetterFile;
    
    private int PurplePos = 4;
    private int BluePos = 4;

    private string[] SelectedCoordinates = new string[2];

    private void Start()
    {
        ArmControls = controls.FindActionMap("ArmMovements");

        SemaphoreDictionaryFile = GetComponent<SemaphoreDictionary>();
        SemaphoreTranslations = new Dictionary<ArmPositions, string>();
        SemaphoreTranslations = SemaphoreDictionaryFile.GetTranslations();

        SpriteSetterFile = GetComponent<SpriteSetter>();

        SelectedCoordinates[0] = " ";
        SelectedCoordinates[1] = " ";

        FirstCoord = GameObject.Find("FirstCoord").GetComponent<SpriteSetter>();
        SecondCoord = GameObject.Find("SecondCoord").GetComponent<SpriteSetter>();
        SailorScript = GameObject.Find("SailorSprite").GetComponent<Sailor>();

        SetSprite();
    }

    //Controls.
    private void Update()
    {
        if (ArmControls.FindAction("PurpleClock").WasPressedThisFrame())
        {
            CheckValidArms("Purple", 1);
            SetSprite();
        }
        if (ArmControls.FindAction("PurpleAnti").WasPressedThisFrame())
        {
            CheckValidArms("Purple", -1);
            SetSprite();
        }
        if (ArmControls.FindAction("BlueClock").WasPressedThisFrame())
        {
            CheckValidArms("Blue", 1);
            SetSprite();
        }
        if (ArmControls.FindAction("BlueAnti").WasPressedThisFrame())
        {
            CheckValidArms("Blue", -1);
            SetSprite();
        }
        if (ArmControls.FindAction("Enter").WasPressedThisFrame())
        {
            SelectCoordinate();
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

                if (SemaphoreTranslations.ContainsKey(new ArmPositions(PurplePos, BluePos)))
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

                if (SemaphoreTranslations.ContainsKey(new ArmPositions(PurplePos, BluePos)))
                {
                    NextPosFound = true;
                }
            }
        }
    }
    //.

    //Get letter from dictionary and change sprite.
    string SpriteName = "New Word";
    void SetSprite()
    {
        SpriteName = SemaphoreTranslations[new ArmPositions(PurplePos, BluePos)];
        SpriteSetterFile.SetArms(SpriteName);
    }
    //.

    //Save selected co-ordinate.
    int CurrentCoordinate = 0;
    Sailor SailorScript;
    void SelectCoordinate()
    {
        if (!(PurplePos == 4 && BluePos == 4)){
            SpriteName = SemaphoreTranslations[new ArmPositions(PurplePos, BluePos)];
            if (CurrentCoordinate == 0)
            {
                SelectedCoordinates[0] = SpriteName;
                CurrentCoordinate = 1;
            }
            else if (CurrentCoordinate == 1)
            {
                SelectedCoordinates[1] = SpriteName;
                CurrentCoordinate = 0;

                SailorScript.ConfirmDestination(SelectedCoordinates[0], SelectedCoordinates[1]);
            }
            ShowCoordinates();
        }
    }
    //.

    //Show current co-ordinates.
    private SpriteSetter FirstCoord;
    private SpriteSetter SecondCoord;
    void ShowCoordinates()
    {
        if (CurrentCoordinate == 1)
        {
            FirstCoord.SetLetter(SelectedCoordinates[0]);
        }
        else if (CurrentCoordinate == 0)
        {
            SecondCoord.SetLetter(SelectedCoordinates[1]);
        }
    }
    //.
}
