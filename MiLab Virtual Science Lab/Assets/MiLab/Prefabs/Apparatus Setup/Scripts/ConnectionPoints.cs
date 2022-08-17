using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionPoints : MonoBehaviour
{  
    public Color connected_color;
    public Color disconnected_color;
   //public Vector2 default_progress_visible_pos;
    void Start()
    {
        connected_color = new Color32(0, 224, 0, 255);
        disconnected_color = new Color32(225, 0, 0, 255);

        //GameObject.Find("PROGRESS_BAR_PARENT").transform.localPosition = new Vector3(-0.358f, -0.216f, 0f); //showing progress bar 
        //Debug.Log("progress" + GameObject.Find("PROGRESS_BAR_PARENT").transform.position);
        GameObject.Find("PROGRESS_BAR_PARENT").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Prog_insider").GetComponent<SpriteRenderer>().enabled = true;
    }
    
   

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.name == gameObject.name)
        {
            ProgressBarApparatus.current_connected_points = ProgressBarApparatus.current_connected_points + 1;
            ProgressBarApparatus.shouldUpdateProgBar = true;
            //changing color when connected
            other.GetComponent<SpriteRenderer>().color = connected_color;
            gameObject.GetComponent<SpriteRenderer>().color = connected_color;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == gameObject.name)
        {
            ProgressBarApparatus.current_connected_points = ProgressBarApparatus.current_connected_points - 1; //decrementing the value if the two points do not remain connected
            ProgressBarApparatus.shouldUpdateProgBar = true;

        //changing color when connected
        other.GetComponent<SpriteRenderer>().color = disconnected_color;
        gameObject.GetComponent<SpriteRenderer>().color = disconnected_color;
      }
    }
}