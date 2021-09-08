using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameScreen : MonoBehaviour
{
    [SerializeField] private GameObject startGamePanel;
    [SerializeField] private Toggle toggleTutorial;
    public static bool isTutorialEnabled;
    // Start is called before the first frame update

    private void Awake()
    {
        isTutorialEnabled = true;
    }
    void Start()
    {
        startGamePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void startGame()
    {
        Time.timeScale = 1f;
        startGamePanel.SetActive(false);
        if(toggleTutorial.isOn)
        {
            isTutorialEnabled = true;
        }
        else
        {
            isTutorialEnabled = false;
        }
    }
}
