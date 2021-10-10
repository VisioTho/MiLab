using UnityEngine;
using UnityEngine.EventSystems;

public class PipetteDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector2 initialPosition;
    private void Start()
    {
        initialPosition = transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = initialPosition;
    }
}
