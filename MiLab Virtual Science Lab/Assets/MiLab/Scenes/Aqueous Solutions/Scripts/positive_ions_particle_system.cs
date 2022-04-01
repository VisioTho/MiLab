using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positive_ions_particle_system : MonoBehaviour
{
    public Vector2 particle_system_position;
    public ParticleSystem neg_ps_go;
    ParticleSystem ps, neg_ps;
    // Start is called before the first frame update
    void Start()
    {
       ps = GetComponent<ParticleSystem>();
       neg_ps = neg_ps_go.GetComponent<ParticleSystem>();
     }

    // Update is called once per frame
    void Update()
    {

        var main = ps.main;
        var main_ng_ps = neg_ps.main;
        particle_system_position =gameObject.transform.position;//getting current position of the particle system

         //Debug.Log("anode_pos"+GameObject.FindWithTag("anode").transform.position.x);
        if (GameObject.FindWithTag("anode").transform.position.x == -0.3903209f)
        {
            if (particle_system_position.x > 0.79f && particle_system_position.x <= 0.99f)
            {
                main.startLifetime = 0.30f;
                main_ng_ps.startLifetime = 0.25f;
            }
            else if (particle_system_position.x > 0.5f && particle_system_position.x <= 0.8f)
            {
                main.startLifetime = 0.25f;
                main_ng_ps.startLifetime = 0.3f;
            }
            else if (particle_system_position.x > 0.3f && particle_system_position.x <= 0.5f)
            {
                main.startLifetime = 0.20f;
                main_ng_ps.startLifetime = 0.40f;
            }
            else if (particle_system_position.x > -0.1f && particle_system_position.x <= 0.3f)
            {
                main.startLifetime = 0.1f;
                main_ng_ps.startLifetime = 0.45f;
            }
            else if (particle_system_position.x <= -0.1f)
            {
                main.startLifetime = 0.08f;
                main_ng_ps.startLifetime = 0.5f;
            }
            else
            {
                main.startLifetime = 0.35f;
                if (neg_ps_go.transform.position.x == -0.3903209f)
                {
                    main_ng_ps.startLifetime = 0.5f;
                }

            }
        }
        //
    }
}
