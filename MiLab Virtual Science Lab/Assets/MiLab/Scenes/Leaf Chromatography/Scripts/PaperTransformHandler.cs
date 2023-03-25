using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaperTransformHandler : MonoBehaviour
{

    public ChromatographySimulation chromatographySimulation;
    public Draggrable draggableScript;
    public GameObject chromPaper, transformedPaper, dotPink, dotGreen;
    public SpriteRenderer chromPaperPoint;

    // Start is called before the first frame update
    void Start()
    {
        transformedPaper.SetActive(false);
        chromPaperPoint = GetComponent<SpriteRenderer>();

    }
    void OnMouseDown()
    {
        if (SnapController.snapEnabled)
        {
            Debug.Log("tapped");
            draggableScript.MoveToDefaultPosition(1);
            transformedPaper.SetActive(true);
            chromPaper.SetActive(false);
            if (chromatographySimulation.dropdown.value == 1)
            {
                dotPink.SetActive(true);
                dotGreen.SetActive(false);
            }
            else
            {
                dotPink.SetActive(false);
                dotGreen.SetActive(true);
            }


        }
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("white color");
    }

    public void Reset()
    {
        chromPaper.SetActive(true);
        transformedPaper.SetActive(false);
    }
}
