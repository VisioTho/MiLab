using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tips_controller : MonoBehaviour
{
    [SerializeField] public GameObject spring_tip, retort_stand_tip, meter_rule_tip, masses_tip;
    public bool tips_Visible = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void toggle_tips()
    {
        if (!tips_Visible)
        {
            spring_tip.SetActive(true);
            retort_stand_tip.SetActive(true);
            meter_rule_tip.SetActive(true);
            masses_tip.SetActive(true);

            tips_Visible = true;
        }
        else
        { 
            spring_tip.SetActive(false);
            retort_stand_tip.SetActive(false);
            meter_rule_tip.SetActive(false);
            masses_tip.SetActive(false);

            tips_Visible = false;
        }
    }
}
