using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class litmus_paper_controller : MonoBehaviour
{
    public bool isDipped = false;
    public float collider_onset_stretch_pointB_Y;
    public GameObject litmus_stretch_pointA, litmus_stretch_pointB, litmus_paper_b;
    public float time = 0;
    public float duration = 6;
    public Toggle litmus_paper_toggler;
    public string currentLitmusColor = "blue";
    public static string lastDippedInto = "none";
    public string[] liquid_tags = {"hydrochloric_acid", "ethanoic_acid", "vinegar", "milk", "tomato", "ammonium_solution", "sodium_hydroxide", "blood", "bleach"};
   //Start is called before the first frame update
    void Start()
    {
        currentLitmusColor = "blue";
        isDipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        float stretch_pointB_Y = litmus_stretch_pointB.transform.position.y;

    //Debug.Log("stretch_pointB_Y:" + stretch_pointB_Y + ", collider_onset_stretch_pointB_Y" + collider_onset_stretch_pointB_Y);

    //if (collider_onset_stretch_pointB_Y < 0) { isDipped = true; } else { isDipped = false; }

        if (isDipped)
        {
            if (collider_onset_stretch_pointB_Y > stretch_pointB_Y) {

                //updating the stretch point position
                collider_onset_stretch_pointB_Y = litmus_stretch_pointB.transform.position.y;

                /* float spritesize = litmus_paper_b.GetComponent<SpriteRenderer>().sprite.rect.width / litmus_paper_b.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
                  Vector2 scale = litmus_paper_b.transform.localScale;
                  scale.y = (litmus_stretch_pointA.transform.position.y - litmus_stretch_pointB.transform.position.y + 1.50f) / spritesize;//
                  litmus_paper_b.transform.localScale = scale;
                  litmus_paper_b.transform.position = new Vector2(litmus_paper_b.transform.position.x, (litmus_stretch_pointA.transform.position.y + litmus_stretch_pointB.transform.position.y) / 2);
                */

                float litmus_stretch_pointAYPos = litmus_stretch_pointA.transform.position.y;
                float litmus_stretch_pointBYPos = litmus_stretch_pointB.transform.position.y;
                Vector2 scale = litmus_paper_b.transform.localScale;
                scale.y = (litmus_stretch_pointAYPos - litmus_stretch_pointBYPos + 0.24f);
                litmus_paper_b.transform.localScale = scale;
                litmus_paper_b.transform.position = new Vector2(litmus_paper_b.transform.position.x, ((litmus_stretch_pointAYPos + litmus_stretch_pointBYPos) / 2));
            }
        }

        if (litmus_paper_toggler.isOn)
        {
            currentLitmusColor = "red";
        }
        else
        {
            currentLitmusColor = "blue";    
        }

        //preventing litmus toggler from being switched on
        if (isDipped) { litmus_paper_toggler.enabled = false; } else { litmus_paper_toggler.enabled = true; }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        string gOtag = collision.gameObject.tag;
        if (gOtag == "hydrochloric_acid" || gOtag == "ethanoic_acid" || gOtag == "vinegar" || gOtag == "milk" || gOtag == "tomato")//ACIDS
        {
            collider_onset_stretch_pointB_Y = litmus_stretch_pointB.transform.position.y;
            isDipped = true;
            if (currentLitmusColor == "blue")
            {
                //Debug.Log("Acid :: blue->red");
                if (lastDippedInto != gOtag)
                {
                    litmus_paper_b.GetComponent<SpriteRenderer>().color = new Color32(8, 135, 199, 255);
                    StartCoroutine(ToRedLitmusColorChangeMode());
                }

                if (currentLitmusColor == "red")
                {
                    litmus_paper_b.GetComponent<SpriteRenderer>().color = new Color32(239, 73, 26, 255);
                }  // reseting the color of the litmus in case it is already 'dyed'
               
                lastDippedInto = gOtag;
            }
        }


        if (gOtag == "ammonium_solution" || gOtag == "sodium_hydroxide" || gOtag == "blood" || gOtag == "bleach") //BASES
        {
            collider_onset_stretch_pointB_Y = litmus_stretch_pointB.transform.position.y;
            isDipped = true;
            if (currentLitmusColor == "red")
            {
                if (lastDippedInto != gOtag)
                {
                    // Debug.Log("Base :: red->blue");
                    litmus_paper_b.GetComponent<SpriteRenderer>().color = new Color32(239, 73, 26, 255);
                    StartCoroutine(ToBlueLitmusColorChangeMode());
                }
                if (currentLitmusColor == "blue")
                {
                    litmus_paper_b.GetComponent<SpriteRenderer>().color = new Color32(8, 135, 199, 255);
                } // reseting the color of the litmus in case it is already 'dyed'
                
                lastDippedInto = gOtag;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        string gOtag = collision.gameObject.tag;
        if (gOtag == "hydrochloric_acid" || gOtag == "ethanoic_acid" || gOtag == "vinegar" || gOtag == "milk" || gOtag == "tomato" || gOtag == "ammonium_solution" || gOtag == "sodium_hydroxide" || gOtag == "blood" || gOtag == "bleach")
        {
            //collider_onset_stretch_pointB_Y = (float) null;
            isDipped = false;
            //Debug.Log("undipped");
        }
    }

    IEnumerator ToBlueLitmusColorChangeMode()
    {
       
        Color startColor = litmus_paper_b.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(8, 135, 199, 255);

        while (time < duration)
        {
            litmus_paper_b.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            //disableLiquidCollider();
            yield return null;
        }
        resetTime();
        litmus_paper_b.GetComponent<SpriteRenderer>().color = endColor;

    }

    IEnumerator ToRedLitmusColorChangeMode()
    {
       
        Color startColor = litmus_paper_b.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(239, 73, 26, 255);
  
        while (time < duration)
        {
            litmus_paper_b.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
           
            yield return null;
        }
        resetTime();
        litmus_paper_b.GetComponent<SpriteRenderer>().color = endColor;
        //resetTag(initial_liquid_tag);
    }

    public void resetTime()
    {
        time = 0;
    }

}
