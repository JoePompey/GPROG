using UnityEngine;

public class SpriteSetter : MonoBehaviour
{
    //Gets the correct sprites ready.
    private Sprite[] ArmSprites = new Sprite[27];
    private Sprite[] LetterSprites = new Sprite[26];
    private Sprite[] HeartSprites = new Sprite[4];
    private Sprite[] EmotionSprites = new Sprite[2];
    private Sprite[] NumberSprites = new Sprite[10];
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        //Gets the sprites from the spritesheets.
        ArmSprites = Resources.LoadAll<Sprite>("Semaphore_Spritesheet");
        LetterSprites = Resources.LoadAll<Sprite>("Alphabet_Spritesheet");
        HeartSprites = Resources.LoadAll<Sprite>("Hearts_Spritesheet");
        EmotionSprites = Resources.LoadAll<Sprite>("Emotions");
        NumberSprites = Resources.LoadAll<Sprite>("Number_Spritesheet");
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

        spriteRenderer.enabled = true;
        spriteRenderer.sprite = LetterSprites[SpriteIndex];
    }
    //.

    //Sets the sprite to inputted hearts value.
    public void SetHearts(int DesiredHearts)
    {
        spriteRenderer.sprite = HeartSprites[DesiredHearts];
    }
    //.

    //Sets the sprite to correct emotion.
    //-- 0 is Angry, 1 is Happy.
    public void SetEmotion(int DesiredEmotion, bool EmotionVisible)
    {
        spriteRenderer.enabled = EmotionVisible;
        spriteRenderer.sprite = EmotionSprites[DesiredEmotion];
    }
    //.

    //Sets the sprite to correct number.
    public void SetNumber(int Number)
    {
        spriteRenderer.sprite = NumberSprites[Number];
    }
    //.
}
