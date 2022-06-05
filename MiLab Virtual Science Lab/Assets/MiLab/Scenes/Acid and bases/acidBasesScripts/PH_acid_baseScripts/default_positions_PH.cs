using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class default_positions_PH : MonoBehaviour
{
    public GameObject pippete, hydrochloric_acid_beaker, ethanoic_acid_beaker, sodium_hydroxide_beaker, ammonium_solution_beaker, bound_hA, bound_hB, bound_hC, bound_hD, bound_hE;
    public static float pippete_y_position;
    public static Vector3 hydrochloric_acid_beaker_position, ethanoic_acid_beaker_position, sodium_hydroxide_beaker_position, ammonium_solution_beaker_position;
    // Start is called before the first frame update
    void Start()
    {
        //Repositioning the beakers before getting their default positions
        hydrochloric_acid_beaker.transform.position = new Vector2((bound_hA.transform.position.x + bound_hB.transform.position.x) / 2, hydrochloric_acid_beaker.transform.position.y);
        ethanoic_acid_beaker.transform.position = new Vector2((bound_hB.transform.position.x + bound_hC.transform.position.x) / 2, hydrochloric_acid_beaker.transform.position.y);//all beakers are on the same y-axis position
        sodium_hydroxide_beaker.transform.position = new Vector2((bound_hC.transform.position.x + bound_hD.transform.position.x) / 2, hydrochloric_acid_beaker.transform.position.y);
        ammonium_solution_beaker.transform.position = new Vector2((bound_hD.transform.position.x + bound_hE.transform.position.x) / 2, hydrochloric_acid_beaker.transform.position.y);



        //getting default positions
        pippete_y_position = pippete.transform.position.y;
        hydrochloric_acid_beaker_position = hydrochloric_acid_beaker.transform.position;
        ethanoic_acid_beaker_position = ethanoic_acid_beaker.transform.position;
        sodium_hydroxide_beaker_position = sodium_hydroxide_beaker.transform.position;
        ammonium_solution_beaker_position = ammonium_solution_beaker.transform.position;
    }
    void Update()
    {
      //  hydrochloric_acid_beaker.transform.position = hydrochloric_acid_beaker_position;
       // ethanoic_acid_beaker.transform.position = ethanoic_acid_beaker_position;
       // sodium_hydroxide_beaker.transform.position = sodium_hydroxide_beaker_position;
        //ammonium_solution_beaker.transform.position = ammonium_solution_beaker_position;
    }
}
