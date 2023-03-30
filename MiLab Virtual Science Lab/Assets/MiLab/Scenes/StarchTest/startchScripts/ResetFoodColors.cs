using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFoodColors : MonoBehaviour
{
    public Color defaultColor = new Color32(255, 251, 251, 0);
    public GameObject[] foodColorableAreas;

    public ColorChange CC = new ColorChange();
    
   public void ResetColors(){
    foreach(GameObject colorableArea in foodColorableAreas){
         colorableArea.GetComponent<SpriteRenderer>().color = defaultColor;
        // ColorChange.breadDropCount = ColorChange.eggDropCount = ColorChange.tomatoDropCount = ColorChange.cassavaDropCount = ColorChange.potatoDropCount = 0;
       CC.breadDropCount = CC.eggDropCount = CC.tomatoDropCount = CC.cassavaDropCount = CC.potatoDropCount = 0;

    }
 }
}
