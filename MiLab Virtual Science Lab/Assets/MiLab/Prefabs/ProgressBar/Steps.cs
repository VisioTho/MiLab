using UnityEngine;

public partial class StepsUIManager
{
    public class Steps
    {
        public GameObject[] stepObjects;
        public void HideObjects()
        {
            foreach (GameObject i in stepObjects)
            {
                i.SetActive(false);
            }
        }
        public void ShowObjects()
        {
            foreach (GameObject i in stepObjects)
            {
                i.SetActive(true);
            }
        }
        public Steps(GameObject[] stepObjects)
        {
            this.stepObjects = stepObjects;
        }
    }
}
