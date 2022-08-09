using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//should be attached to the dropper
public class colorChange : MonoBehaviour
{
    public GameObject breadSoakingAreaSmall, breadSoakingAreaLarge;
    Color breadColorChangeTo = new Color32(46, 50, 73, 255);
    public int breadDropCount, eggDropcount, tomatoDropCount, cassavaDropCount;
    float time = 0;

    void Start() {
        breadDropCount = eggDropcount = tomatoDropCount = cassavaDropCount = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        string gameObjectName = collision.gameObject.name;
       
        Debug.Log("food name: " + gameObject.name);
        if (gameObjectName == "drop_to_spawn(Clone)")
        {
            Destroy(collision.gameObject);
            if (gameObject.name == "egg")
            {
                Debug.Log("food egg " + gameObject.name);
            }
            else if (gameObject.name == "bread")
            {
                breadDropCount += 1;
                if (breadDropCount == 1)
                {
                    StartCoroutine(changeFoodColor(breadSoakingAreaSmall, breadColorChangeTo, 3));
                }
                if (breadDropCount == 2)
                {
                    StartCoroutine(changeFoodColor(breadSoakingAreaLarge, breadColorChangeTo, 6));
                }
            }
        }
    }

    IEnumerator changeFoodColor(GameObject spriteToChangeColor, Color colorTo, float changeDuration)
    {

        Color startColor = spriteToChangeColor.GetComponent<SpriteRenderer>().color;
        Color endColor = colorTo;
        float duration = changeDuration;

        while (time < duration)
        {
            spriteToChangeColor.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        //resetTime();
        spriteToChangeColor.GetComponent<SpriteRenderer>().color = endColor;
        time = 0;
    }
}