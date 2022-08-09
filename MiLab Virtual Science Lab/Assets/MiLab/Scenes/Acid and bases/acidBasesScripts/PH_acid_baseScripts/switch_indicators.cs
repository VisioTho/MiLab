using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switch_indicators : MonoBehaviour
{
    public GameObject pippete, litmus_paper, litmus_paper_binary_choice, beaker_reset_button, litmus_reset_button, legend_panel, ph_scale_chat, selector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Toggle>().isOn)//for litmus paper
        {
            litmus_paper.SetActive(true);
            litmus_paper_binary_choice.SetActive(true);
            pippete.SetActive(false);
            beaker_reset_button.SetActive(false);
            selector.SetActive(false);
            ph_scale_chat.SetActive(false);
            legend_panel.SetActive(true);
            litmus_reset_button.SetActive(true);
        }
        else
        {   //for dropper
            litmus_paper.SetActive(false);
            litmus_paper_binary_choice.SetActive(false);
            pippete.SetActive(true);
            beaker_reset_button.SetActive(true);
            selector.SetActive(true);
            ph_scale_chat.SetActive(true);
            legend_panel.SetActive(false);
            litmus_reset_button.SetActive(false);
        }
    }
}
