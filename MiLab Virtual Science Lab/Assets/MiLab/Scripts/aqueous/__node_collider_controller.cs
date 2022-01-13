using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class __node_collider_controller : MonoBehaviour
{
    public static bool isCollided = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "cathode" || collision.gameObject.tag == "anode") {
            isCollided = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cathode" || collision.gameObject.tag == "anode")
        {
            isCollided = false;
        }
    }
    }
