using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class apparatus_drag : MonoBehaviour
{
    public static bool isDragged = false;
    private Vector3 mouseDragStartPosition, spriteDragStartPosition, position_before_drag, current_drop_position;
    Vector3 offset;
    public bool isOnlegendWire;
    public List<GameObject> in_canvas_apparatus, on_legend_apparatus;
    public List<string> apparatus_descriptions_texts;
    public GameObject x1_bound, x2_bound, y1_bound, y2_bound, apparatus_description_panel, delete;
    public TextMeshProUGUI apparatus_description_text_UI;
    public float x1_x_pos, x2_x_pos, y1_y_pos, y2_y_pos;
    public bool toDeleteAfterFingerLift;


    // VARIABLES FOR TAPPING
    float startTime;
    float endTime;
    int tapCounter;

    void Start()
    {
        tapCounter = 0;
        // GameObject.FindWithTag("selector").SetActive(false);
        toDeleteAfterFingerLift = false;

        x1_x_pos = x1_bound.transform.position.x;
        x2_x_pos = x2_bound.transform.position.x;

        y1_y_pos = y1_bound.transform.position.y;
        y2_y_pos = y2_bound.transform.position.y;

    }




    private void OnMouseDown()
    {
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
        // offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3)
        position_before_drag = gameObject.transform.position;

        startTime = Time.time; //TAP
    }
    private void OnMouseDrag()
    {

        if (isDragged)
        {
            // transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            transform.position = curPosition;
        }

        if (checkAvailabilityInCanvas(in_canvas_apparatus, gameObject)) {
            delete.SetActive(true); //showing delete icon
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;
        current_drop_position = gameObject.transform.position;

        endTime = Time.time;//TAP
        delete.SetActive(false); //hiding delete icon
        if (toDeleteAfterFingerLift)
        {
            gameObject.SetActive(false);
            toDeleteAfterFingerLift = false;
        }

        if ((current_drop_position.x > x1_x_pos && current_drop_position.x < x2_x_pos) && (current_drop_position.y < y1_y_pos && current_drop_position.y > y2_y_pos))
        {

                in_canvas_apparatus[on_legend_apparatus.IndexOf(gameObject)].SetActive(true);
                in_canvas_apparatus[on_legend_apparatus.IndexOf(gameObject)].transform.position = current_drop_position;

                gameObject.transform.position = position_before_drag;


       
                if (isOnlegendWire)
                {
                    //gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    gameObject.transform.position = position_before_drag;
                    gameObject.SetActive(false);
                    on_legend_apparatus[in_canvas_apparatus.IndexOf(gameObject)].SetActive(true);
                }
           
        }
        else
        {
            gameObject.transform.position = position_before_drag;
            if (checkAvailabilityInCanvas(in_canvas_apparatus, gameObject))
            {
                gameObject.SetActive(false);
                on_legend_apparatus[in_canvas_apparatus.IndexOf(gameObject)].SetActive(true);
            }
        }


    }


    //check if the current dragged item is in canvas and is invisible
    public bool checkAvailabilityInCanvas(List<GameObject> apparatus_list, GameObject current_gameObject)
    {
        if (apparatus_list.Contains(current_gameObject))
        {
            return true;
        }
        else
        {
            return false;
        }
    }





    // FUNCTIONS TO DETECT DOUBLE TAPPING
    private void LateUpdate() {
        if (endTime - startTime < 0.2f && endTime - startTime > 0f)
        {
            tapCounter++;
            endTime = 0f;
            startTime = 0f;
            StartCoroutine(Countdown());
            //Debug.Log("Tap Counter = " + tapCounter);
        if (tapCounter == 2)
        {
         //CHECK IF THE CLICKED OBJECT IS THE ONE INSIDE THE CANVAS
         if(checkAvailabilityInCanvas(in_canvas_apparatus, gameObject)){
          //TOGGLING THE PANEL AT THE SAME TIME INFLATING TIP TEXT

            apparatus_description_panel.SetActive(true);
            apparatus_description_text_UI.text = apparatus_descriptions_texts[in_canvas_apparatus.IndexOf(gameObject)];
         }
       }
        else
        {
            //Debug.Log("Single tappedddddddddddd");
        }
      }

    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(0.7f);
        tapCounter = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "delete")
        {
            //Debug.Log("To be deleted");
            gameObject.SetActive(false);
            delete.SetActive(false);
            //toDeleteAfterFingerLift = true;
           on_legend_apparatus[in_canvas_apparatus.IndexOf(gameObject)].SetActive(true);
        }
    }



  /*  void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "delete")
        {
           // Debug.Log("To be deleted");
           // gameObject.SetActive(false);
           //toDeleteAfterFingerLift = false;
        }
    }*/

}
