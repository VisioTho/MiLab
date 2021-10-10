using UnityEngine;

public class DialManager : MonoBehaviour
{
    public SpriteRenderer multimeterSprite;
    public Sprite[] multimeterSprites;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void swapSrites(int n)
    {
        multimeterSprite.sprite = multimeterSprites[n];
    }
}
