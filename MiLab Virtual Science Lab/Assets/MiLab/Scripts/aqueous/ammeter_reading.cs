using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ammeter_reading : MonoBehaviour
{
    public TextMeshProUGUI ammeter_readingT;
    public static float ammeter_final_readingA;//to be accessed from solutionsDropdown class
    public float ammeter_read_tmp = 0.00004f;//chosen to be used in update function
    // Start is called before the first frame update
    void Start()
    {
        
        
    } // Update is called once per frame
    void Update()
    {
        if(ammeter_read_tmp != solutionsDropdown.ammeter_final_readingA) { 
        ammeter_final_readingA = ammeter_read_tmp= solutionsDropdown.ammeter_final_readingA;
          StartCoroutine(ammeterValueUpdate());
        }

       
       
    } 
    
    IEnumerator ammeterValueUpdate()
    {
        for(float i=0f; i <= ammeter_final_readingA; i+=0.1f) {
            yield return new WaitForSecondsRealtime(0.001f);
            ammeter_readingT.text = i.ToString("0.00");
        }    
     }
   }
