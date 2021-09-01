using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject confirmationWindow;
    public void confirmQuit(int val)
    {
        if (val == 0)
        {
            confirmationWindow.SetActive(false);
            Time.timeScale = 1f;
        }
        if (val == 1)
            SceneManager.LoadScene("MainMenu");
    }

    public void showConfirmationWindow()
    {
        confirmationWindow.SetActive(true);
        Time.timeScale = 0f;
    }
}
