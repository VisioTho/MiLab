using UnityEngine;
using UnityEngine.EventSystems;

public class Draggables : MonoBehaviour, IDragHandler, IDropHandler
{
    public bool shouldSnapBack;
    private Vector3 initialposition;

    private void Start()
    {
        initialposition = gameObject.transform.localPosition;
    }
    void OnMouseDown()
    {
        
    }
    public void OnDrag(PointerEventData eventdata)
    {
        transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventdata)
    {
        if(shouldSnapBack)
        {
            transform.localPosition = initialposition;
        }
    }

}
