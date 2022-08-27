using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class changeColor : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float time = 0;
    public float duration = 8;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    public void defaultColor()
    {
        if (true)
        {
            // StopCoroutine(changeColors());
            Debug.Log("Coroutine stopped");
            sprite.color = new Color32(255, 255, 255, 255);
        }

    }

    public void ColorChanged()
    {
        StartCoroutine(magCopperSulphate());
    }
    public void ColorChanged2()
    {
        StartCoroutine(magZincSulphate());
    }
    public void magIronTransition()
    {
        StartCoroutine(magIronSulphate());
    }

    IEnumerator magCopperSulphate()
    {
        Color startColor = sprite.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(200, 117, 37, 255);

        while (time < duration)
        {
            sprite.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.GetComponent<SpriteRenderer>().color = endColor;
    }
    IEnumerator magZincSulphate()
    {
        Color startColor = sprite.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(75, 71, 73, 255);

        while (time < duration)
        {
            sprite.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.GetComponent<SpriteRenderer>().color = endColor;
    }

    IEnumerator magIronSulphate()
    {
        Color startColor = sprite.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(84, 45, 11, 255);

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
