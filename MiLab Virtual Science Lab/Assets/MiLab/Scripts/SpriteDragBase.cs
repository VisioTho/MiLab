using UnityEngine;
public class SpriteDragBase: MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        TemperatureReaction.stirTime = 0f;
        transform.GetChild(0).gameObject.SetActive(true);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }


    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }
}