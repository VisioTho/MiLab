using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switch_litmus : MonoBehaviour
{
    public GameObject litmus_paper_a, litmus_paper_b;
    public static Vector2 litmus_paper_default_pos;
    // Start is called before the first frame update
    void Start()
    {
        litmus_paper_default_pos = litmus_paper_a.transform.position;

        gameObject.GetComponent<Toggle>().onValueChanged.AddListener(delegate
        {
            ToggleValueChanged();
        });
    }

    public void ToggleValueChanged()
    {
        litmus_paper_controller.lastDippedInto = "none"; // resetting the last liquid into which Litmus paper was dipped
        if (gameObject.GetComponent<Toggle>().isOn) //red
        {
            litmus_paper_a.GetComponent<SpriteRenderer>().color = new Color32(239, 73, 26, 255);
            litmus_paper_b.GetComponent<SpriteRenderer>().color = new Color32(239, 73, 26, 255);
        }
        else //blue
        {
            litmus_paper_a.GetComponent<SpriteRenderer>().color = new Color32(8, 135, 199, 255);
            litmus_paper_b.GetComponent<SpriteRenderer>().color = new Color32(8, 135, 199, 255);
        }
    }
}