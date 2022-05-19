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
  public Vector3 initAnodePos, initCathodePos;
  public float lerpDuration;

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

        initAnodePos = GameObject.FindWithTag("anode").transform.position;
        initCathodePos = GameObject.FindWithTag("cathode").transform.position;
        lerpDuration = 2;
    }


    public void valueHasChanged(TMP_Dropdown sender)
    {
        switch_is_on = false;
        StartCoroutine(LerpPositionAnode(initAnodePos, lerpDuration));
        StartCoroutine(LerpPositionCathode(initCathodePos, lerpDuration));
       // GameObject.FindWithTag("anode").transform.position = initAnodePos;
       // GameObject.FindWithTag("cathode").transform.position = initCathodePos;
    }

   void Update(){

        
        if (switch_is_on){
        switcher.GetComponent<SpriteRenderer>().sprite=switch_on;
      } else{
        switcher.GetComponent<SpriteRenderer>().sprite=switch_off;
      }
   }



     public IEnumerator LerpPositionAnode(Vector3 targetPos, float duration)
     {
         float time = 0;

         while (time < duration)
         {
             GameObject.FindWithTag("anode").transform.position = Vector3.Lerp(GameObject.FindWithTag("anode").transform.position, new Vector3(targetPos.x , targetPos.y, 0f), time / duration);
             time += Time.deltaTime;
             yield return null;
         }
         GameObject.FindWithTag("anode").transform.position = new Vector3(targetPos.x, targetPos.y, 0f);
         time = 0; //reseting
     }

    public IEnumerator LerpPositionCathode(Vector3 targetPos, float duration)
    {
        float time = 0;

        while (time < duration)
        {
            GameObject.FindWithTag("cathode").transform.position = Vector3.Lerp(GameObject.FindWithTag("cathode").transform.position, new Vector3(targetPos.x, targetPos.y, 0f), time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        GameObject.FindWithTag("cathode").transform.position = new Vector3(targetPos.x, targetPos.y, 0f);
        time = 0; //reseting
    }
}
