using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public bool isConnectedToTube;
    public Rigidbody2D plant;
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        plant = GetComponent<Rigidbody2D>();
        initialPosition = plant.position;
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
            Vector2 newPosition = new Vector2(1.98f, 2.64f);
            WaterLevelManager.isReset = false;
            GetComponent<Rigidbody2D>().MovePosition(newPosition);
        }
            
    }

    public void ResetPlantPosition()
    {
        Vector2 newPosition = initialPosition;
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
