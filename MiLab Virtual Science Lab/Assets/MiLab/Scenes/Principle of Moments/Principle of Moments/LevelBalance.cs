using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBalance : MonoBehaviour
{
    public GameObject ruler;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        
        if (ruler.transform.rotation.z >= 10)
        {
            ruler.transform.eulerAngles = new Vector3(ruler.transform.eulerAngles.x, transform.transform.eulerAngles.y, 10);
        }
        
        if (ruler.transform.rotation.z >= -0.009962927f && ruler.transform.rotation.z <= 0.009962927f)
        {
            spriteRenderer.color = new Color(0, 1, 0);
        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1);
        }
    }
   
}
