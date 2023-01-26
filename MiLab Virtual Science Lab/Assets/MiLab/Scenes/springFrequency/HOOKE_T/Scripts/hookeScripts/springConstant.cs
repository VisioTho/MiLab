using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class springConstant : MonoBehaviour
{

    /*
     * ATTACHED TO THE SPRING CONSTANT SLIDER 
     */

    public GameObject spring;
    public Sprite looseSpring, stiffSpring, stifferSpring;
    // Start is called before the first frame update
    void Start()
    {
       // gameObject.GetComponent<Slider>().value = Random.Range(1,4); //generating random constant on game launch
        
        constantChanged(); //in order to match randomly generated spring constant with the sprite to be used for that constant

        gameObject.GetComponent<Slider>().onValueChanged.AddListener((v) =>
        {
            constantChanged();
        });
    }

    void constantChanged()
    {
        if (gameObject.GetComponent<Slider>().value == 1)
        { //1 Loose
            spring.GetComponent<SpriteRenderer>().sprite = looseSpring;
            spring.transform.position = new Vector3(-0.5f, 1.4f, -0.9f);
            spring.transform.localScale = new Vector3(0.2f, 0.1f, 0.2f);
            spring.transform.localRotation = Quaternion.Euler(0f, 58.81f, 0f);
        }
        else if (gameObject.GetComponent<Slider>().value == 2)
        { //2 Stiff
            spring.GetComponent<SpriteRenderer>().sprite = stiffSpring;
            spring.transform.position = new Vector3(-0.5f, 1.4f, 33.1464f);
            spring.transform.localScale = new Vector3(0.1716145f, 0.09167814f, 0.2226454f);
            spring.transform.localRotation = Quaternion.Euler(0f, 58.81f, 0f);
        }
        else
        { //3 Stiffer
            spring.GetComponent<SpriteRenderer>().sprite = stifferSpring;
            spring.transform.position = new Vector3(-0.5f, 1.4f, 1.4f);
            spring.transform.localScale = new Vector3(0.1f, 0.1f, 0.2f);
            spring.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    void Update()
    {
        if (drag_n_drop.current_hanged_mass != null)
        {
           gameObject.GetComponent<Slider>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Slider>().interactable = true;
        }
    }
}
