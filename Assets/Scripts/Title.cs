using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Title : MonoBehaviour
{
    public InputActionAsset Controls;
    private InputActionMap ControlMap;
    //Gets controls ready.
    private void Start()
    {
        ControlMap = Controls.FindActionMap("GameControls");
    }
    //.

    //Changes to the ActiveGame scene when you press Enter.
    void Update()
    {
        if (ControlMap.FindAction("Enter").WasPressedThisFrame())
        {
            SceneManager.LoadScene("ActiveGame");
        }
    }
    //.
}
