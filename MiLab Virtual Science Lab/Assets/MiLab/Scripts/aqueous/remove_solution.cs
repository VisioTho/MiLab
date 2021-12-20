using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class remove_solution : MonoBehaviour
{
    public TMP_Dropdown solutions_dd;
    //public TMP_button rs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (solutions_dd.value > 0)
        {
            rs.interactable (true);
        }
        else
        {
            rs.interactable = false;
        } */
    }
    public void removeSolution()
    {
        solutions_dd.value = 0;
    }
}
