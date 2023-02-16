using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFoodColors : MonoBehaviour
{
    public Color defaultColor = new Color32(255, 251, 251, 0);
    public GameObject[] foodColorableAreas; 
    
   public void ResetColors(){
    foreach(GameObject colorableArea in foodColorableAreas){
         colorableArea.GetComponent<SpriteRenderer>().color = defaultColor;
         colorChange.breadDropCount = colorChange.eggDropCount = colorChange.tomatoDropCount = colorChange.cassavaDropCount = colorChange.potatoDropCount = 0;
    }
 }
}
