using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class beaker_switcher : MonoBehaviour
{
    public GameObject beaker1_btn_bg, beaker2_btn_bg, beaker3_btn_bg, beaker4_btn_bg, beaker1, beaker2, beaker3, beaker4, litmus, dropper, bound_hA, bound_hB, bound_hC, bound_hD, bound_hE, selector;
    public Color on_color = new Color32(0, 0, 255, 200);
    public Color off_color = new Color32(83, 84, 80, 255);
    public float default_litmus_Y_pos;
    public float duration;
    public int current_visible_beakers;
    void Start()
    {
        gameObject.GetComponent<Toggle>().onValueChanged.AddListener(delegate
        {
            toggle_beaker_value_changed();
        });
        default_litmus_Y_pos = litmus.transform.position.y;
        duration = 0.55f;
        current_visible_beakers = 0;
    }
    void Update()
    {
        if (beaker1.activeSelf) { 
            beaker1_btn_bg.GetComponent<Image>().color = on_color;
            // GameObject.FindWithTag("beaker1_btn").GetComponent<Toggle>().isOn = true;
            activateButton("beaker1_btn");
        } else {
            beaker1_btn_bg.GetComponent<Image>().color = off_color; 
        }
        if (beaker2.activeSelf) { 
            beaker2_btn_bg.GetComponent<Image>().color = on_color;
            //  GameObject.FindWithTag("beaker2_btn").GetComponent<Toggle>().isOn = true;
            activateButton("beaker2_btn");
        } else { beaker2_btn_bg.GetComponent<Image>().color = off_color; }
        if (beaker3.activeSelf) { beaker3_btn_bg.GetComponent<Image>().color = on_color;
            //  GameObject.FindWithTag("beaker3_btn").GetComponent<Toggle>().isOn = true;
            activateButton("beaker3_btn");
        } else { beaker3_btn_bg.GetComponent<Image>().color = off_color; }
        if (beaker4.activeSelf) { beaker4_btn_bg.GetComponent<Image>().color = on_color;
            //  GameObject.FindWithTag("beaker4_btn").GetComponent<Toggle>().isOn = true;
            activateButton("beaker4_btn");
        } else { beaker4_btn_bg.GetComponent<Image>().color = off_color; }
       
    }


    public void toggle_beaker_value_changed()
    {
        makeSureOneBeakerIsalwaysActive();

        if (gameObject.GetComponent<Toggle>().isOn)
        {

            if (gameObject.tag == "beaker1_btn") {
                beaker1_btn_bg.GetComponent<Image>().color = on_color;
                if(!(beaker2.activeSelf || beaker3.activeSelf || beaker4.activeSelf)) { StartCoroutine(targetBeaker1()); }
                beaker1.SetActive(true);
            }
            if (gameObject.tag == "beaker2_btn") { 
                beaker2_btn_bg.GetComponent<Image>().color = on_color;
                if (!(beaker1.activeSelf || beaker3.activeSelf || beaker4.activeSelf)) { StartCoroutine(targetBeaker2()); }
                beaker2.SetActive(true);
            }
            if (gameObject.tag == "beaker3_btn") {
                beaker3_btn_bg.GetComponent<Image>().color = on_color;
                if (!(beaker2.activeSelf || beaker2.activeSelf || beaker4.activeSelf)) { StartCoroutine(targetBeaker3()); }
                beaker3.SetActive(true);
            }
            if (gameObject.tag == "beaker4_btn") { 
                beaker4_btn_bg.GetComponent<Image>().color = on_color;
                if (!(beaker2.activeSelf || beaker3.activeSelf || beaker1.activeSelf)) { StartCoroutine(targetBeaker4()); }
                beaker4.SetActive(true);
            }

        }
        else
        {
            if (gameObject.tag == "beaker1_btn") { 
                beaker1_btn_bg.GetComponent<Image>().color = off_color;
                beaker1.SetActive(false);
                beaker_hidden("beaker1");
            }
            if (gameObject.tag == "beaker2_btn") { 
                beaker2_btn_bg.GetComponent<Image>().color = off_color;
                beaker2.SetActive(false);
                beaker_hidden("beaker2");
            }
            if (gameObject.tag == "beaker3_btn") { 
                beaker3_btn_bg.GetComponent<Image>().color = off_color;
                beaker3.SetActive(false);
                beaker_hidden("beaker3");
            }
            if (gameObject.tag == "beaker4_btn") { 
                beaker4_btn_bg.GetComponent<Image>().color = off_color;
                beaker4.SetActive(false);
                beaker_hidden("beaker4");
            }
        }
    }

    public void beaker_hidden(string hidden_beaker)
    {
        if (hidden_beaker == "beaker1") //target beakers 2, 3, 4
        {
            if (beaker2.activeSelf) {StartCoroutine(targetBeaker2());}
            else if (beaker3.activeSelf) { StartCoroutine(targetBeaker3()); }
            else if (beaker4.activeSelf){ StartCoroutine(targetBeaker4()); }
        }
        if (hidden_beaker == "beaker2") //target beakers 1, 3, 4
        {
            if (beaker1.activeSelf) { StartCoroutine(targetBeaker1()); }
            else if (beaker3.activeSelf) { StartCoroutine(targetBeaker3()); }
            else if (beaker4.activeSelf) { StartCoroutine(targetBeaker4()); }
        }
        if (hidden_beaker == "beaker3") //target beakers 1, 2, 4
        {
            if (beaker4.activeSelf) { StartCoroutine(targetBeaker4()); }
            else if (beaker2.activeSelf) { StartCoroutine(targetBeaker2()); }
            else if (beaker1.activeSelf) { StartCoroutine(targetBeaker1()); }
        }
        if (hidden_beaker == "beaker4") //target beakers 1, 2, 3
        {
            if (beaker3.activeSelf) { StartCoroutine(targetBeaker3()); }
            else if (beaker2.activeSelf) { StartCoroutine(targetBeaker2()); }
            else if (beaker1.activeSelf) { StartCoroutine(targetBeaker1()); }
        }
    }


    public void move_litmus_to_its_topmost_position()
    {
        litmus.transform.position = new Vector2(litmus.transform.position.x, default_litmus_Y_pos);
    }

    public IEnumerator targetBeaker1()
    {
        moveLitmusToTopFirst();//
        float time = 0;

        while (time < duration)
        {
           // litmus.transform.position = Vector3.Lerp(litmus.transform.position, new Vector3((bound_hA.transform.position.x + bound_hB.transform.position.x) / 2, litmus.transform.position.y, 0f), time / duration);
            dropper.transform.position = Vector3.Lerp(dropper.transform.position, new Vector3((bound_hA.transform.position.x-0.7f + bound_hB.transform.position.x) / 2, dropper.transform.position.y, 0f), time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        //litmus.transform.position = new Vector3((bound_hA.transform.position.x + bound_hB.transform.position.x) / 2, litmus.transform.position.y, 0f);
        dropper.transform.position = new Vector3((bound_hA.transform.position.x-0.7f + bound_hB.transform.position.x) / 2, dropper.transform.position.y, 0f);
        time = 0; //resetting

        selector.transform.SetParent(beaker1.transform, false);
        selectorNdropper_position_controller.current_selected_beaker = "hydrochloric_acid_beaker";
    }

    public IEnumerator targetBeaker2()
    {
         moveLitmusToTopFirst();//
        float time = 0;

        while (time<duration)
        {
           // litmus.transform.position = Vector3.Lerp(litmus.transform.position, new Vector3((bound_hB.transform.position.x + bound_hC.transform.position.x) / 2, litmus.transform.position.y, 0f), time / duration);
            dropper.transform.position = Vector3.Lerp(dropper.transform.position, new Vector3((bound_hB.transform.position.x - 0.7f + bound_hC.transform.position.x) / 2, dropper.transform.position.y, 0f), time / duration);

            time += Time.deltaTime;
            yield return null;
        }
        //litmus.transform.position = new Vector3((bound_hB.transform.position.x + bound_hC.transform.position.x) / 2, litmus.transform.position.y, 0f);
        dropper.transform.position = new Vector3((bound_hB.transform.position.x - 0.7f + bound_hC.transform.position.x) / 2, dropper.transform.position.y, 0f);

        time = 0; //resetting
         selector.transform.SetParent(beaker2.transform, false);
         selectorNdropper_position_controller.current_selected_beaker = "ethanoic_acid_beaker";
    }


    public IEnumerator targetBeaker3()
    {
        moveLitmusToTopFirst();//
        float time = 0;

        while (time < duration)
        {
            //litmus.transform.position = Vector3.Lerp(litmus.transform.position, new Vector3((bound_hC.transform.position.x + bound_hD.transform.position.x) / 2, litmus.transform.position.y, 0f), time / duration);
            dropper.transform.position = Vector3.Lerp(dropper.transform.position, new Vector3((bound_hC.transform.position.x - 0.7f + bound_hD.transform.position.x) / 2, dropper.transform.position.y, 0f), time / duration);

            time += Time.deltaTime;
            yield return null;
        }
        //litmus.transform.position = new Vector3((bound_hC.transform.position.x + bound_hD.transform.position.x) / 2, litmus.transform.position.y, 0f);
        dropper.transform.position = new Vector3((bound_hC.transform.position.x - 0.7f + bound_hD.transform.position.x) / 2, dropper.transform.position.y, 0f);

        time = 0; //resetting
        selector.transform.SetParent(beaker3.transform, false);
        selectorNdropper_position_controller.current_selected_beaker = "sodium_hydroxide_beaker";
    }

    public IEnumerator targetBeaker4()
    {
        moveLitmusToTopFirst();//
        float time = 0;

        while (time < duration)
        {
            //litmus.transform.position = Vector3.Lerp(litmus.transform.position, new Vector3((bound_hD.transform.position.x + bound_hE.transform.position.x) / 2, litmus.transform.position.y, 0f), time / duration);
            dropper.transform.position = Vector3.Lerp(dropper.transform.position, new Vector3((bound_hD.transform.position.x - 0.7f + bound_hE.transform.position.x) / 2, dropper.transform.position.y, 0f), time / duration);

            time += Time.deltaTime;
            yield return null;
        }
        //litmus.transform.position = new Vector3((bound_hD.transform.position.x + bound_hE.transform.position.x) / 2, litmus.transform.position.y, 0f);
        dropper.transform.position = new Vector3((bound_hD.transform.position.x - 0.7f + bound_hE.transform.position.x) / 2, dropper.transform.position.y, 0f);

        time = 0; //resetting
        selector.transform.SetParent(beaker4.transform, false);
        selectorNdropper_position_controller.current_selected_beaker = "ammonium_solution_beaker";
    }



    //functions
    public void activateButton(string btn_tag)
    {
        GameObject.FindWithTag(btn_tag).GetComponent<Toggle>().isOn = true;
    }

    public void makeSureOneBeakerIsalwaysActive()
    {
        Debug.Log("changed");
       // if (beaker1.activeSelf  && beaker2.activeSelf && beaker3.activeSelf){ GameObject.FindWithTag("beaker4_btn").GetComponent<Toggle>().interactable = true; } else { GameObject.FindWithTag("beaker4_btn").GetComponent<Toggle>().interactable = false; }
        //if (beaker2.activeSelf  && beaker3.activeSelf && beaker4.activeSelf){ GameObject.FindWithTag("beaker1_btn").GetComponent<Toggle>().interactable = true; } else { GameObject.FindWithTag("beaker1_btn").GetComponent<Toggle>().interactable = false; }
       // if (beaker1.activeSelf  && beaker4.activeSelf && beaker3.activeSelf){ GameObject.FindWithTag("beaker2_btn").GetComponent<Toggle>().interactable = true; } else { GameObject.FindWithTag("beaker2_btn").GetComponent<Toggle>().interactable = false; }
       // if (beaker1.activeSelf  && beaker2.activeSelf && beaker4.activeSelf){ GameObject.FindWithTag("beaker3_btn").GetComponent<Toggle>().interactable = true; } else { GameObject.FindWithTag("beaker3_btn").GetComponent<Toggle>().interactable = false; }
    }

    void moveLitmusToTopFirst()
    {
        litmus.transform.position = new Vector2(litmus.transform.position.x, switch_litmus.litmus_paper_default_pos.y); //accessing from 'switch_litmus' paper
    }
}
