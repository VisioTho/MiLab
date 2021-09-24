using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowHideLabels : MonoBehaviour
{
    [SerializeField] private GameObject[] experimentSetupLabels;
    public Button showHideButton;
    // Start is called before the first frame update
    void Start()
    {
        showHideButton.onClick.AddListener(ShowHide);
        foreach (GameObject i in experimentSetupLabels)
        {
            i.SetActive(false);
        }
    }

    void ShowHide()
    {
        foreach(GameObject i in experimentSetupLabels)
        {
            if(i.activeSelf)
            {
                i.SetActive(false);
            }
            else if(!i.activeSelf)
            {
                i.SetActive(true);
            }
        }
    }

}
