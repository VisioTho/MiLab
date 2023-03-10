using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//should be attached to the dropper
public class colorChange : MonoBehaviour
{
    public GameObject breadSoakingAreaSmall, breadSoakingAreaLarge, eggSoakingAreaSmall, eggSoakingAreaLarge, tomatoSoakingAreaSmall, tomatoSoakingAreaLarge, cassavaSoakingAreaSmall, cassavaSoakingAreaLarge, potatoSoakingAreaSmall, potatoSoakingAreaLarge;
    public GameObject ResetButton;
    Color starchPresentColor = new Color32(46, 50, 73, 100);
    Color starchAbsentColor = new Color32(238, 159, 46, 100);
    public static int breadDropCount, eggDropCount, tomatoDropCount, cassavaDropCount, potatoDropCount;
    float time = 0;

    void Start() {
        breadDropCount = eggDropCount = tomatoDropCount = cassavaDropCount = potatoDropCount = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        string gameObjectName = collision.gameObject.name;
    
        if (gameObjectName == "drop_to_spawn(Clone)")
        {
            Destroy(collision.gameObject);
            if (gameObject.name == "egg")
            {
                eggDropCount+=1;
                if (eggDropCount == 1)
                {
                    StartCoroutine(changeFoodColor(eggSoakingAreaSmall, starchPresentColor, 0.5f));
                }
                if (eggDropCount == 2)
                {
                    StartCoroutine(changeFoodColor(eggSoakingAreaLarge, starchPresentColor, 0.7f));
                }
            }
            else if (gameObject.name == "bread")
            {
                breadDropCount += 1;
                if (breadDropCount == 1)
                {
                    StartCoroutine(changeFoodColor(breadSoakingAreaSmall, starchPresentColor, 0.5f));
                }
                if (breadDropCount == 2)
                {
                    StartCoroutine(changeFoodColor(breadSoakingAreaLarge, starchPresentColor, 0.7f));
                }
            }else if (gameObject.name == "tomato")
            {
                tomatoDropCount += 1;
                if (tomatoDropCount == 1)
                {
                    StartCoroutine(changeFoodColor(tomatoSoakingAreaSmall, starchAbsentColor, 0.5f));
                }
                if (tomatoDropCount == 2)
                {
                    StartCoroutine(changeFoodColor(tomatoSoakingAreaLarge, starchAbsentColor, 0.7f));
                }
            }
            else if (gameObject.name == "cassava")
            {
                cassavaDropCount += 1;
                if (cassavaDropCount == 1)
                {
                    StartCoroutine(changeFoodColor(cassavaSoakingAreaSmall, starchPresentColor, 0.5f));
                }
                if (cassavaDropCount == 2)
                {
                    StartCoroutine(changeFoodColor(cassavaSoakingAreaLarge, starchPresentColor, 0.7f));
                }
            }else if (gameObject.name == "irish_potato")
            {
                potatoDropCount += 1;
                if (potatoDropCount == 1)
                {
                    StartCoroutine(changeFoodColor(potatoSoakingAreaSmall, starchPresentColor, 0.5f));
                }
                if (potatoDropCount == 2)
                {
                    StartCoroutine(changeFoodColor(potatoSoakingAreaLarge, starchPresentColor, 0.7f));
                }
            }
        }
    }

    IEnumerator changeFoodColor(GameObject spriteToChangeColor, Color colorTo, float changeDuration)
    {
        ResetButton.GetComponent<Button>().interactable = false;
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
        ResetButton.GetComponent<Button>().interactable = true;
    }
}