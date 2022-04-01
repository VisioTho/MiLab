using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class negative_ions_particle_system : MonoBehaviour
{
    public Vector2 particle_system_position;
    public ParticleSystem pos_ps_go;
    ParticleSystem ps, pos_ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        pos_ps = pos_ps_go.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var main = ps.main;
        var main_pos_ps = pos_ps.main;
        particle_system_position = gameObject.transform.position;//getting current position of the particle system

        // Debug.Log(particle_system_position.x);
       // Debug.Log("cathode_pos" + GameObject.FindWithTag("cathode").transform.position.x);
     if (GameObject.FindWithTag("cathode").transform.position.x == 1.099679f) { 
         if (particle_system_position.x >= -0.23f && particle_system_position.x < -0.17f)
        {
            main.startLifetime = 0.45f;
            main_pos_ps.startLifetime = 0.1f;
        }
        else if (particle_system_position.x >= -0.17f && particle_system_position.x < 0.14f)
        {
            main.startLifetime = 0.40f;
            main_pos_ps.startLifetime = 0.2f;
        }
        else if (particle_system_position.x >= 0.14f && particle_system_position.x < 0.39f)
        {
            main.startLifetime = 0.3f;
            main_pos_ps.startLifetime = 0.25f;
        }
        else if (particle_system_position.x >= 0.39f && particle_system_position.x < 0.55f)
        {
            main.startLifetime = 0.25f;
            main_pos_ps.startLifetime = 0.3f;
        }
        else if (particle_system_position.x >= 0.55f)
        {
            main.startLifetime = 0.1f;
            main_pos_ps.startLifetime = 0.35f;
        }
        else
        {
            main.startLifetime = 0.5f;
            // main_pos_ps.startLifetime = 0.35f;
        } 
      }
    }
}
