using UnityEngine;
using UnityEngine.EventSystems;

public class Draggables : MonoBehaviour, IDragHandler, IDropHandler
{
    public bool shouldSnapBack, limitMovement; // set modifiable motion characteristics in inspector
    private Vector3 initialposition;
    public float maxPosY, minPosY, maxPosX, minPosX; 
   

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
        transform.position = Input.mousePosition;
        if (limitMovement)
        {
            LimitMovement();
        }   
    }

    private void LimitMovement()
    {
        if (transform.localPosition.y > maxPosY)
            transform.LeanMoveLocalY(-2f, 1f);

        if (transform.localPosition.y < minPosY)
            transform.LeanMoveLocalY(2f, 1f);

        if (transform.localPosition.x > maxPosX)
            transform.LeanMoveLocalX(-2f, 1f);

        if (transform.localPosition.x < minPosX)
            transform.LeanMoveLocalX(2f, 1f);
    }

    public void OnDrop(PointerEventData eventdata)
    {
        if(shouldSnapBack)
        {
            transform.localPosition = initialposition;
        }
    }

}
