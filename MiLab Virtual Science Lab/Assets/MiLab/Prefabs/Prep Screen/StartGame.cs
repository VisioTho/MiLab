using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private Toggle tutorialToggle;
    public static bool isTutorialEnabled; //classes implementing the tutorial can access the value
   

    private void Awake()
    {
        isTutorialEnabled = false;
    }

    void Start()
    {
        isTutorialEnabled = true;
        tutorialToggle = this.gameObject.GetComponent<Toggle>();
        //Time.timeScale = 0f;
    }

    public void startGame()
    {
        if(isTutorialEnabled)
        {
            isTutorialEnabled = false;
        }
        else if(!isTutorialEnabled)
        {
            isTutorialEnabled = true;
        }
        /*if (tutorialToggle.isOn)
        {
            isTutorialEnabled = true;
        }
        else
        {
            isTutorialEnabled = false;
        }*/
    }
}
