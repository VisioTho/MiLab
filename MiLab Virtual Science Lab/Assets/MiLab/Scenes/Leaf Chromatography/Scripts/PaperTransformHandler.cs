using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaperTransformHandler : MonoBehaviour
{

    public GameObject chromPaper, transformedPaper;

    // Start is called before the first frame update
    void Start()
    {
        transformedPaper.SetActive(false);
    }
    void OnMouseDown()
    {
        if (SnapController.snapEnabled)
        {
            Debug.Log("tapped");
            transformedPaper.SetActive(true);
            chromPaper.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
