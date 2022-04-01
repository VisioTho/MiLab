using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectorNdropper_position_controller : MonoBehaviour
{
    public GameObject dropper, selector;
    public static string current_selected_beaker;
    public float lerpDuration;
    public static Vector3 hydrochloric_acid_beaker_position;

    //public IEnumerator LerpPosition;
    // Start is called before the first frame update
    void Start()
    {
        current_selected_beaker = "hydrochloric_acid_beaker";
        lerpDuration = 0.55f;
        // hydrochloric_acid_beaker_position = default_positions_PH.hydrochloric_acid_beaker_position;
        // selector.transform.position = hydrochloric_acid_beaker_position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseDown()
    {
        //if (gameObject.tag != current_selected_beaker)
        // {
        //}
        //LerpPosition();
        string gObjTag = gameObject.tag;

        if (gObjTag == "ammonium_solution_beaker" || gObjTag== "sodium_hydroxide_beaker" || gObjTag == "ethanoic_acid_beaker" || gObjTag == "hydrochloric_acid_beaker")
        {
           current_selected_beaker = gObjTag;
           // Debug.Log(gObjTag);
           StopAllCoroutines();
           StartCoroutine(LerpPosition(new Vector3(gameObject.transform.position.x, dropper.transform.position.y, 0f), lerpDuration));
           //selector.transform.position = gameObject.transform.position;
           selector.transform.SetParent ( gameObject.transform, false);
        }
       
    }

    public IEnumerator LerpPosition(Vector3 targetPos, float duration)
    {
        float time = 0;

        while (time < duration)
        {
            dropper.transform.position = Vector3.Lerp(dropper.transform.position, new Vector3(targetPos.x - 0.5f, targetPos.y, 0f), time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        dropper.transform.position =new Vector3(targetPos.x-0.5f, targetPos.y, 0f);
        time = 0; //reseting
    }
}
