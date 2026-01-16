using UnityEngine;

public class SpriteSetter : MonoBehaviour
{
    //Gets the correct sprites ready.
    private Sprite[] ArmSprites = new Sprite[27];
    private Sprite[] LetterSprites = new Sprite[26];
    private Sprite[] HeartSprites = new Sprite[4];
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        //Gets the sprites from the spritesheets.
        ArmSprites = Resources.LoadAll<Sprite>("Semaphore_Spritesheet");
        LetterSprites = Resources.LoadAll<Sprite>("Alphabet_Spritesheet");
        HeartSprites = Resources.LoadAll<Sprite>("Hearts_Spritesheet");
        //.

        //Gets sprite ready.
        spriteRenderer = GetComponent<SpriteRenderer>();
        //.
    }
    //.

    //Sets the sprite to inputted arm value.
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

    //Sets the sprite to inputted letter value.
    public void SetLetter(string DesiredLetter)
    {
        //Get desired pose's index in the list of letter sprites.
        int SpriteIndex = -1;
        for (int i = 0; i < LetterSprites.Length; i++)
        {
            if (LetterSprites[i].name == DesiredLetter)
            {
                SpriteIndex = i;
                break;
            }
        }
        //.

        spriteRenderer.sprite = LetterSprites[SpriteIndex];
    }
    //.

    //Sets the sprite to inputted hearts value.
    public void SetHearts(int DesiredHearts)
    {
        spriteRenderer.sprite = HeartSprites[DesiredHearts];
    }
    //.
}
