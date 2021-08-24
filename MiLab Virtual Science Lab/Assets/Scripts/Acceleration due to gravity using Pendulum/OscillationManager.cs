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
    int oscillationCounter=-1; //integer storing oscillation count 
    private float timer;
    private int stringLength;

    [SerializeField] private TMP_Text[] tableValues;

    public class Oscillations
    {
        public float timeTaken, count, length, timeForOneOscillation;

        public Oscillations()
        {
            timeTaken=0;
            count = -1;
            length=0;
        }

        public float getTimeForOneOscillation()
        {
            return 0.1f*this.timeTaken;
        }
        public float getTSquared()
        {
            return (0.1f*this.timeTaken)*(0.1f*this.timeTaken);
        }
    }

    public Oscillations _20CM = new Oscillations();
    public Oscillations _40CM = new Oscillations();
    public Oscillations _60CM = new Oscillations();
    public Oscillations _100CM = new Oscillations();


    // Start is called before the first frame update
    void Start()
    {
        lengthSlider.enabled = true;
        Time.timeScale = 0f;
        initialClampPositiony = clamp.transform.position.y;
        initialClampPositionx = clamp.transform.position.x;
        initialBobPositionx = Bob.transform.position.x;
        initialBobPositiony = Bob.transform.position.y;
        startTime = Time.time;
    }

    #region ..oscillation controls
    private bool isSleeping=true;
    private bool isReset=false;
    public void Oscillate()
    {
        transform.position = new Vector2(initialBobPositionx, initialBobPositiony);
        Time.timeScale = 1f;
        bob.WakeUp();
        isSleeping=false;  
    }
    public void stopOscillation()
    {
        bob.Sleep();  
        //Bob.transform.position = new Vector2(initialBobPositionx, initialBobPositiony);
    }

    public void resetOscillation()
    {
        Time.timeScale =0f;
        bob.Sleep();
        startTime = Time.time;
        isReset =true;
        oscillationCounter=-1;
        isSleeping=true;
    }
    #endregion

    #region ..string length controls
    
    public void adjustLength(float val)
    {

        if(val==0)
        {
            clamp.transform.position = new Vector2(initialClampPositionx, initialClampPositiony);
            lengthText.text = " 20CM";
            stringLength=20;
        }
        else if(val==1) 
        {
            clamp.transform.position = new Vector2(initialClampPositionx, initialClampPositiony+1.0f);
            lengthText.text = " 40CM";
            stringLength=40;
        }

        else if(val==2) 
        {
            clamp.transform.position = new Vector2(initialClampPositionx, initialClampPositiony+2.0f);
            lengthText.text = " 60CM";
            stringLength=60;
        }
        else if(val==3)
        {
             clamp.transform.position = new Vector2(initialClampPositionx, initialClampPositiony+4.0f);
             lengthText.text = " 100CM";
             stringLength=100;
        }

    }
    #endregion
    // Update is called once per frame
    void Update()
    {    
        if(!isSleeping)
        {   
            float t = Time.time - startTime;
            string sec = t.ToString("f0");
            timer = t;
            timerText.text = sec;
            lengthSlider.enabled = false;
        }  
        else
        {
            lengthSlider.enabled=true;
        }
        
        //Debug.Log(stringLength);
        if(oscillationCounter==10)
            {
                if(stringLength==100)
                {
                    if(_100CM.timeTaken==0 && _100CM.count==-1)
                        {
                            _100CM.timeTaken = timer;
                            _100CM.count = oscillationCounter;
                        }
                }
                else if(stringLength==60)
                {
                    if(_60CM.timeTaken==0 && _60CM.count==-1)
                        {
                            _60CM.timeTaken = timer;
                            _60CM.count = oscillationCounter;
                        }
                }
                else if(stringLength==40)
                {
                    if(_40CM.timeTaken==0 && _40CM.count==-1)
                    {
                        _40CM.timeTaken = timer;
                        _40CM.count = oscillationCounter;
                    }
  
                }
            tabulateResults();
            resetOscillation();
            }
    }

    void tabulateResults()
    {
        tableValues[0].text = _40CM.timeTaken.ToString("f2");
        tableValues[1].text = _40CM.getTimeForOneOscillation().ToString("f2");
        tableValues[2].text = _40CM.getTSquared().ToString("f2");
    
        tableValues[3].text = _60CM.timeTaken.ToString("f2");
        tableValues[4].text = _60CM.getTimeForOneOscillation().ToString("f2");
        tableValues[5].text = _60CM.getTSquared().ToString("f2");

        tableValues[6].text = _100CM.timeTaken.ToString("f2");
        tableValues[7].text = _100CM.getTimeForOneOscillation().ToString("f2");
        tableValues[8].text = _100CM.getTSquared().ToString("f2");
    }
    

  [SerializeField] private TMP_Text oscillationText;
  void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name=="oscillationpoint")
        {
            if(oscillationCounter<0)
            {
             oscillationText.text = "0";
            }
            oscillationCounter++;
            oscillationText.text = oscillationCounter.ToString();    
        }
    }
}
