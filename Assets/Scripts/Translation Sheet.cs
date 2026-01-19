using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TranslationSheet : MonoBehaviour
{
    //Initialising sprite lists and visibilities.
    private SpriteRenderer[] AllTranslationSprites;
    private SpriteRenderer[] AllIslandNameSprites;
    private bool TranslationVisible = false;
    private bool IslandNameVisible = false;
    //.

    //Initialising controls.
    public InputActionAsset controls;
    private InputActionMap ArmControls;
    //.

    void Start()
    {
        //Declaring controls.
        ArmControls = controls.FindActionMap("ArmMovements");
        ArmControls.Enable();
        //.

        //Declaring sprites.
        Transform Translations = transform.Find("Translations");
        AllTranslationSprites = Translations.GetComponentsInChildren<SpriteRenderer>();

        Transform IslandNames = transform.Find("IslandNames");
        AllIslandNameSprites = IslandNames.GetComponentsInChildren<SpriteRenderer>();
        //.

        SpriteVisibility(false, false);
    }

    //Controls for toggling visibility.
    private void Update()
    {
        if (ArmControls.FindAction("OpenTranslations").WasPressedThisFrame())
        {
            if (IslandNameVisible)
            {
                SpriteVisibility(true, false);
                TranslationVisible = true;
                IslandNameVisible = false;
            }
            else if (TranslationVisible)
            {
                SpriteVisibility(false, false);
                TranslationVisible = false;
                IslandNameVisible = false;
            }
            else 
            {
                SpriteVisibility(true, false);
                TranslationVisible = true;
                IslandNameVisible = false;
            }
        }

        if (ArmControls.FindAction("OpenIslandNames").WasPressedThisFrame())
        {
            if (TranslationVisible)
            {
                SpriteVisibility(false, true);
                TranslationVisible = false;
                IslandNameVisible = true;
            }
            else if (IslandNameVisible)
            {
                SpriteVisibility(false, false);
                TranslationVisible = false;
                IslandNameVisible = false;
            }
            else
            {
                SpriteVisibility(false, true);
                TranslationVisible = false;
                IslandNameVisible = true;
            }
        }
    }
    //.

    //Enable/disable sheet visibility.
    void SpriteVisibility(bool TranslationVisibility, bool IslandNameVisibility)
    {
        foreach (var SingleSprite in AllTranslationSprites)
        {
            SingleSprite.enabled = TranslationVisibility;
        }

        foreach (var SingleSprite in AllIslandNameSprites)
        {
            SingleSprite.enabled = IslandNameVisibility;
        }
    }
    //.
}
