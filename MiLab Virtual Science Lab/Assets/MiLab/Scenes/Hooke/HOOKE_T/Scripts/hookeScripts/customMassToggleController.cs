using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class customMassToggleController : MonoBehaviour
{
    public GameObject custom_mass, spring, load_100;//gettting only position values from spring and load_100
    public static Vector3 spring_tagertPos, custom_mass_hidden_pos, custom_mass_visible_pos;
    public float lerpingDuration;
   //Start is called before the first frame update
    void Start()
    {
         // Debug.Log("Toggle toggled");
        // custom_mass_hidden_pos = custom_mass.transform.position;
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
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            custom_mass.transform.DOMove(custom_mass_visible_pos, 1);
        }
        else
        {
            custom_mass.transform.DOMove(custom_mass_hidden_pos, 1);
        }
    }
}
