using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabsManager : MonoBehaviour
{
    public GameObject tabContent;
    public GameObject tabLabel;
    private Vector3 initialTabLabelScale;
    // Start is called before the first frame update
    void Start()
    {
        initialTabLabelScale = tabLabel.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        OnActive();
        OnInActive();
    }

    private void OnActive()
    {
        if (tabContent.activeSelf)
        {
            Debug.Log("show");
            tabLabel.transform.localScale = new Vector3(1.20f, 1.20f, 1);
        }
        
    }

    private void OnInActive()
    {
        if (tabContent.activeSelf == false)
        {
            Debug.Log("working");
            tabLabel.transform.localScale = initialTabLabelScale;
        }
    }
}
