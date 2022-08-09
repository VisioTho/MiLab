using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class foodSelection : MonoBehaviour
{
    public TMP_Dropdown foods_dd;
    public GameObject bread_plate, egg_plate, tomato_plate, cassava_plate, irish_potato_plate, dropper_spawn_pointA;
    GameObject onFocusNow = null;
    Vector3 hidden_posistion;
   // Start is called before the first frame update
    void Start()
    {

        hidden_posistion = egg_plate.transform.position;

        foods_dd.onValueChanged.AddListener(delegate {
            foodValueHasChanged(foods_dd);
        });

        foods_dd.value = Random.Range(0, 5); //randomizing default food
        //putting the selected food on focus
        if (foods_dd.value == 0) moveAPlate(egg_plate, new Vector3(dropper_spawn_pointA.transform.position.x, hidden_posistion.y, 0f), 1);
        if (foods_dd.value == 1) moveAPlate(tomato_plate, new Vector3(dropper_spawn_pointA.transform.position.x, hidden_posistion.y, 0f), 1);
        if (foods_dd.value == 2) moveAPlate(cassava_plate, new Vector3(dropper_spawn_pointA.transform.position.x, hidden_posistion.y, 0f), 1);
        if (foods_dd.value == 3) moveAPlate(irish_potato_plate, new Vector3(dropper_spawn_pointA.transform.position.x, hidden_posistion.y, 0f), 1);
        if (foods_dd.value == 4) moveAPlate(bread_plate, new Vector3(dropper_spawn_pointA.transform.position.x, hidden_posistion.y, 0f), 1);
    }

   void foodValueHasChanged(TMP_Dropdown sender)
    {
        //DROP_DOWN_ORDER :: egg, tomato, cassava, irish_potato, bread;
       // moveAPlate(onFocusNow, hidden_posistion, 0.5f); //moving another plate out of focus

        int selected_value = sender.value;

        if (selected_value == 0)
        {
            onFocusNow = egg_plate;
            moveAPlate(egg_plate, new Vector3(dropper_spawn_pointA.transform.position.x, hidden_posistion.y, 0f), 1);
        }
        else if (selected_value == 1) {
            onFocusNow = tomato_plate;
            moveAPlate(tomato_plate, new Vector3(dropper_spawn_pointA.transform.position.x, hidden_posistion.y, 0f), 1);
        }
        else if (selected_value == 2)
        {
            onFocusNow = cassava_plate;
            moveAPlate(cassava_plate, new Vector3(dropper_spawn_pointA.transform.position.x, hidden_posistion.y, 0f), 1);
        }
        else if (selected_value == 3)
        {
            onFocusNow = irish_potato_plate;
            moveAPlate(irish_potato_plate, new Vector3(dropper_spawn_pointA.transform.position.x, hidden_posistion.y, 0f), 1);
        }
        else
        {
            onFocusNow = bread_plate;
            moveAPlate(bread_plate, new Vector3(dropper_spawn_pointA.transform.position.x, hidden_posistion.y, 0f), 1);
        }
    }


    void moveAPlate(GameObject plateToMove, Vector3 positionTo, float duration)
    {
        plateToMove.transform.DOMove(positionTo, duration);
    }
}
