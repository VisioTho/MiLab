using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zincColorChange : MonoBehaviour
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

    public void zincColorChanged()
    {
        StartCoroutine(zincCopperSulphate());
    }
    public void zincColorChanged2()
    {
        StartCoroutine(zincIronSulphate());
    }

    IEnumerator zincCopperSulphate()
    {
        if (true)
        {
            yield return new WaitForSeconds(22f);
            Debug.Log("zinc color changed");
            sprite.color = new Color32(70, 65, 65, 255);
        }
    }

    IEnumerator zincIronSulphate()
    {
        if (true)
        {
            yield return new WaitForSeconds(29f);
            Debug.Log("zinc color changed");
            sprite.color = new Color32(135, 135, 135, 255);
        }
    }

}

