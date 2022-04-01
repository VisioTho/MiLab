using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positions_controller : MonoBehaviour
{
    [SerializeField] public GameObject load, stretchPointA, stretchPointB, nl_rb, ml_rb, spring, load_100, load_200, load_300, load_400, load_custom;
    public static Vector2 load_dp, stretchPointA_dp, stretchPointB_dp, nl_rb_dp, ml_rb_dp, spring_dp, load_100_dp, load_200_dp, load_300_dp, load_400_dp, load_custom_dp, gte_500_lt_600_dp, gte_100_lt_200_dp, gte_250_lt_300_dp, gte_350_lt_400_dp, eq_400_dp;
    // Start is called before the first frame update
    void Start()
    {
        load_dp = load.transform.position;//to be discarded

        stretchPointA_dp = stretchPointA.transform.position;
        stretchPointB_dp = stretchPointB.transform.position;
        nl_rb_dp = nl_rb.transform.position;
        ml_rb_dp = ml_rb.transform.position;
        spring_dp = spring.transform.position;

        //deafult positions of the masses
        load_100_dp = load_100.transform.position;
        load_200_dp = load_200.transform.position;
        load_300_dp = load_300.transform.position;
        load_400_dp = load_400.transform.position;
        // load_500_dp = load_500.transform.position;
        // load_600_dp = load_600.transform.position;
        // load_700_dp = load_700.transform.position;
        // load_800_dp = load_800.transform.position;
        load_custom_dp = load_custom.transform.position;
        gte_500_lt_600_dp = new Vector2(-0.5f, -2.2f);
        gte_350_lt_400_dp = new Vector2(-0.5f, -2.2f);
        gte_250_lt_300_dp = new Vector2(-0.5f, -2.2f);
        gte_100_lt_200_dp = new Vector2(-0.5f, -2.4f);
        eq_400_dp = new Vector2(-0.5f, -2.2f);
    }

    // Update is called once per frame
       void Update()
    {
     
    }
}
