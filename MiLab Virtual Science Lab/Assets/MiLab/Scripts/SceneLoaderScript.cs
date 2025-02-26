using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    private int nextSceneToLoad;
    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex - 1;
    }
    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadPrevScene()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }
    
    void Update()
    {
     
       // Check if Back was pressed this frame
       if (Input.GetKeyDown(KeyCode.Escape))
       {
            SceneManager.LoadScene("MainMenu");
       }
        
    }
}
