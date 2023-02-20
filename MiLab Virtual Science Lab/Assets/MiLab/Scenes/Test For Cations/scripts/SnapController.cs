using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Draggrable> draggrableObjects;
    public float snapRange = 0.5f;
    public static bool snapEnabled = false;
    void Start()
    {
        foreach (Draggrable draggrable in draggrableObjects)
        {
            draggrable.dragEndedCallback = onDragEnded;
        }
    }

    private void onDragEnded(Draggrable draggrable)
    {
        float closeDistance = -1;
        Transform closestSnapPoint = null;

        foreach (Transform snapPoint in snapPoints)
        {
            float curretDistance = Vector2.Distance(draggrable.transform.position, snapPoint.localPosition);
            if (closestSnapPoint == null || curretDistance < closeDistance)
            {
                closestSnapPoint = snapPoint;
                closeDistance = curretDistance;
                snapEnabled = false;
            }
        }
        if (closestSnapPoint != null && closeDistance <= snapRange)
        {
            draggrable.transform.localPosition = closestSnapPoint.localPosition;
            snapEnabled = true;
        }
    }
}
