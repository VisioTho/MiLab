using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public static bool isPlayed = V1;
    public void startGame()
    {
        Time.timeScale = 1f;
        startGamePanel.SetActive(false);
        if(!BunsenBurnerTutorialManager.isTutorial)
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
