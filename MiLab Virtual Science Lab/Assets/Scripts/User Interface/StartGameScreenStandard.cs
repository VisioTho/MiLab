using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScreenStandard : MonoBehaviour
{
    [SerializeField] private GameObject startGamePanel;
    // Start is called before the first frame update
    void Start()
    {
        startGamePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void startGame()
    {
        Time.timeScale = 1f;
        startGamePanel.SetActive(false);
    }
}
