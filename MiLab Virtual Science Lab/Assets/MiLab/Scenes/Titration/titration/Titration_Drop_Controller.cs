using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Titration_Drop_Controller : MonoBehaviour
{

    public LiquidControllerScript liquidControllerScript;
    public GameObject sodium_hydroxide;
    public static int sodium_hydroxide_drops;
    public float time = 0;
    public float duration = 3;


    // Start is called before the first frame update
    void Start()
    {
        sodium_hydroxide_drops = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "drop_to_spawn")
        {
            //Debug.Log("dropped");
            Destroy(collision.gameObject);

            //incrementing number of drops in a liquid
            if (gameObject.tag == "sodium_hydroxide")
            {
                sodium_hydroxide_drops++;
                if (sodium_hydroxide_drops == 2 && liquidControllerScript.indicatorVariation.value == 0)
                {
                    StartCoroutine(sodium_hydroxide_color_changer());
                    liquidControllerScript.pipetteDrop = true;
                    liquidControllerScript.resetButton.interactable = true;
                }
                else if (sodium_hydroxide_drops == 2 && liquidControllerScript.indicatorVariation.value == 1)
                {

                    StartCoroutine(MethylOrangeColorTransition());
                    liquidControllerScript.pipetteDrop = true;
                    liquidControllerScript.resetButton.interactable = true;
                }
                else if (sodium_hydroxide_drops > 0 && (liquidControllerScript.indicatorVariation.value == 0 || liquidControllerScript.indicatorVariation.value == 1))
                {
                    liquidControllerScript.resetButton.interactable = true;
                    liquidControllerScript.indicatorVariation.interactable = false;
                    liquidControllerScript.analyteVariation.interactable = false;
                }
            }

        }
    }

    IEnumerator sodium_hydroxide_color_changer()
    {
        Color startColor = sodium_hydroxide.GetComponent<Image>().color;
        Color endColor = new Color32(251, 0, 253, 243);

        while (time < duration)
        {
            sodium_hydroxide.GetComponent<Image>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;

        }
        resetTime();
        sodium_hydroxide.GetComponent<Image>().color = endColor;
    }

    IEnumerator MethylOrangeColorTransition()
    {
        Color startColor = sodium_hydroxide.GetComponent<Image>().color;
        Color endColor = new Color32(237, 217, 40, 255);

        while (time < duration)
        {
            sodium_hydroxide.GetComponent<Image>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;

        }
        resetTime();
        sodium_hydroxide.GetComponent<Image>().color = endColor;
    }

    IEnumerator ColorReset()
    {
        Color startColor = sodium_hydroxide.GetComponent<Image>().color;
        Color endColor = new Color32(234, 234, 234, 150);

        while (time < duration)
        {
            sodium_hydroxide.GetComponent<Image>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;

        }
        resetTime();
        sodium_hydroxide.GetComponent<Image>().color = endColor;
    }

    public void resetTime()
    {
        time = 0;
    }

    public void resetDrops()
    {
        liquidControllerScript.pipetteDrop = false;
        StartCoroutine(ColorReset());
        sodium_hydroxide_drops = 0;
    }
}
