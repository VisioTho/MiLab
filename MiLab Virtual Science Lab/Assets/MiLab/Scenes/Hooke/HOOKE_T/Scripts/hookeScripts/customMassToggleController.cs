using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customMassToggleController : MonoBehaviour
{
    public GameObject custom_mass, spring, load_100;//gettting only position values from spring and load_100
    public static Vector3 spring_tagertPos, custom_mass_hidden_pos, custom_mass_visible_pos;
    public float lerpingDuration;
   //Start is called before the first frame update
    void Start()
    {
       // Debug.Log("Toggle toggled");
        //custom_mass_hidden_pos = custom_mass.transform.position;
        gameObject.GetComponent<Toggle>().onValueChanged.AddListener(delegate
        {
            showHideCustomMass();
        });

        custom_mass_visible_pos = new Vector3(spring.transform.position.x, load_100.transform.position.y, 0f);
        lerpingDuration = 0.6f;
        custom_mass_hidden_pos = custom_mass.transform.position;
    }

   //Update is called once per frame
   public void showHideCustomMass()
    {

       // Debug.Log("Toggle toggled");

        if (gameObject.GetComponent<Toggle>().isOn)
        {
            //LerpPositionShow(custom_mass_visible_pos, lerpingDuration);
           // Debug.Log("Toggle toggled on");
            custom_mass.transform.position = custom_mass_visible_pos;
        }
        else
        {
           // Debug.Log("Toggle toggled off");
            // LerpPositionHide(custom_mass_hidden_pos, lerpingDuration);
            custom_mass.transform.position = custom_mass_hidden_pos;
        }
    }


    //showing custom mass
    //
    public IEnumerator LerpPositionShow(Vector3 targetPos, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            custom_mass.transform.position = Vector3.Lerp(custom_mass_hidden_pos, targetPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        custom_mass.transform.position = targetPos;
        time = 0; //reseting
    }



    //hiding custom mass
   /* public IEnumerator LerpPositionHide(Vector3 targetPos, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            custom_mass.transform.position = Vector3.Lerp(custom_mass_visible_pos, targetPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        custom_mass.transform.position = targetPos;
        time = 0; //reseting
    }*/
}
