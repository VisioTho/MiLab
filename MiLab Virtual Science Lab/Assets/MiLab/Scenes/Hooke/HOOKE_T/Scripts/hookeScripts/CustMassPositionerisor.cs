using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustMassPositionerisor : MonoBehaviour
{
    void OnMouseUp()
    {
     if (load_collider.current_hanged_mass != "load_custom")
       {
           transform.DOMove(customMassToggleController.custom_mass_visible_pos, 1);
       }
    }
}
