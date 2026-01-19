using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TranslationSheet : MonoBehaviour
{
    //Initialising sprite lists and visibilities.
    private SpriteRenderer[] AllTranslationSprites;
    private SpriteRenderer[] AllIslandNameSprites;
    private SpriteRenderer[] AllHelpSprites;
    private bool TranslationVisible = false;
    private bool IslandNameVisible = false;
    private bool HelpVisible = false;
    //.

    //Initialising controls.
    public InputActionAsset controls;
    private InputActionMap ArmControls;
    //.

    void Start()
    {
        //Declaring controls.
        ArmControls = controls.FindActionMap("GameControls");
        ArmControls.Enable();
        //.

        //Declaring sprites.
        Transform Translations = transform.Find("Translations");
        AllTranslationSprites = Translations.GetComponentsInChildren<SpriteRenderer>();

        Transform IslandNames = transform.Find("IslandNames");
        AllIslandNameSprites = IslandNames.GetComponentsInChildren<SpriteRenderer>();

        Transform Help = transform.Find("Help");
        AllHelpSprites = Help.GetComponentsInChildren<SpriteRenderer>();
        //.

        SpriteVisibility(TranslationVisible, IslandNameVisible, HelpVisible);
    }

    //Controls for toggling visibility.
    private void Update()
    {
        if (ArmControls.FindAction("OpenTranslations").WasPressedThisFrame())
        {
            if (TranslationVisible)
            {
                TranslationVisible = false;
                IslandNameVisible = false;
                HelpVisible = false;
            }
            else 
            {
                TranslationVisible = true;
                IslandNameVisible = false;
                HelpVisible = false;
            }
            SpriteVisibility(TranslationVisible, IslandNameVisible, HelpVisible);
        }

        if (ArmControls.FindAction("OpenIslandNames").WasPressedThisFrame())
        {
            if (IslandNameVisible)
            {
                TranslationVisible = false;
                IslandNameVisible = false;
                HelpVisible = false;
            }
            else
            {
                TranslationVisible = false;
                IslandNameVisible = true;
                HelpVisible = false;
            }
            SpriteVisibility(TranslationVisible, IslandNameVisible, HelpVisible);
        }
        
        if (ArmControls.FindAction("OpenHelp").WasPressedThisFrame())
        {
            if (HelpVisible)
            {
                TranslationVisible = false;
                IslandNameVisible = false;
                HelpVisible = false;
            }
            else
            {
                TranslationVisible = false;
                IslandNameVisible = false;
                HelpVisible = true;
            }
            SpriteVisibility(TranslationVisible, IslandNameVisible, HelpVisible);
        }
    }
    //.

    //Enable/disable sheet visibility.
    void SpriteVisibility(bool TranslationVisibility, bool IslandNameVisibility, bool HelpVisibility)
    {
        foreach (var SingleSprite in AllTranslationSprites)
        {
            SingleSprite.enabled = TranslationVisibility;
        }

        foreach (var SingleSprite in AllIslandNameSprites)
        {
            SingleSprite.enabled = IslandNameVisibility;
        }

        foreach (var SingleSprite in AllHelpSprites)
        {
            SingleSprite.enabled = HelpVisibility;
        }
    }
    //.
}
