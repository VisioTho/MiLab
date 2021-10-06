using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropToDelete : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventdata)
    {
        GameObject objectToDetele = eventdata.pointerDrag;
        objectToDetele.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
