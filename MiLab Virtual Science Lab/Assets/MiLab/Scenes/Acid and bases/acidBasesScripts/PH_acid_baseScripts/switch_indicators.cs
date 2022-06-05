using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switch_indicators : MonoBehaviour
{
    public GameObject pippete, litmus_paper, litmus_paper_binary_choice, reset_btn, selector;
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
            reset_btn.SetActive(false);
            selector.SetActive(false);
        }
        else
        {   //for dropper
            litmus_paper.SetActive(false);
            litmus_paper_binary_choice.SetActive(false);
            pippete.SetActive(true);
            reset_btn.SetActive(true);
            selector.SetActive(true);
        }
    }
}
