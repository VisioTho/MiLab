using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class load_collider : MonoBehaviour
{
    [SerializeField] public Rigidbody2D ml_rb, nl_rb;
    [SerializeField] public Slider _mass_slider, _spring_constant;
    public static bool drag_detached = false;
    [SerializeField] public GameObject stretchPointA, stretchPointB, spring;
    private float pointAposY, pointBposY, xSpringPos;
    public static Vector2 load_dp, stretchPointA_dp, stretchPointB_dp, nl_rb_dp, ml_rb_dp, spring_dp;//to be fetched from positions_controller class
    public static string current_hanged_mass = null; //to be used by other classes
    public static float current_slider_mass_value; //to be fetched from controller class
    public float gravitymultiplier, connAnchorx, connAnchory, gravityScale1, gravityScale2, gravityScale3, gravityScale4, gravityScale_5, gravityScale_1_5, gravityScale_2_5, gravityScale_3_5;
    public Vector2 connectedAnc, anchorConn;
    Renderer render;


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

        connectedAnc = new Vector2(-0.0772457f, 11.75946f);
        connAnchorx = -0.0772457f;
        connAnchory = 11.75946f;
        gravitymultiplier = 0.01f;

       gravityScale1 = 1.1f;
       gravityScale2 = 2.2f;
       gravityScale3 = 3.32f;
       gravityScale4 = 4.49f;
       gravityScale_5 = 0.5f;
       gravityScale_1_5 = 1.69f;
       gravityScale_2_5 = 2.83f;
       gravityScale_3_5 = 3.9f;

       anchorConn = new Vector2(-1.700165e-07f, 2.5f);

        //----------------------------------------------//
    }
    //to run on update
   void Update()
    {
        current_slider_mass_value=controller.current_slider_mass_value;

        pointAposY = stretchPointA.transform.position.y;
        pointBposY = stretchPointB.transform.position.y;

        float spritesize = spring.GetComponent<SpriteRenderer>().sprite.rect.width / spring.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        Vector2 scale = spring.transform.localScale;
        scale.y = (stretchPointA.transform.position.y - stretchPointB.transform.position.y+0.83f) / spritesize;
        spring.transform.localScale = scale;
        spring.transform.position = new Vector2(spring.transform.position.x , (pointAposY + pointBposY) / 2);        


        if (!drag_detached)
        {
            //trying to work around the misbehaving stretchPointB and movable line
            ml_rb.transform.position = ml_rb_dp; //resetting the postion of ml line
            stretchPointB.transform.position = stretchPointB_dp; //resetting position of stretchPointB
        }       
  }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "stretchPointB") //collider
        {
            if ((gameObject.GetComponent<SpringJoint2D>() == null) && (gameObject.GetComponent<FixedJoint2D>() == null))//collidee
            {
                Vibration.Vibrate(30);//vibration on mass-attached
                int sc = 4;
                gameObject.AddComponent<SpringJoint2D>();//collidee
                gameObject.AddComponent<FixedJoint2D>();
                SpringJoint2D spj = gameObject.GetComponent<SpringJoint2D>();
                FixedJoint2D fj = gameObject.GetComponent<FixedJoint2D>();
                Rigidbody2D rb2d = gameObject.GetComponent<Rigidbody2D>();
                spj.connectedBody = nl_rb;
                fj.connectedBody = ml_rb;
                spj.anchor = anchorConn;
                spj.connectedAnchor = connectedAnc;
                

                /*-----------------------------------------------------------------------
                 Setting the gravity scale depending on the mass of the load attached
                ----------------------------------------------------------------------*/
                float stiff_spring_subtractor = 0.3f;
                float stiffer_spring_subtractor = 0.45f;

                if (_spring_constant.value == 1)
                {//loose spring
                if (gameObject.tag == "load_100") rb2d.gravityScale = gravityScale1;
                if (gameObject.tag == "load_200") rb2d.gravityScale = gravityScale2;
                if (gameObject.tag == "load_300") rb2d.gravityScale = gravityScale3;
                if (gameObject.tag == "load_400") rb2d.gravityScale = gravityScale4;

                        if (gameObject.tag == "load_custom")
                        {
                            if (_mass_slider.value == 50f) rb2d.gravityScale = gravityScale_5;
                            if (_mass_slider.value == 100f) rb2d.gravityScale = gravityScale1;
                            if (_mass_slider.value == 150f) rb2d.gravityScale = gravityScale_1_5;
                            if (_mass_slider.value == 200f) rb2d.gravityScale = gravityScale2;
                            if (_mass_slider.value == 250f) rb2d.gravityScale = gravityScale_2_5;
                            if (_mass_slider.value == 300f) rb2d.gravityScale = gravityScale3;
                            if (_mass_slider.value == 350f) rb2d.gravityScale = gravityScale_3_5;
                            if (_mass_slider.value == 400f) rb2d.gravityScale = gravityScale4;
                        }
               }else if (_spring_constant.value == 2){//stiff spring
                     if (gameObject.tag == "load_100") rb2d.gravityScale = gravityScale1 - stiff_spring_subtractor;
                     if (gameObject.tag == "load_200") rb2d.gravityScale = gravityScale2 - stiff_spring_subtractor;
                     if (gameObject.tag == "load_300") rb2d.gravityScale = gravityScale3 - stiff_spring_subtractor;
                     if (gameObject.tag == "load_400") rb2d.gravityScale = gravityScale4 - stiff_spring_subtractor;

                     if (gameObject.tag == "load_custom")
                     {
                         if (_mass_slider.value == 50f) rb2d.gravityScale = gravityScale_5 - stiff_spring_subtractor;
                         if (_mass_slider.value == 100f) rb2d.gravityScale = gravityScale1 - stiff_spring_subtractor;
                         if (_mass_slider.value == 150f) rb2d.gravityScale = gravityScale_1_5 - stiff_spring_subtractor;
                         if (_mass_slider.value == 200f) rb2d.gravityScale = gravityScale2 - stiff_spring_subtractor;
                         if (_mass_slider.value == 250f) rb2d.gravityScale = gravityScale_2_5 - stiff_spring_subtractor;
                         if (_mass_slider.value == 300f) rb2d.gravityScale = gravityScale3 - stiff_spring_subtractor;
                         if (_mass_slider.value == 350f) rb2d.gravityScale = gravityScale_3_5 - stiff_spring_subtractor;
                         if (_mass_slider.value == 400f) rb2d.gravityScale = gravityScale4 - stiff_spring_subtractor;
                     }
                 }else {//stiffer spring
                             if (gameObject.tag == "load_100") rb2d.gravityScale = gravityScale1 - stiffer_spring_subtractor;
                             if (gameObject.tag == "load_200") rb2d.gravityScale = gravityScale2 - stiffer_spring_subtractor;
                             if (gameObject.tag == "load_300") rb2d.gravityScale = gravityScale3 - stiffer_spring_subtractor;
                             if (gameObject.tag == "load_400") rb2d.gravityScale = gravityScale4 - stiffer_spring_subtractor;

                             if (gameObject.tag == "load_custom")
                             {
                                 if (_mass_slider.value == 50f) rb2d.gravityScale = gravityScale_5 - stiffer_spring_subtractor;
                                 if (_mass_slider.value == 100f) rb2d.gravityScale = gravityScale1 - stiffer_spring_subtractor;
                                 if (_mass_slider.value == 150f) rb2d.gravityScale = gravityScale_1_5 - stiffer_spring_subtractor;
                                 if (_mass_slider.value == 200f) rb2d.gravityScale = gravityScale2 - stiffer_spring_subtractor;
                                 if (_mass_slider.value == 250f) rb2d.gravityScale = gravityScale_2_5 - stiffer_spring_subtractor;
                                 if (_mass_slider.value == 300f) rb2d.gravityScale = gravityScale3 - stiffer_spring_subtractor;
                                 if (_mass_slider.value == 350f) rb2d.gravityScale = gravityScale_3_5 - stiffer_spring_subtractor;
                                 if (_mass_slider.value == 400f) rb2d.gravityScale = gravityScale4 - stiffer_spring_subtractor;
                             }
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


    //default'lize spring setup
    void OnMouseDown()
    {
        if (drag_detached) {

            Vibration.Vibrate(45);//vibration

            Rigidbody2D rb2d = gameObject.GetComponent<Rigidbody2D>();
            rb2d.gravityScale = 0;
            Destroy(gameObject.GetComponent<SpringJoint2D>());
            Destroy(gameObject.GetComponent<FixedJoint2D>());
            gameObject.AddComponent<drag_n_drop>(); //attaching drag_n_drop script
            drag_detached = false;
            render.enabled = false; //hiding movable line
            ml_rb.transform.position = ml_rb_dp; //resetting the postion of ml line
            stretchPointB.transform.position = stretchPointB_dp; //resetting position of stretchPointB
            current_hanged_mass = null; //updating current active mass          
        }
   }
}