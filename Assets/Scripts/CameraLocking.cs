using UnityEngine;

public class CameraLocking : MonoBehaviour
{
    public float TargetAspectRatio = 2f / 1f;
    Camera CurrentCamera;
    float Width = 2f;
    float Height = 1f;

    private void Start()
    {
        CurrentCamera = GetComponent<Camera>();
        ScreenRatioSetter();
    }

    //Updates camera lock if window changes size.
    private void Update()
    {
        if (Screen.width != Width || Screen.height != Height)
        {
            ScreenRatioSetter();
        }
    }
    //.

    //Edit screen size ratio.
    void ScreenRatioSetter()
    {
        float WindowAspectRatio = (float)Screen.width / (float)Screen.height;
        float ScreenSizesRatio = WindowAspectRatio / TargetAspectRatio;

        //Crops top and bottom if extra space.
        if (ScreenSizesRatio < 1f)
        {
            Width = 1.0f;
            Height = ScreenSizesRatio;
            float XPos = 0f;
            float YPos = (1f - Height) / 2f;

            CurrentCamera.rect = new Rect(XPos, YPos, Width, Height);
        }
        //.

        //Crops left and right if extra space.
        else
        {
            float InverseScreenSizesRatio = 1f / ScreenSizesRatio;
            Width = InverseScreenSizesRatio;
            Height = 1f;
            float XPos = (1f - Width) / 2f;
            float YPos = 0f;

            CurrentCamera.rect = new Rect(XPos, YPos, Width, Height);
        }
        //.
    }
    //.
}
