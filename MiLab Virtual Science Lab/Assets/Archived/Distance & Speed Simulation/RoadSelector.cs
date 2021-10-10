using TMPro;
using UnityEngine;

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
            finishLineFlag.transform.position = new Vector3(29.3999996f, -5.0999999f, 0);
        }
        if (val == 1)
        {
            flatRoad.SetActive(false);
            hillyRoad.SetActive(true);
            finishLineFlag.transform.position = new Vector2(28.0699997f, -2.52999997f);
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
