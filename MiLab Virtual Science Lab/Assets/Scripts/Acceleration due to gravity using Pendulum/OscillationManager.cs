using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OscillationManager : MonoBehaviour
{
    [SerializeField] private Slider lengthSlider;
    [SerializeField] private GameObject clamp, Bob;
    private float initialClampPositiony,initialClampPositionx, initialBobPositionx,initialBobPositiony;
    [SerializeField] private TMP_Text lengthText, timerText;
    [SerializeField] private Rigidbody2D bob;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        initialClampPositiony = clamp.transform.position.y;
        initialClampPositionx = clamp.transform.position.x;
        initialBobPositionx = Bob.transform.position.x;
        initialBobPositiony = Bob.transform.position.y;
        startTime = Time.time;
    }
    private bool isSleeping=true;
    public void Oscillate()
    {
        bob.WakeUp();
        isSleeping=false;
    }
    public void stopOscillation()
    {
        bob.Sleep();
        isSleeping=true;
        Bob.transform.position = new Vector2(initialBobPositionx, initialBobPositiony);
    }

    public void adjustLength(float val)
    {

        if(val==0)
        {
            clamp.transform.position = new Vector2(initialClampPositionx, initialClampPositiony);
            lengthText.text = " 20CM";
        }
        else if(val==1) 
        {
            clamp.transform.position = new Vector2(initialClampPositionx, initialClampPositiony+1.0f);
            lengthText.text = " 40CM";
        }

        else if(val==2) 
        {
            clamp.transform.position = new Vector2(initialClampPositionx, initialClampPositiony+2.0f);
            lengthText.text = " 60CM";
        }
        else if(val==3)
        {
             clamp.transform.position = new Vector2(initialClampPositionx, initialClampPositiony+4.0f);
             lengthText.text = " 100CM";
        }

    }
    // Update is called once per frame
    int num=0;
    void Update()
    {    
        #region
        float t = Time.time - startTime;
        string min = ((int) t/60).ToString();
        string sec = t.ToString("f0");
        timerText.text = sec;
        #endregion
        
    }
    
  void FixedUpdate()
  {
  
  }

  void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D " +col.gameObject.name);
        if(col.gameObject.name=="oscillationpoint")
        {
            num++;
            Debug.Log(num);
        }
    }
}
