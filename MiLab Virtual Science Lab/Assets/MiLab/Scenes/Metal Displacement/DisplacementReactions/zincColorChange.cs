using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zincColorChange : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float time = 0;
    public float duration = 8;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void defaultColor()
    {
        if (true)
        {
            // StopCoroutine(changeColors());
            Debug.Log("Coroutine stopped");
            sprite.color = new Color32(183, 179, 179, 195);
        }

    }

    public void zincColorChanged()
    {
        StartCoroutine(zincTransition());
    }
    public void zincColorChanged2()
    {
        StartCoroutine(zincIronSulphate());
    }

    IEnumerator zincTransition()
    {
        Color startColor = sprite.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(70, 65, 65, 255);

        while (time < duration)
        {
            sprite.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.GetComponent<SpriteRenderer>().color = endColor;
    }

    IEnumerator zincIronSulphate()
    {
        Color startColor = sprite.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(135, 135, 135, 255);

        while (time < duration)
        {
            sprite.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.GetComponent<SpriteRenderer>().color = endColor;
    }

    public void resetTime()
    {
        time = 0;
        StopAllCoroutines();
    }

}

