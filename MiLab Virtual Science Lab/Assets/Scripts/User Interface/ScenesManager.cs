using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void LoadBunsenBurnerScene()
    {
        SceneManager.LoadScene("Burner");
    }

    public void LoadBunsenBurnerExcercise()
    {
        SceneManager.LoadScene("BurnerExcercise");
    }
}
