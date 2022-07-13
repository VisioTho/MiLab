using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceIndicators : MonoBehaviour
{
    public GameObject oppositeIndicator;

    public Sprite d1DistanceSprite;
    public Sprite d2DistanceSprite;
    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "LeftDistanceIndicator")
            transform.position = new Vector2(MassManager.massHungOnLeft.transform.position.x, transform.position.y);
        else if (gameObject.name == "RightDistanceIndicator")
            transform.position = new Vector2(MassManager.massHungOnRight.transform.position.x, transform.position.y);

        AssignDistanceSprites();

    }

    private void AssignDistanceSprites()
    {
        if (!MassManager.lMassIsReleased && MassManager.RMassIsReleased)
        {
            if (gameObject.name == "LeftDistanceIndicator")
                gameObject.GetComponent<SpriteRenderer>().sprite = d1DistanceSprite;
            else if (gameObject.name == "RightDistanceIndicator")
                gameObject.GetComponent<SpriteRenderer>().sprite = d1DistanceSprite;
            oppositeIndicator.GetComponent<SpriteRenderer>().sprite = d2DistanceSprite;

        }
        else if (!MassManager.RMassIsReleased && MassManager.lMassIsReleased)
        {
            if (gameObject.name == "LeftDistanceIndicator")
                gameObject.GetComponent<SpriteRenderer>().sprite = d1DistanceSprite;
            else if (gameObject.name == "RightDistanceIndicator")
                gameObject.GetComponent<SpriteRenderer>().sprite = d1DistanceSprite;
            oppositeIndicator.GetComponent<SpriteRenderer>().sprite = d2DistanceSprite;
        }

       
    }
}
