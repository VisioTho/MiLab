using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetLitmus : MonoBehaviour
{
    public GameObject litmus_a, litmus_b;
    public static bool isDipped;
    public Button reset_litmus_button;

    void Update()
    {
        isDipped = litmus_paper_controller.isDipped;
        if (isDipped) {
            reset_litmus_button.interactable = false;
        }
        else
        {
            reset_litmus_button.interactable = true;
        }
    }

   public void rest_litmus_color()
    {
        litmus_b.GetComponent<SpriteRenderer>().color = litmus_a.GetComponent<SpriteRenderer>().color;
        litmus_paper_controller.lastDippedInto = "none";
    }
}
