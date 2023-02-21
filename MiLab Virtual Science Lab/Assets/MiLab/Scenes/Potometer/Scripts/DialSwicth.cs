using UnityEngine;

public class DialSwicth: MonoBehaviour
{
    private Vector3 originalRotation;
    private Vector3 rotatedRotation;
    public bool isRotated;
    private bool isRed;
    public Color targetColor;
    private Color originalColor;
    private SpriteRenderer rend;
  
    
    // Start is called before the first frame update
    void Start()
    {
        rotatedRotation = new Vector3(0, 0, 90);
        isRotated = false;
        isRed = false;
        
        originalRotation = transform.eulerAngles;
        rend = GetComponent<SpriteRenderer>();
        originalColor = rend.color;
    }
    private void OnMouseDown()
    {
        
        if (isRotated)
        {
            transform.eulerAngles = originalRotation;
            isRotated = false;
            rend.color = originalColor;
            isRed = false;
            
        }
        else
        {
            transform.eulerAngles = rotatedRotation;
            isRotated = true;
            rend.color = targetColor;
            isRed = true;

        }
    }

  
}