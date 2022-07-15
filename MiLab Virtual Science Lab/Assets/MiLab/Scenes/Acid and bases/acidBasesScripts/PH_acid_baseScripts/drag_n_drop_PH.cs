using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class drag_n_drop_PH : MonoBehaviour
{
    public static bool isDragged = false;
    private Vector3 mouseDragStartPosition, spriteDragStartPosition;
    //to be fetched from default_positions_PH
    public static float pippete_y_position;
    public static Vector3 hydrochloric_acid_beaker_position, ethanoic_acid_beaker_position, sodium_hydroxide_beaker_position, ammonium_solution_beaker_position, horizontal_litmus_movement_notifier_position;
    public GameObject horizontal_litmus_movement_notifier, bottom_most_litmus_drag_limit, litmus_stretch_pointB, bound_hA, bound_hB, bound_hC, bound_hD, bound_hE;
    public string litmus_pos_range;
    //Start is called before the first frame update
    void Start()
    {
        pippete_y_position = default_positions_PH.pippete_y_position;
        hydrochloric_acid_beaker_position = default_positions_PH.hydrochloric_acid_beaker_position;
        ethanoic_acid_beaker_position = default_positions_PH.ethanoic_acid_beaker_position;
        sodium_hydroxide_beaker_position = default_positions_PH.sodium_hydroxide_beaker_position;
        ammonium_solution_beaker_position = default_positions_PH.ammonium_solution_beaker_position;
        //--------------------------------------------------------------------------//
        horizontal_litmus_movement_notifier_position = horizontal_litmus_movement_notifier.transform.position;
        litmus_pos_range = "NA";
    }


    public void Update()
    {
        if (litmus_pos_range == "A-B") {
            gameObject.transform.position = new Vector2((bound_hA.transform.position.x + bound_hB.transform.position.x) / 2, gameObject.transform.position.y);
        }
        if (litmus_pos_range == "B-C") {
            gameObject.transform.position = new Vector2((bound_hB.transform.position.x + bound_hC.transform.position.x) / 2, gameObject.transform.position.y);
        }
        if (litmus_pos_range == "C-D")
        {
            gameObject.transform.position = new Vector2((bound_hC.transform.position.x + bound_hD.transform.position.x) / 2, gameObject.transform.position.y);
        }
        if (litmus_pos_range == "D-E")
        {
            gameObject.transform.position = new Vector2((bound_hD.transform.position.x + bound_hE.transform.position.x) / 2, gameObject.transform.position.y);
        }
        /* if (litmus_pos_range == "NA") {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, horizontal_litmus_movement_notifier_position.y); 
         }*/



        /*--------preventing the beakers from being dragged--------------*/

        GameObject.FindWithTag("hydrochloric_acid_beaker").transform.position = hydrochloric_acid_beaker_position;
        GameObject.FindWithTag("ethanoic_acid_beaker").transform.position = ethanoic_acid_beaker_position;
        GameObject.FindWithTag("sodium_hydroxide_beaker").transform.position = sodium_hydroxide_beaker_position;
        GameObject.FindWithTag("ammonium_solution_beaker").transform.position = ammonium_solution_beaker_position;

    }


    private void OnMouseDown()
    {
        Vibration.Vibrate(20); //Vibration
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
    }
    private void OnMouseDrag()
    {
        if (isDragged)
        {
             transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
         /*   if (gameObject.tag == "pippete")
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, pippete_y_position);
            }*/

            if (gameObject.tag == "litmus")
            {
                    //limiting the litmus paper from being dragged beyond the base of the beakers
                    if (gameObject.transform.position.y < bottom_most_litmus_drag_limit.transform.position.y) //y axis drag-position zenith
                    {
                       gameObject.transform.position = new Vector2(gameObject.transform.position.x, bottom_most_litmus_drag_limit.transform.position.y);
                    }

                if (horizontal_litmus_movement_notifier_position.y > litmus_stretch_pointB.transform.position.y)
                {
                    //constraining the litmus paper movement to the top target of the beaker only.
                   if((gameObject.transform.position.x > bound_hA.transform.position.x) && (gameObject.transform.position.x < bound_hB.transform.position.x))
                    {
                        litmus_pos_range = "A-B";
                    }
                    else if ((gameObject.transform.position.x > bound_hB.transform.position.x) && (gameObject.transform.position.x < bound_hC.transform.position.x))
                    {
                        litmus_pos_range = "B-C";
                    }
                    else if ((gameObject.transform.position.x > bound_hC.transform.position.x) && (gameObject.transform.position.x < bound_hD.transform.position.x))
                    {
                        litmus_pos_range = "C-D";
                    }
                    else if ((gameObject.transform.position.x > bound_hD.transform.position.x) && (gameObject.transform.position.x < bound_hE.transform.position.x))
                    {
                        litmus_pos_range = "D-E";
                    }
                    else { litmus_pos_range = "NA"; }
                }
                else
                {
                    litmus_pos_range = "NA";
                }
            }
        }
    }

    private void OnMouseUp()
    {

        isDragged = false;

      /* 
        if (gameObject.tag == "hydrochloric_acid_beaker") { gameObject.transform.position = hydrochloric_acid_beaker_position; }
        if (gameObject.tag == "ethanoic_acid_beaker") { gameObject.transform.position = ethanoic_acid_beaker_position; }
        if (gameObject.tag == "sodium_hydroxide_beaker") { gameObject.transform.position = sodium_hydroxide_beaker_position; }
        if (gameObject.tag == "ammonium_solution_beaker") { gameObject.transform.position = ammonium_solution_beaker_position; }
      */


    /*    if (gameObject.tag == "pippete")
        {
            float pippeteXpos = gameObject.transform.position.x;

            if (pippeteXpos >=-11f && pippeteXpos<-4.9f) { 
                gameObject.transform.position = new Vector2(-6.8f, pippete_y_position);
              }
            if (pippeteXpos >= -4.9f && pippeteXpos < -1.4f) {
                gameObject.transform.position = new Vector2(-3.5f, pippete_y_position);
            }
            if (pippeteXpos >= -1.4f && pippeteXpos < 2.1f) { 
                gameObject.transform.position = new Vector2(0.1f, pippete_y_position);
            }
            if (pippeteXpos >= 2.1f) {
                gameObject.transform.position = new Vector2(3.5f, pippete_y_position);
            }
        }*/
           
    }
}
