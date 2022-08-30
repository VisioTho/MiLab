using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switch_litmus : MonoBehaviour
{
    public GameObject litmus_paper_a, litmus_paper_b;
    public static Vector2 litmus_paper_default_pos;
    Color defaultBlue = new Color32(17, 97, 137, 255);
    Color defaultRed = new Color32(161, 80, 63, 255);
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
            litmus_paper_a.GetComponent<SpriteRenderer>().color = defaultRed;
            litmus_paper_b.GetComponent<SpriteRenderer>().color = defaultRed;
        }
        else //blue
        {
            litmus_paper_a.GetComponent<SpriteRenderer>().color = defaultBlue;
            litmus_paper_b.GetComponent<SpriteRenderer>().color = defaultBlue;
        }
    }
}