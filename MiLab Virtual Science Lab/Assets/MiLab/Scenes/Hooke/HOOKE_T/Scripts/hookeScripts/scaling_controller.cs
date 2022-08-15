using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class scaling_controller : MonoBehaviour
{
    [SerializeField] public Slider _massSlider;
    [SerializeField] public GameObject _load_custom, load_100, load_200, load_300, load_400;
    public float xVectorMultiplier = 0.0001178342625f;
    public float yVectorMultiplier = 0.0001289075f;
    public float zVectorMultiplier = 0.0005191605f;
    public float _massValue;
    public static Vector2 gte_500_lt_600_dp, gte_100_lt_200_dp, gte_250_lt_300_dp, gte_350_lt_400_dp, eq_400_dp, lcp;
    // Start is called before the first frame update
    void Start()
    {
        _massSlider.onValueChanged.AddListener((v) =>
        {
            update_position();
        });
        }

    // Update is called once per frame
    void Update()
    {
        _load_custom.SetActive(true);
        //Debug.Log(_load_custom.transform.position);
        gte_100_lt_200_dp = positions_controller.gte_100_lt_200_dp;
        gte_500_lt_600_dp = positions_controller.gte_500_lt_600_dp;
        gte_250_lt_300_dp = positions_controller.gte_250_lt_300_dp;
        gte_350_lt_400_dp = positions_controller.gte_350_lt_400_dp;
        eq_400_dp = positions_controller.eq_400_dp;

         _massValue = _massSlider.value;
        if (_massValue == 50f) _load_custom.transform.localScale = new Vector3(xVectorMultiplier * 200f, yVectorMultiplier * 200f, zVectorMultiplier * 200f);
        if (_massValue == 100f) _load_custom.transform.localScale = load_100.transform.localScale;
        if (_massValue == 150f) _load_custom.transform.localScale = (load_100.transform.localScale + new Vector3(xVectorMultiplier * 30f, yVectorMultiplier * 30f, zVectorMultiplier * 30f));
        if (_massValue == 200f) _load_custom.transform.localScale = load_200.transform.localScale;
        if (_massValue == 250f) _load_custom.transform.localScale = (load_200.transform.localScale + new Vector3(xVectorMultiplier * 50f, yVectorMultiplier * 50f, zVectorMultiplier * 50f));
        if (_massValue == 300f) _load_custom.transform.localScale = load_300.transform.localScale;
        if (_massValue == 350f) _load_custom.transform.localScale = (load_300.transform.localScale + new Vector3(xVectorMultiplier * 50f, yVectorMultiplier * 50f, zVectorMultiplier * 50f));
        if (_massValue == 400f) _load_custom.transform.localScale = load_400.transform.localScale;
        if (_massValue == 450f) _load_custom.transform.localScale = (load_400.transform.localScale + new Vector3(xVectorMultiplier * 50f, yVectorMultiplier * 50f, zVectorMultiplier * 50f));
        if (_massValue == 500f) _load_custom.transform.localScale = (load_400.transform.localScale + new Vector3(xVectorMultiplier * 70f, yVectorMultiplier * 70f, zVectorMultiplier * 70f));
        if (_massValue == 550f) _load_custom.transform.localScale = (load_400.transform.localScale + new Vector3(xVectorMultiplier * 90f, yVectorMultiplier * 90f, zVectorMultiplier * 90f));
        if (_massValue == 600f) _load_custom.transform.localScale = (load_400.transform.localScale + new Vector3(xVectorMultiplier * 110f, yVectorMultiplier * 110f, zVectorMultiplier * 110f));
    }


    void update_position()
    {

        //well positioning depending on size
       /* if ((_massValue >= 100f) && (_massValue <= 200f))
        {
          //  _load_custom.transform.position = gte_100_lt_200_dp;
            _load_custom.transform.DOMove(new Vector3(-0.5f, -2.4f, 0f), 1);
        }
        if ((_massValue >= 500f) && (_massValue <= 600f))
        {
            //   _load_custom.transform.position = gte_500_lt_600_dp;
            _load_custom.transform.DOMove(new Vector3(-0.5f, -2.2f, 0f), 1);
        }
        if ((_massValue >= 250f) && (_massValue <= 300f))
        {
            // _load_custom.transform.position = gte_250_lt_300_dp;
            _load_custom.transform.DOMove(new Vector3(-0.5f, -2.2f, 0f), 1);
        }
        if ((_massValue >= 350f) && (_massValue <= 400f))
        {
            //_load_custom.transform.position = gte_350_lt_400_dp;
            _load_custom.transform.DOMove(new Vector3(-0.5f, -2.2f, 0f), 1);
        }
        if (_massValue == 400f)
        {
            //_load_custom.transform.position = eq_400_dp;
            _load_custom.transform.DOMove(new Vector3(-0.5f, -2.2f, 0f), 1);
        }*/
    }
}