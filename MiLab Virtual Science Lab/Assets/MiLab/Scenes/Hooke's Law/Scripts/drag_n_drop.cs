using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_n_drop : MonoBehaviour
{
    //drag 'n' drop vars
    public static bool isDragged = false;
    private Vector3 mouseDragStartPosition, spriteDragStartPosition;
    public static bool drag_detached;
   // public bool isHanged = false;//to be used when disabling drag on other masses
    public static Hashtable loads = new Hashtable();
    public static string current_hanged_mass;//accessed from a load_collider class
    public static Vector3 load_dp, load_100_dp, load_200_dp, load_300_dp, load_400_dp, load_custom_dp;//to be fetched from positions_controller class


    // Start is called before the first frame update
    void Start()
    {
        //track of all the masses
         loads =controller.loads;
             
        load_dp = positions_controller.load_dp;   //fetching from positions_controller class

        //fetching default load positions
        load_100_dp = positions_controller.load_100_dp;
        load_200_dp = positions_controller.load_200_dp;
        load_300_dp = positions_controller.load_300_dp;
        load_400_dp = positions_controller.load_400_dp;
        load_custom_dp = positions_controller.load_custom_dp;
        
    }

    // Update is called once per frame
    void Update()
    {
        //drag_detached = load_collider.drag_detached;  //accessing variable from load_collider class
        current_hanged_mass = load_collider.current_hanged_mass;

        if (current_hanged_mass != null) {
             for (int i = 1; i <= loads.Count; i++)
               {
                   if (current_hanged_mass ==(string) loads[i]) { continue; } //skip if the current mass being checked is the one already hanged
                   GameObject.FindWithTag((string)loads[i]).GetComponent<PolygonCollider2D>().enabled=false; //Disabling collider for drug 'n' drop
            }
        }
        else
        {
            for (int i = 1; i <= loads.Count; i++)
            {
                GameObject.FindWithTag((string)loads[i]).GetComponent<PolygonCollider2D>().enabled = true; //Enabling collider for drug 'n' drop on all mass objects
            }
        }
        
       
    }
    //drag 'n' drop
    private void OnMouseDown()
    {   Vibration.Vibrate(30); //Vibration
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
    }
    private void OnMouseDrag()
    {
        if (isDragged)
        {
         

           transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
           if ((gameObject.tag == "load") || (gameObject.tag == "load_100") || (gameObject.tag == "load_200") || (gameObject.tag == "load_300") || (gameObject.tag == "load_400") || (gameObject.tag == "load_500") || (gameObject.tag == "load_600") || (gameObject.tag == "load_700") || (gameObject.tag == "load_800") || (gameObject.tag == "load_custom"))
            {
              
                
                if ((gameObject.transform.position.y > -0.1627356f)&& (gameObject.transform.position.x > -1.59f)&&(gameObject.transform.position.x < 0.417f))
                {
                    gameObject.transform.position = new Vector2(-0.56f, gameObject.transform.position.y);//v.x is hardcoded deliberately to force the object only make movement on y axis
                }
            }

        }
    }

    private void OnMouseUp()
    {
      //  spring_target.SetActive(false);

        isDragged = false;
        if ((gameObject.GetComponent<SpringJoint2D>()==null) && (gameObject.transform.position.x>-2.14f) && (gameObject.tag!="ruler"))
        {
             // gameObject.transform.position = load_dp;
            if (gameObject.tag == "load_100") gameObject.transform.position = load_100_dp;
            if (gameObject.tag == "load_200") gameObject.transform.position = load_200_dp;
            if (gameObject.tag == "load_300") gameObject.transform.position = load_300_dp;
            if (gameObject.tag == "load_400") gameObject.transform.position = load_400_dp;
            if (gameObject.tag == "load_custom") gameObject.transform.position = load_custom_dp;
   
        }
    }
    //end drag 'n' drop
}