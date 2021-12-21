using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class observation_dealer : MonoBehaviour
{

    public GameObject positivesToBeSpawned, switch_ob, negativesToBeSpawned, tryposTopMost, tryposBottomMost, tryposLeftMost, tryposRightMost, anode, cathode, attracted_positive_ions, attracted_negative_ions, empty_y_Particle_system, positive_ions_Particle_system, negative_ions_Particle_system;
    public float speed = 2f;
    public static bool switch_is_on;
    public bool restart_ob = false;
    public int doOnce = 0;
    //public GameObject positives[20] = new GameObject;
    public GameObject[] positive_ions, negative_ions;

    public bool already_spawned = false;
    //public Coroutine co = null;
    // public bool isSpawning = false;
    //public Coroutine showIons_trigger;

    public static float should_restart_observation;
    //Start is called before the first frame update
    void Start()
    {
        attracted_negative_ions.SetActive(false);  
        attracted_positive_ions.SetActive(false);
        negative_ions_Particle_system.SetActive(false);
        positive_ions_Particle_system.SetActive(false);
       // Debug.Log("tryposTopMost: " + tryposTopMost.transform.position);
       // Debug.Log("tryposBottomMost: " + tryposBottomMost.transform.position);
       // Debug.Log("tryposLeftMost: " + tryposLeftMost.transform.position);
       // Debug.Log("tryposRightMost: " + tryposRightMost.transform.position);
        
    }


    /*IEnumerator spawner()
    {
       if (!already_spawned && should_restart_observation!=0)
       {
           for (int i = 0; i <= 40; i++)
           {

               Vector3 randomPosPos = new Vector2(Random.Range(tryposLeftMost.transform.position.x, tryposRightMost.transform.position.x), Random.Range(tryposBottomMost.transform.position.y, tryposTopMost.transform.position.y));
               Vector3 randomPosNeg = new Vector2(Random.Range(tryposLeftMost.transform.position.x, tryposRightMost.transform.position.x), Random.Range(tryposBottomMost.transform.position.y, tryposTopMost.transform.position.y));
               GameObject spawneePos = Instantiate(positivesToBeSpawned, randomPosPos, Quaternion.identity) as GameObject;
               GameObject spawneeNeg = Instantiate(negativesToBeSpawned, randomPosNeg, Quaternion.identity) as GameObject;
               spawneePos.gameObject.tag = "instantiated_plus";
               spawneeNeg.gameObject.tag = "instantiated_minus";
               //positive_ions[i] = spawneePos;
              // Vector2.MoveTowards(spawneePos.transform.position, anode.transform.position, speed * Time.deltaTime);   
             positive_ions = GameObject.FindGameObjectsWithTag("instantiated_plus");
             negative_ions = GameObject.FindGameObjectsWithTag("instantiated_minus");
             already_spawned = true;

               if (i < 40)
               {
                   isSpawning = true;
               }
               else
               {
                   isSpawning = false;
               }

             yield return new WaitForSeconds(0.2f);

           }

         }


       /* foreach (var pos in positive_ions)
        {
            pos.transform.position = Vector2.MoveTowards(pos.transform.position, anode.transform.position, speed * Time.deltaTime);
        }*/

    //}
  /* IEnumerator showIons()
    { 
       
        yield return new WaitForSeconds(1);
       // Debug.Log("showed showed");
        attracted_negative_ions.SetActive(true);
        attracted_positive_ions.SetActive(true);
    }*/



    void Update()
    {
        switch_is_on = switch_controller.switch_is_on;
    should_restart_observation= solutionsDropdown.should_restart_observation;

       /* if (solutionsDropdown.should_restart_observation != 0f && solutionsDropdown.should_restart_observation != should_restart_observation)
        {
          

        }*/


    if(should_restart_observation!=0 && switch_is_on){
            empty_y_Particle_system.SetActive(true);
            negative_ions_Particle_system.SetActive(true);
            positive_ions_Particle_system.SetActive(true);
            attracted_negative_ions.SetActive(true);
            attracted_positive_ions.SetActive(true);
           // showIons_trigger = StartCoroutine(showIons());
            

        }
        else
        {
            empty_y_Particle_system.SetActive(false);
            negative_ions_Particle_system.SetActive(false);
            positive_ions_Particle_system.SetActive(false);
            attracted_negative_ions.SetActive(false);
            attracted_positive_ions.SetActive(false);

          //  StopCoroutine(showIons_trigger);
        }


       /* if (solutionsDropdown.should_restart_observation == 0f)
        {

           // restart_ob = false;
//////////////////////////////////////////////////////
            if (already_spawned)
            { //destroying positives
              already_spawned = false;
                foreach (var pos in positive_ions)
                {
                    Destroy(pos);
                }
                ///destroying negatives
                foreach (var neg in negative_ions)
                {
                    Destroy(neg);
                }
                
           }
            //////////////////////////////////////////////////////////////////
        }*/
        
           //////////////////////////////////////////////////////
       /* if (already_spawned && !switch_is_on)
        { 
            //destroying positives
            already_spawned = false;
            foreach (var pos in positive_ions)
            {
                Destroy(pos);
            }
            ///destroying negatives
            foreach (var neg in negative_ions)
            {
                Destroy(neg);
            }
         }*/
        /////////////////////////////////////////////////////////

    }
}
