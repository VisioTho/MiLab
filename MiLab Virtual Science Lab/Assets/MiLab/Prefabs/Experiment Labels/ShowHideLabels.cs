using UnityEngine;
using UnityEngine.UI;

public class ShowHideLabels : MonoBehaviour
{
    public GameObject[] experimentSetupLabels;
    public Button showHideButton;

   
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
        foreach (GameObject i in experimentSetupLabels)
        {
            if (i.activeSelf)
            {
                i.SetActive(false);
            }
            else if (!i.activeSelf)
            {
                i.SetActive(true);
            }
        }
    }

}
