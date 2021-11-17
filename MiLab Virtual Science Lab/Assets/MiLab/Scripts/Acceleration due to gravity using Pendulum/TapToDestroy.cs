using UnityEngine;

public class TapToDestroy : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
