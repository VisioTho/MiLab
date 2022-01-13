using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class remove_solution : MonoBehaviour
{
    public TMP_Dropdown solutions_dd;
    public void removeSolution()
    {
        solutions_dd.value = 0;
    }
}
