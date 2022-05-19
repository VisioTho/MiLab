using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ammeter_reading : MonoBehaviour
{
    public TextMeshProUGUI ammeter_readingT;
    public static float ammeter_final_readingA;  //to be accessed from solutionsDropdown class
    public float ammeter_read_tmp = 0.00004f;    //chosen to be used in update function
    public Quaternion currentRotation;
    public Quaternion targetRotation;
    public GameObject rotationParent;
    public float rot_duration;
    public float z_rotation_angle;
    //Start is called before the first frame update
    void Start()
    {
        rot_duration = 1f;
        z_rotation_angle = 0;
        
    } // Update is called once per frame
    void Update()
    {
        if(ammeter_read_tmp != solutionsDropdown.ammeter_final_readingA) { 
        ammeter_final_readingA = ammeter_read_tmp= solutionsDropdown.ammeter_final_readingA;
            if (ammeter_final_readingA == 4.79f)
            {
                z_rotation_angle = -36.896f;
            }
            else if (ammeter_final_readingA == 6.79f)
            {
                z_rotation_angle = -51.7f;
            }
            else if (ammeter_final_readingA == 3.59f)
            {
                z_rotation_angle = -26.877f;
            }
            else if (ammeter_final_readingA == 7.64f)
            {
                z_rotation_angle = -61.027f;
            }
            else if (ammeter_final_readingA == 6.24f)
            {
                z_rotation_angle = -51.022f;
            }
            else if (ammeter_final_readingA == 5.64f)
            {
                z_rotation_angle = -45.127f;
            }
            else if (ammeter_final_readingA == 6.34f)
            {
                z_rotation_angle = -51.7f;
            }
            else if (ammeter_final_readingA == 8.50f)
            {
                z_rotation_angle = -68.752f;
            }
            else if (ammeter_final_readingA == 0.00f)
            {
                z_rotation_angle = 0f;
            }
            else {z_rotation_angle = 0f; }

        targetRotation = Quaternion.Euler(new Vector3(0, 0, z_rotation_angle));
        StartCoroutine(ammeterValueUpdate());
        StartCoroutine(ammeterNeedleRotation(targetRotation));
        }
 }
    //4.79=-36.896f
    //6.34=-51.7
    //3.59=-26.877
    //7.64=-61.027
    //6.24=-51.022
    //5.64=-45.127
    //8.50=-68.752

    IEnumerator ammeterValueUpdate()
    {
        for(float i=0f; i <= ammeter_final_readingA; i+=0.1f) {
            yield return new WaitForSecondsRealtime(0.01f);
            ammeter_readingT.text = i.ToString("0.00");
        }    
     }


    IEnumerator ammeterNeedleRotation(Quaternion targetRotation)
    {
        float rot_time = 0;
        Quaternion startRotation = rotationParent.transform.rotation;
        while (rot_time < rot_duration)
        {
            rotationParent.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, rot_time / rot_duration);
            rot_time += Time.deltaTime;
            yield return null;
         }
        rotationParent.transform.rotation = targetRotation;
        rot_time = 0;
    }
 }
