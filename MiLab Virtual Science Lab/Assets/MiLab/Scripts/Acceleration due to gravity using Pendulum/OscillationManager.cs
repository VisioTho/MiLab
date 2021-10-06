using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OscillationManager : MonoBehaviour
{
    [SerializeField] private Slider lengthSlider;
    [SerializeField] private Button oscillateButton, stopOscillationButton;
    [SerializeField] private GameObject clamp, Bob;
    private float initialClampPositiony, initialClampPositionx, initialBobPositionx, initialBobPositiony;
    [SerializeField] private TMP_Text lengthText, timerText;
    [SerializeField] private Rigidbody2D bob;
    private float startTime = 0f, stopWatchTime;
    int oscillationCounter = -1; //integer storing oscillation count 
    private float timer;
    private int stringLength;
    public Slider gravityScaleSlider;
    public TMP_Dropdown gravityScaleSelector;

    public GameObject handGlowSprite, handNoGlowSprite;

    [SerializeField] private TMP_Text[] tableValues;

    [SerializeField] private GameObject[] tutorialBoxes;

    [SerializeField] private GameObject[] checkmarks;

    public class Oscillations
    {
        public float timeTaken, count, length, timeForOneOscillation;

        public Oscillations()
        {
            timeTaken = 0;
            count = -1;
            length = 0;
        }

        public float getTimeForOneOscillation()
        {
            return 0.1f * this.timeTaken;
        }
        public float getTSquared()
        {
            return (0.1f * this.timeTaken) * (0.1f * this.timeTaken);
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
        initialClampPositiony = clamp.transform.position.y;
        initialClampPositionx = clamp.transform.position.x;
        initialBobPositionx = Bob.transform.position.x;
        initialBobPositiony = Bob.transform.position.y;
        oscillateButton.interactable = false;
    
    }


    private bool isReset = false;

    public void ResetPendulum()
    {
        Bob.transform.position = new Vector2(initialBobPositionx, Bob.transform.position.y);
        bob.Sleep();
    }

    private Vector2 currentBobPosition;
    

    private void FixedUpdate()
    {
      
    }

    public void ChangeLength(float value)
    {
        Debug.Log("adjusted");
        Bob.transform.position = new Vector2(currentBobPosition.x, value);
    }
    public void AdjustGravity(float val)
    {
        bob.gravityScale = val;
        if (val != 5 && val != 10 && val!=0)
            gravityScaleSelector.value = 3;
        Debug.Log("adjust");
    }
    public void SelectGravityScale(int val)
    {
        float gravity = 0;
        if (val == 0)
        {
            gravity = 5;
            bob.gravityScale = gravity;
        }
        if (val == 1)
        {
            gravity = 0;
            bob.gravityScale = gravity;
        }
        if (val == 2)
        {
            gravity = 10;
            bob.gravityScale = gravity;
        }
        if (val == 3)
        {
            gravity = gravityScaleSlider.value;
        }
        gravityScaleSlider.value = gravity;
    }
    
    // Update is called once per frame
    void Update()
    {
        currentBobPosition = Bob.transform.position;
        //start stopwatch counter when the bob is activated i.e starts oscillating
        if(!bob.IsSleeping())
        {   
            if(Time.timeScale!=0f)
            {
                
            }
            stopOscillationButton.interactable = true;
            //lengthSlider.enabled = false;
        }  
        else if(bob.IsSleeping())
        {
            lengthSlider.enabled=true;
            stopOscillationButton.interactable = false;
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
                    checkmarks[2].SetActive(true);
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
                            checkmarks[1].SetActive(true);
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
                        checkmarks[0].SetActive(true);
                }
                    else //prevent the oscillation process from happening again if object is already written to
                    {
                        oscillateButton.interactable = false;
                        lengthText.text = "Adjust to different length";
                    }

            }
            oscillationCounter = -1;
            tabulateResults();
            
            }

    }

    void tabulateResults()
    {
        tableValues[0].text = _40CM.timeTaken.ToString("f2");
       // tableValues[1].text = _40CM.getTimeForOneOscillation().ToString("f2");
       // tableValues[2].text = _40CM.getTSquared().ToString("f2");
    
        tableValues[3].text = _60CM.timeTaken.ToString("f2");
        //tableValues[4].text = _60CM.getTimeForOneOscillation().ToString("f2");
       // tableValues[5].text = _60CM.getTSquared().ToString("f2");

        tableValues[6].text = _100CM.timeTaken.ToString("f2");
        //tableValues[7].text = _100CM.getTimeForOneOscillation().ToString("f2");
        //tableValues[8].text = _100CM.getTSquared().ToString("f2");
    }

  void glowHandSprite()
    {
        handGlowSprite.SetActive(true);
        handNoGlowSprite.SetActive(false);
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
