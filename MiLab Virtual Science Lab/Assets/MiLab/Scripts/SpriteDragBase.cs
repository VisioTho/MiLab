using UnityEngine;
public class SpriteDragBase: MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    public float maxX, minX, maxY, minY;
    public bool isLimited;


    void OnMouseDown()
    {
        //TemperatureReaction.stirTime = 0f;
        //transform.GetChild(0).gameObject.SetActive(true);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }


    void OnMouseDrag()
    {
        DragSprite();
    }

    public void DragSprite()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        if (isLimited)
        {
            if (transform.position.y <= minY)
                transform.position = new Vector3(transform.position.x, minY, transform.position.z);

            if (transform.position.y >= maxY)
                transform.position = new Vector3(transform.position.x, maxY, transform.position.z);

            if (transform.position.x <= minX)
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);

            if (transform.position.x >= maxX)
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);

        }
    }
}