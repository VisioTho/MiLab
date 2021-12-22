using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    public SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //StartCoroutine(changeColors());
        //sprite.color = new Color32(114, 111, 111, 255);
        // sprite.color = new Color32(255, 255, 255, 255);
    }


    // IEnumerator changeColors()
    // {
    //     if (true)
    //     {
    //         yield return new WaitForSeconds(5f);
    //         sprite.color = new Color32(114, 111, 111, 255);
    //     }
    //     else
    //     {
    //         StopCoroutine(changeColors());
    //         Debug.Log("Coroutine stopped");
    //         sprite.color = new Color32(255, 255, 255, 255);
    //     }

    // }

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
    public void ColorChanged3()
    {
        StartCoroutine(magIronSulphate());
    }

    IEnumerator magCopperSulphate()
    {
        if (true)
        {
            yield return new WaitForSeconds(2f);
            Debug.Log("magnesium color changed");
            sprite.color = new Color32(114, 111, 111, 255);

        }
    }

    IEnumerator magZincSulphate()
    {
        if (true)
        {
            yield return new WaitForSeconds(11f);
            Debug.Log("magnesium color changed");
            sprite.color = new Color32(157, 138, 138, 255);
        }
    }

    IEnumerator magIronSulphate()
    {
        if (true)
        {
            yield return new WaitForSeconds(22f);
            Debug.Log("magnesium color changed");
            sprite.color = new Color32(255, 172, 71, 255);
        }
    }



}
