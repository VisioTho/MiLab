using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OscillationManager : MonoBehaviour
{
    [SerializeField] private Slider lengthSlider;
    [SerializeField] private Button oscillateButton;
    [SerializeField] private GameObject clamp, Bob;
    private float initialClampPositiony,initialClampPositionx, initialBobPositionx,initialBobPositiony;
    [SerializeField] private TMP_Text lengthText, timerText;
    [SerializeField] private Rigidbody2D bob;
    private float startTime;
    int oscillationCounter=-1; //integer storing oscillation count 
    private float timer;
    private int stringLength;

    [SerializeField] private TMP_Text[] tableValues;

    [SerializeField] private GameObject[] tutorialBoxes;

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
        oscillateButton.interactable = false;
    }

    #region ..oscillation controls
    private bool isSleeping=true;
    private bool isReset=false;
    
    public void Oscillate()
    {

        startTime = Time.time;
        Time.timeScale = 1f;
        bool v = bob.IsSleeping();
        if (v && stringLength > 20)
        {
            transform.position = new Vector2(initialBobPositionx, initialBobPositiony);
            
            bob.WakeUp();
        }  
    }
    public void stopOscillation()
    {
        bob.Sleep();  
        //Bob.transform.position = new Vector2(initialBobPositionx, initialBobPositiony);
    }

    public void resetOscillation()
    {
        bob.Sleep();
        isReset =true;
        oscillationCounter=-1; //reset counter
    }
    #endregion

    #region ..string length controls
  
    public void adjustLength(float val)
    {
        Time.timeScale = 0f;
        oscillateButton.interactable = true;
        if(val==0)
        {
            clamp.transform.position = new Vector2(initialClampPositionx, initialClampPositiony);
            lengthText.text = "Move slider";
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

    private void Awake()
    {
        bob.Sleep();
    }
    // Update is called once per frame
    void Update()
    {    

        if(!bob.IsSleeping())
        {   
            float t = Time.time - startTime;
            string sec = t.ToString("f0");
            timer = t;
            timerText.text = sec;
            lengthSlider.enabled = false;
        }  
        else if(bob.IsSleeping())
        {
            lengthSlider.enabled=true;
        }
        
        //after every 10 oscillations of the bob, record the values for each length of pendulum
        if(oscillationCounter==10)
            {
                if(stringLength==100)
                {
                if (_100CM.timeTaken == 0 && _100CM.count == -1) //only record values when the object has not been written to
                {
                    _100CM.timeTaken = timer;
                    _100CM.count = oscillationCounter;
                }
                else //prevent the oscillation process from happening again if object is already written to
                {
                    oscillateButton.interactable = false;
                    lengthText.text = "Adjust to different length";
                }
                    
                }
                else if(stringLength==60)
                {
                    if(_60CM.timeTaken==0 && _60CM.count==-1)
                        {
                            _60CM.timeTaken = timer;
                            _60CM.count = oscillationCounter;
                        }
                    else //prevent the oscillation process from happening again if object is already written to
                    {
                        oscillateButton.interactable = false;
                        lengthText.text = "Adjust to different length";
                    }
            }
                else if(stringLength==40)
                {
                    if(_40CM.timeTaken==0 && _40CM.count==-1)
                    {
                        _40CM.timeTaken = timer;
                        _40CM.count = oscillationCounter;
                    }
                    else //prevent the oscillation process from happening again if object is already written to
                    {
                        oscillateButton.interactable = false;
                        lengthText.text = "Adjust to different length";
                    }

            }
            oscillationCounter = -1;
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
