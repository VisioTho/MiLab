using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prog_apparatus : MonoBehaviour
{
    public GameObject progress_bar;
    public float MAXIMUM_X_STRECH;
    public int current_connected_points;
    public int NUMBER_OF_PAIR_CONNECTION_POINTS;
    public float x_stretch;
    
    // Start is called before the first frame update
    void Start()
    {
        current_connected_points = 4;
        MAXIMUM_X_STRECH = 0.594f; //Dependent on how long you wanna your progress bar to be
        NUMBER_OF_PAIR_CONNECTION_POINTS = 5;

        x_stretch = 0.007f;
    }

    // Update is called once per frame
    void Update()
    {
      
        x_stretch = (current_connected_points / NUMBER_OF_PAIR_CONNECTION_POINTS * MAXIMUM_X_STRECH);
        
        progress_bar.transform.localScale = new Vector3(x_stretch, progress_bar.transform.localScale.y, progress_bar.transform.localScale.z);

        //Debug.Log("prog current c point: " + current_connected_points);
       //Debug.Log("prog x stretch: " + x_stretch);
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == gameObject.name)
        {
            Debug.Log("Collision Entered");
           // progress_bar.transform.localScale = new Vector3(1f, 0.797712f, 1f);
           //current_connected_points + = 1;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == gameObject.name)
        {
           Debug.Log("Collision Exited");
       //    current_connected_points -= 1; //decrementing the value if the two points do not remain connected
        }
    }

}
