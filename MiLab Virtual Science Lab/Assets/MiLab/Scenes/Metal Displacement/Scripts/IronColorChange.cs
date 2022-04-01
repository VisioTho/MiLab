using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronColorChange : MonoBehaviour
{
    public SpriteRenderer sprite;

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
            sprite.color = new Color32(255, 255, 255, 255);
        }

    }
    public void ironColorChanged()
    {
        StartCoroutine(ironCopperSulphate());
    }

    IEnumerator ironCopperSulphate()
    {
        if (true)
        {
            yield return new WaitForSeconds(15f);
            Debug.Log("iron color changed");
            sprite.color = new Color32(255, 172, 78, 255);
        }
    }


}
