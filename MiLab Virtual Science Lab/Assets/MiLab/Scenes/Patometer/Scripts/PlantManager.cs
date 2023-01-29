using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public bool isConnectedToTube;
    public Rigidbody2D plant;
    // Start is called before the first frame update
    void Start()
    {
        plant = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Tube Tip")
        {     
            isConnectedToTube = true;
        }
    }
   

    private void OnMouseUp()
    {
        if(isConnectedToTube)
        {
            Vector2 newPosition = new Vector2(-2.95f, 1.5f);
            WaterLevelManager.isReset = false;
            GetComponent<Rigidbody2D>().MovePosition(newPosition);
        }
            
    }

    public void ResetPlantPosition()
    {
        Vector2 newPosition = new Vector3(-8.25f, 1.37f, 0f);
        GetComponent<Rigidbody2D>().MovePosition(newPosition);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tube Tip")
        {
            isConnectedToTube = false;
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        Debug.Log("state is " + isConnectedToTube);
        WaterLevelManager.AdjustWaterLevel(this);
    }
}
