using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TranslationSheet : MonoBehaviour
{
    private SpriteRenderer[] AllSprites;
    private bool Visible = false;

    public InputActionAsset controls;
    private InputActionMap ArmControls;

    void Start()
    {
        ArmControls = controls.FindActionMap("ArmMovements");
        ArmControls.Enable();
        
        AllSprites = GetComponentsInChildren<SpriteRenderer>();
        SpriteVisibility(false);
    }

    //Controls for toggling visibility.
    private void Update()
    {
        if (ArmControls.FindAction("OpenTranslations").WasPressedThisFrame())
        {
            Visible = !Visible;
            SpriteVisibility(Visible);
        }
    }
    //.

    //Enable/disable sheet visibility.
    void SpriteVisibility(bool Visibility)
    {
        foreach (var SingleSprite in AllSprites)
        {
            SingleSprite.enabled = Visibility;
        }
    }
    //.
}
