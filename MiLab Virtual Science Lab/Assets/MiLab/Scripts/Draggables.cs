using UnityEngine;
using UnityEngine.EventSystems;

public class Draggables : MonoBehaviour, IDragHandler, IDropHandler
{
    public bool shouldSnapBack;
    private Vector3 initialposition;
    public bool moveAlongX, moveAlongY;
   

    private void Start()
    {
        initialposition = gameObject.transform.localPosition;
    }
    void OnMouseDown()
    {
        
    }
    public void OnDrag(PointerEventData eventdata)
    {
        DragToNewPosition();
    }

    private void DragToNewPosition()
    {
        if (moveAlongX && moveAlongY)
            transform.position = Input.mousePosition;

        else if (moveAlongX && !moveAlongY)
            transform.position = new Vector3(Input.mousePosition.x, initialposition.y,initialposition.z);

        else if (!moveAlongX && moveAlongY)
            transform.position = new Vector3(initialposition.x, Input.mousePosition.y, initialposition.z);
    }

    public void OnDrop(PointerEventData eventdata)
    {
        if(shouldSnapBack)
        {
            transform.localPosition = initialposition;
        }
    }

}
