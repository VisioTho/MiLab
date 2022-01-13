using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class switch_controller : MonoBehaviour
{
  public Sprite switch_on, switch_off;
  public GameObject bulb, switcher;
  public static bool switch_is_on=false;
  public Light bulb_light;
  public TMP_Dropdown solutions_dd;

    public void OnMouseDown(){
    if(switch_is_on){
       switch_is_on=false;
    }else{
        switch_is_on=true;
    }
   }
    void Start()
    {
       solutions_dd.onValueChanged.AddListener(delegate {
            valueHasChanged(solutions_dd);
        });
    }


    public void valueHasChanged(TMP_Dropdown sender)
    {
        switch_is_on = false;
    }

   void Update(){

        
        if (switch_is_on){
        switcher.GetComponent<SpriteRenderer>().sprite=switch_on;
      } else{
        switcher.GetComponent<SpriteRenderer>().sprite=switch_off;
      }
   }
 }
