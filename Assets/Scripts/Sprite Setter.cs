using UnityEngine;

public class SpriteSetter : MonoBehaviour
{
    //Gets the correct sprites ready.
    private Sprite[] ArmSprites = new Sprite[27];
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        //Gets the sprites from the spritesheet.
        ArmSprites = Resources.LoadAll<Sprite>("Semaphore_Spritesheet");
        //.

        //Gets sprite ready.
        spriteRenderer = GetComponent<SpriteRenderer>();
        //.
    }
    //.

    //Sets the sprite to inputted value.
    public void SetArms(string DesiredPose)
    {
        //Get desired pose's index in the list of arm sprites.
        int SpriteIndex = -1;

        for (int i = 0; i < ArmSprites.Length; i++)
        {
            if (ArmSprites[i].name == DesiredPose)
            {
                SpriteIndex = i;
                break;
            }
        }
        //.
  
        spriteRenderer.sprite = ArmSprites[SpriteIndex];
    }
    //.
}
