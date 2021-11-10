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
        //load_500_dp = positions_controller.load_500_dp;
       //load_600_dp = positions_controller.load_600_dp;
       //load_700_dp = positions_controller.load_700_dp;
       //load_800_dp = positions_controller.load_800_dp;
       load_custom_dp = positions_controller.load_custom_dp;
        
    }

    // Update is called once per frame
    void Update()
    {
        //drag_detached = load_collider.drag_detached;  //accessing variable from load_colliders class
        current_hanged_mass = load_collider.current_hanged_mass;

        if (current_hanged_mass != null) {
             for (int i = 1; i <= loads.Count; i++)
               {
                   if (current_hanged_mass ==(string) loads[i]) { continue; }
                   GameObject.FindWithTag((string)loads[i]).GetComponent<PolygonCollider2D>().enabled=false;//Disabling collider for drug 'n' drop
            }
        }
        else
        {
            for (int i = 1; i <= loads.Count; i++)
            {
                GameObject.FindWithTag((string)loads[i]).GetComponent<PolygonCollider2D>().enabled = true;//Enabling collider for drug 'n' drop
            }
        }
        
       
    }
    //drag 'n' drop
    private void OnMouseDown()
    {
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

            //zoom ruler
            if (gameObject.tag == "ruler")
            {
               /* if (gameObject.transform.position.x > -6.34f)
                {
                     gameObject.transform.localScale = new Vector3(0.7024579f, 0.7024579f, 0.7024579f);
                  //gameObject.transform.localRotation = Quaternion.Euler(0f, 0f,0f);
                }
                else
                {
                     gameObject.transform.localScale = new Vector3(0.2866328f, 0.2866328f, 0.2866328f);
                   //gameObject.transform.localRotation = Quaternion.Euler(79.392f, -26.231f, -48.73f);
                   
                }*/
            }
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;
        if ((gameObject.GetComponent<SpringJoint2D>()==null) && (gameObject.transform.position.x>-2.14f) && (gameObject.tag!="ruler"))
        {
             // gameObject.transform.position = load_dp;
            if (gameObject.tag == "load_100") gameObject.transform.position = load_100_dp;
            if (gameObject.tag == "load_200") gameObject.transform.position = load_200_dp;
            if (gameObject.tag == "load_300") gameObject.transform.position = load_300_dp;
            if (gameObject.tag == "load_400") gameObject.transform.position = load_400_dp;
           //if (gameObject.tag == "load_500") gameObject.transform.position = load_500_dp;
           //if (gameObject.tag == "load_600") gameObject.transform.position = load_600_dp;
           //if (gameObject.tag == "load_700") gameObject.transform.position = load_700_dp;
          // if (gameObject.tag == "load_800") gameObject.transform.position = load_800_dp;
          if (gameObject.tag == "load_custom") gameObject.transform.position = load_custom_dp;
   
        }
    }
    //end drag 'n' drop
}
