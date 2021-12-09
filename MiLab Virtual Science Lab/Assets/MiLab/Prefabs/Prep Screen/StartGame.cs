using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject prepScreen;
    public Toggle toggleTutorial; //play with or without tutorial
    public static bool isTutorialEnabled; //classes implementing the tutorial can access the value
   

    private void Awake()
    {
        isTutorialEnabled = false;
    }

    void Start()
    {
        prepScreen.SetActive(true);

        Time.timeScale = 0f;
    }

    public void startGame()
    {
        Time.timeScale = 1f;

        prepScreen.SetActive(false);

        if (toggleTutorial.isOn)
        {
            isTutorialEnabled = true;
        }
        else
        {
            isTutorialEnabled = false;
        }
    }
}
