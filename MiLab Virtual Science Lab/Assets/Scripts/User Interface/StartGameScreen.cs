using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartGameScreen : MonoBehaviour
{
    private const bool V = true;
    private const bool V1 = false;
    [SerializeField] private GameObject[] tutorialboxes;
    [SerializeField] private GameObject startGamePanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        startGamePanel.SetActive(true);
    }

   [SerializeField] private Toggle tutorialOrNot; 
    public void startGame()
    {
        Time.timeScale = 1f;
        startGamePanel.SetActive(false);
        Debug.Log(tutorialOrNot.isOn);
        if(!tutorialOrNot.isOn)
        {
             for(int i=0; i<tutorialboxes.Length; i++)
            {
                Destroy(tutorialboxes[i]);
            }
        }
        else
        {
            tutorialboxes[0].SetActive(true);
        }
    }
}
