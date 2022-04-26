using UnityEngine;

public partial class BottomNavController
{
    public class Tabs
    {
        public GameObject[] TabObjects;
        public void HideObjects()
        {
            foreach (GameObject i in TabObjects)
            {
                i.SetActive(false);
            }
        }
        public void ShowObjects()
        {
            foreach (GameObject i in TabObjects)
            {
                i.SetActive(true);
            }
        }
        public Tabs(GameObject[] objectsInTab)
        {
            this.TabObjects = objectsInTab;
        }
    }
}
