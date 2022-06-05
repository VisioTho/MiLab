using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class customSolution_controller : MonoBehaviour
{
    public Toggle custom_solution_toggler;
    public float litmus_paperYpos;
    public Toggle[] beaker_toggle_buttons;
    public GameObject hydrochloric_acid_beaker, sodium_hydroxide_beaker, ammonium_solution_beaker, pippete, litmus_paper, ethanoic_acid_beaker, ethanoic_acid_label, ethanoic_acid;
    //public static Hashtable viewed_beakers = new Hashtable();//to be fetched from beaker_switcher;
    public TMP_Dropdown solutions_dd;
    public bool bk1_should_appear_by_default, bk2_should_appear_by_default, bk3_should_appear_by_default, bk4_should_appear_by_default;
    // Start is called before the first frame update
    void Start()
    {
        litmus_paperYpos = litmus_paper.transform.position.y;
        custom_solution_toggler.onValueChanged.AddListener(delegate
        {
            custom_solu_value_changedToggle();
        });
       
        bk1_should_appear_by_default = true;
        bk2_should_appear_by_default = true;
        bk3_should_appear_by_default = false;
        bk4_should_appear_by_default = false;
    }
   
    void Update()
    {
        //viewed_beakers = beaker_switcher.viewed_beakers;
        if (!custom_solution_toggler.isOn)
        {
              ethanoic_acid.tag = "ethanoic_acid";
              ethanoic_acid_label.SetActive(true);
         }
    }

    public void custom_solu_value_changedToggle()
    {
        
        if (custom_solution_toggler.isOn)
        {
            solutions_dd.value = 0;
            //   resetController.current_selected_beaker = "ethanoic_acid_beaker";//making ethanoic acid beaker the current selected beaker
            StartCoroutine(LerpPosition(new Vector3(ethanoic_acid_beaker.transform.position.x, pippete.transform.position.y, 0f), 2f));
          //  StartCoroutine(Camera.main.GetComponent<selectorNdropper_position_controller>().LerpPosition(new Vector3(ethanoic_acid_beaker.transform.position.x, pippete.transform.position.y, 0f), 2f));

            foreach (Toggle beakerBTN in beaker_toggle_buttons)
             {
                 string btn_tag = beakerBTN.tag;
                 if (btn_tag == "beaker1_btn" && beakerBTN.isOn) { bk1_should_appear_by_default = true; } //else { bk1_should_appear_by_default = false; }
                 if (btn_tag == "beaker2_btn" && beakerBTN.isOn) { bk2_should_appear_by_default = true; } //else { bk2_should_appear_by_default = false; }
                 if (btn_tag == "beaker3_btn" && beakerBTN.isOn) { bk3_should_appear_by_default = true; } //else { bk3_should_appear_by_default = false; }
                 if (btn_tag == "beaker4_btn" && beakerBTN.isOn) { bk4_should_appear_by_default = true; } //else { bk4_should_appear_by_default = false; }
                beakerBTN.interactable = false;
             }


            hydrochloric_acid_beaker.SetActive(false);
            sodium_hydroxide_beaker.SetActive(false);
            ammonium_solution_beaker.SetActive(false);
            ethanoic_acid_label.SetActive(false);

            pippete.transform.position = new Vector2(-3.5f, pippete.transform.position.y);
            litmus_paper.transform.position = new Vector2(ethanoic_acid_beaker.transform.position.x, litmus_paperYpos);

            foreach(Toggle beaker_tg_btn in beaker_toggle_buttons)//turning off all the beaker toggle buttons
            {
                beaker_tg_btn.isOn = false;
            }
            ethanoic_acid_beaker.SetActive(true);

        }
        else
        {

            drop_controller.ethanoic_acid_drops = 0;
            //updating viewed beakers Hashtag
            if (bk1_should_appear_by_default){ hydrochloric_acid_beaker.SetActive(true); } else { hydrochloric_acid_beaker.SetActive(false);}
            if (bk2_should_appear_by_default) { ethanoic_acid_label.SetActive(true); } else { ethanoic_acid_label.SetActive(false);}
            if (bk3_should_appear_by_default) { sodium_hydroxide_beaker.SetActive(true); } else { sodium_hydroxide_beaker.SetActive(false);}
            if (bk4_should_appear_by_default) { ammonium_solution_beaker.SetActive(true); } else { ammonium_solution_beaker.SetActive(false);}


            bk1_should_appear_by_default = bk2_should_appear_by_default = bk3_should_appear_by_default = bk4_should_appear_by_default = false;


            //sodium_hydroxide_beaker.SetActive(true);
            // ammonium_solution_beaker.SetActive(true);
            // ethanoic_acid_label.SetActive(true);


            foreach (Toggle beakerBTN in beaker_toggle_buttons)
            {
                beakerBTN.interactable = true;
            }
            }
    }
    public IEnumerator LerpPosition(Vector3 targetPos, float duration)
    {
        float time = 0;

        while (time < duration)
        {
            pippete.transform.position = Vector3.Lerp(pippete.transform.position, new Vector3(targetPos.x - 0.5f, targetPos.y, 0f), time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        pippete.transform.position = new Vector3(targetPos.x - 0.5f, targetPos.y, 0f);
        time = 0; //reseting
    }
}
