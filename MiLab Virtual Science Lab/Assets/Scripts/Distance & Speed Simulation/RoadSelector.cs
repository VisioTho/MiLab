using UnityEngine;
using TMPro;

public class RoadSelector : MonoBehaviour
{
    [SerializeField] private GameObject flatRoad, hillyRoad, finishLineFlag;
    [SerializeField] private TMP_Dropdown roadSelector;
    public Rigidbody2D carBody;
    public void SelectRoad(int val)
    {
        if (val == 0)
        {
            flatRoad.SetActive(true);
            hillyRoad.SetActive(false);
            finishLineFlag.transform.position = new Vector2(35f, -5.6f);
        }
        if (val == 1)
        {
            flatRoad.SetActive(false);
            hillyRoad.SetActive(true);
            finishLineFlag.transform.position = new Vector2(33.6f, 0.4f);
        }
    }

    void FixedUpdate()
    {
        if (!carBody.IsSleeping())
            roadSelector.enabled = false;
        else
            roadSelector.enabled = true;
    }


}
