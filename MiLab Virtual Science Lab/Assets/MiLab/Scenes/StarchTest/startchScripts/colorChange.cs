using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//should be attached to the dropper
public class ColorChange : MonoBehaviour
{
    public GameObject breadSoakingAreaSmall, breadSoakingAreaLarge, eggSoakingAreaSmall, eggSoakingAreaLarge, tomatoSoakingAreaSmall, tomatoSoakingAreaLarge, cassavaSoakingAreaSmall, cassavaSoakingAreaLarge, potatoSoakingAreaSmall, potatoSoakingAreaLarge;
    public GameObject ResetButton;
    Color starchPresentColor = new Color32(46, 50, 73, 100);
    Color starchAbsentColor = new Color32(238, 159, 46, 100);
    public int breadDropCount, eggDropCount, tomatoDropCount, cassavaDropCount, potatoDropCount;
    float time = 0;

    void Start() {
        breadDropCount = eggDropCount = tomatoDropCount = cassavaDropCount = potatoDropCount = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        string gameObjectName = collision.gameObject.name;
    
        if (gameObjectName == "droplet(Clone)")
        {
            Destroy(collision.gameObject);
            if (gameObject.name == "egg")
            {
                eggDropCount+=1;
                if (eggDropCount == 1)
                {
                    StartCoroutine(ChangeFoodColor(eggSoakingAreaSmall, starchPresentColor, 0.5f));
                }
                if (eggDropCount == 2)
                {
                    StartCoroutine(ChangeFoodColor(eggSoakingAreaLarge, starchPresentColor, 0.7f));
                }
            }
            else if (gameObject.name == "bread")
            {
                breadDropCount += 1;
                if (breadDropCount == 1)
                {
                    StartCoroutine(ChangeFoodColor(breadSoakingAreaSmall, starchPresentColor, 0.5f));
                }
                if (breadDropCount == 2)
                {
                    StartCoroutine(ChangeFoodColor(breadSoakingAreaLarge, starchPresentColor, 0.7f));
                }
            }else if (gameObject.name == "tomato")
            {
                tomatoDropCount += 1;
                if (tomatoDropCount == 1)
                {
                    StartCoroutine(ChangeFoodColor(tomatoSoakingAreaSmall, starchAbsentColor, 0.5f));
                }
                if (tomatoDropCount == 2)
                {
                    StartCoroutine(ChangeFoodColor(tomatoSoakingAreaLarge, starchAbsentColor, 0.7f));
                }
            }
            else if (gameObject.name == "cassava")
            {
                cassavaDropCount += 1;
                if (cassavaDropCount == 1)
                {
                    StartCoroutine(ChangeFoodColor(cassavaSoakingAreaSmall, starchPresentColor, 0.5f));
                }
                if (cassavaDropCount == 2)
                {
                    StartCoroutine(ChangeFoodColor(cassavaSoakingAreaLarge, starchPresentColor, 0.7f));
                }
            }else if (gameObject.name == "irish_potato")
            {
                potatoDropCount += 1;
                if (potatoDropCount == 1)
                {
                    StartCoroutine(ChangeFoodColor(potatoSoakingAreaSmall, starchPresentColor, 0.5f));
                }
                if (potatoDropCount == 2)
                {
                    StartCoroutine(ChangeFoodColor(potatoSoakingAreaLarge, starchPresentColor, 0.7f));
                }
            }
        }
    }

    IEnumerator ChangeFoodColor(GameObject spriteToChangeColor, Color colorTo, float changeDuration)
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