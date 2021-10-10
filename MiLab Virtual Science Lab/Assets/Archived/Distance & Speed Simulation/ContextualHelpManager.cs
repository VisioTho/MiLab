using UnityEngine;

public class ContextualHelpManager : MonoBehaviour
{
    [SerializeField] private GameObject[] helpPanels;
    [SerializeField] private GameObject fader;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject i in helpPanels)
        {
            i.SetActive(false);
        }
    }
    public void showPanel(int n)
    {
        if (!helpPanels[n].activeSelf)
        {
            helpPanels[n].SetActive(true);
            fader.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (helpPanels[n].activeSelf)
        {
            helpPanels[n].SetActive(false);
            fader.SetActive(false);
            Time.timeScale = 1f;
        }

    }
}
