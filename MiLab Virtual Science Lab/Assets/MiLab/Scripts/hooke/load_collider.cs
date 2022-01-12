using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class load_collider : MonoBehaviour
{
    [SerializeField] public Rigidbody2D ml_rb, nl_rb;
    [SerializeField] public Slider _mass_slider;
    public Renderer render;
    public static bool drag_detached = false;
    [SerializeField] public GameObject stretchPointA, stretchPointB, spring;
    private float pointAposY, pointBposY, xSpringPos;
    public static Vector2 load_dp, stretchPointA_dp, stretchPointB_dp, nl_rb_dp, ml_rb_dp, spring_dp;//to be fetched from positions_controller class
    public static string current_hanged_mass=null; //to be used by other classes
    public static float current_slider_mass_value; //to be fetched from controller class
    public float gravitymultiplier = 0.01f;

    void Start()
    {
        render = ml_rb.GetComponent<Renderer>();

       //-------fetching from positions_controller-------//

        load_dp = positions_controller.load_dp;
        stretchPointA_dp = positions_controller.stretchPointA_dp;
        stretchPointB_dp = positions_controller.stretchPointB_dp;
        nl_rb_dp = positions_controller.nl_rb_dp;
        ml_rb_dp = positions_controller.ml_rb_dp;
        spring_dp= positions_controller.spring_dp;

       //----------------------------------------------//
    }
    //to run on update
   void Update()
    {
        current_slider_mass_value=controller.current_slider_mass_value;

        pointAposY = stretchPointA.transform.position.y;
        pointBposY = stretchPointB.transform.position.y;
        //xSpringPos = spring.transform.position.x;
        //Debug.Log("pA: "+pointAposY + "pB: " + pointBposY+" Srpx:"+xSpringPos);
        //Debug.Log(Vector2.Distance(new Vector2(-8.9719f, 2.8381f), new Vector2(-6.98f, 2.8381f)));
        //Debug.Log(Vector2.Distance(pointAposY, pointBposY));
        float spritesize = spring.GetComponent<SpriteRenderer>().sprite.rect.width / spring.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        Vector2 scale = spring.transform.localScale;
       // scale.y = (stretchPointA.transform.position.y+0.35f- stretchPointB.transform.position.y)/spritesize;//initial
       scale.y = (stretchPointA.transform.position.y - stretchPointB.transform.position.y+0.83f)/spritesize;
        //spring.transform.localScale = new Vector2(spring.transform.localScale.x ,(Vector2.Distance(pointAposY, pointBposY)));
        spring.transform.localScale = scale;
        spring.transform.position = new Vector2(spring.transform.position.x , (pointAposY + pointBposY) / 2);
        if (!drag_detached)
        {
            //trying to work around the misbehaving stretchPointB
            ml_rb.transform.position = ml_rb_dp; //resetting the postion of ml line
            stretchPointB.transform.position = stretchPointB_dp; //resetting position of stretchPointB
        }
  }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "stretchPointB")//collider
        {
            if ((gameObject.GetComponent<SpringJoint2D>() == null) && (gameObject.GetComponent<FixedJoint2D>() == null))//collidee
            {
                Vibration.Vibrate(60);//vibration on mass-attached

                gameObject.AddComponent<SpringJoint2D>();//collidee
                gameObject.AddComponent<FixedJoint2D>();
                SpringJoint2D spj = gameObject.GetComponent<SpringJoint2D>();
                FixedJoint2D fj = gameObject.GetComponent<FixedJoint2D>();
                Rigidbody2D rb2d = gameObject.GetComponent<Rigidbody2D>();
                spj.connectedBody = nl_rb;
                fj.connectedBody = ml_rb;
                spj.anchor = new Vector2(-1.700165e-07f, 2.5f);
                float connAnchorx = -0.0772457f, connAnchory = 11.75946f;
                spj.connectedAnchor = new Vector2(Mathf.Clamp(connAnchorx, -0.0772457f, -0.0772457f), Mathf.Clamp(connAnchorx, 11.75946f, 11.75946f));
                /*-----------------------------------------------------------------------
                  Setting the gravity scale depending on the mass of the load attached
                 ----------------------------------------------------------------------*/
                if (gameObject.tag == "load_100") rb2d.gravityScale=1f;
                if (gameObject.tag == "load_200") rb2d.gravityScale=2f;
                if (gameObject.tag == "load_300") rb2d.gravityScale=3f;
                if (gameObject.tag == "load_400") rb2d.gravityScale=4f;
                //if (gameObject.tag == "load_500") rb2d.gravityScale=5f;
                //if (gameObject.tag == "load_600") rb2d.gravityScale=6f;
                //if (gameObject.tag == "load_700") rb2d.gravityScale=7f;
                // if (gameObject.tag == "load_800") rb2d.gravityScale=8f;
                if (gameObject.tag == "load_custom") { 
                rb2d.gravityScale = gravitymultiplier*current_slider_mass_value;
                }
               
                

                /*------------------------------------------------
                                      ending
                 * ---------------------------------------------*/
                render.enabled = true;//showing movable line
                Destroy(GetComponent<drag_n_drop>());//detaching drag_n_drop script
                drag_detached = true;

                current_hanged_mass = gameObject.tag;//updating current active mass
                
            }
        }

    }
    //default'lize setup
    void OnMouseDown()
    {
        if (drag_detached) {

            Vibration.Vibrate(60);//vibration

            Rigidbody2D rb2d = gameObject.GetComponent<Rigidbody2D>();
            rb2d.gravityScale = 0;
            Destroy(gameObject.GetComponent<SpringJoint2D>());
            Destroy(gameObject.GetComponent<FixedJoint2D>());
           // transform.position = new Vector2(-3.55f, -3.03f);
            gameObject.AddComponent<drag_n_drop>(); //attaching drag_n_drop script
            drag_detached = false;
            render.enabled = false; //hiding movable line
            ml_rb.transform.position = ml_rb_dp; //resetting the postion of ml line
            stretchPointB.transform.position =stretchPointB_dp; //resetting position of stretchPointB
            current_hanged_mass = null; //updating current active mass
           
        }

    }

}
