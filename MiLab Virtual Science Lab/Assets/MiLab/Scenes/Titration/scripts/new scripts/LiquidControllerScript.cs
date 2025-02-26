using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
//using System.Linq;

public class LiquidControllerScript : MonoBehaviour
{
    public Titration_Drop_Controller dropController;
    public MolesController molesController;
    public ConicalFlaskVolume ConicalFlaskVolume;
    // public ShakeEffectHandler ShakeEffectHandler;
    public Image content;
    [SerializeField]
    public Stat fill;
    public GameObject liquidFlowParticle, stream, phenopthalein, methyl; //flowStream;
    public ParticleSystem DropParticle;

    IEnumerator dropSolution, flowController, fillBurette;
    public Slider buretteKnob;
    public bool pipetteDrop;
    private float valueHolder;
    private float fillDifference;

    public TMP_Text analyteNotation;
    public TMP_Dropdown titrantVariation, analyteVariation, indicatorVariation, resetDropdown;
    public Button resetButton;
    public Toggle beakerToggle;


    private bool isTransformed;
    public float time = 0;
    public float duration = 8;
    // private bool hasTitrated;

    // public SpriteRenderer mat;
    public SpriteRenderer indicatorDrop;

    private void Awake()
    {
        fill.Initialize();
        dropSolution = LiquidDrop();
        fillBurette = LiquidFill();
        flowController = LiquidFlow();
    }

    void Start()
    {
        isTransformed = false;
        buretteKnob.minValue = 0;
        buretteKnob.maxValue = 2;
        buretteKnob.wholeNumbers = true;

        fill.CurrentVal = 0;
        content.fillAmount = 0;
    }
    void Update()
    {
        void shakeHandler()
        {
            if (ShakeEffectHandler.isShaking)
            {
                ColorlessTransition(7);
            }
            else
            {
                ColorlessTransition(14);
            }
        }
        if (content.fillAmount == 0f)
        {
            var localReftoParticle = DropParticle.main;
            localReftoParticle.playOnAwake = false;
            DropParticle.Stop();

            // molesController.BMoles1.interactable = true;
            // molesController.BMoles2.interactable = true;
        }
        else if (content.fillAmount > 0f)
        {
            var localReftoParticle = DropParticle.main;
            localReftoParticle.playOnAwake = true;
        }
        if (indicatorVariation.value == 0)
        {
            phenopthalein.SetActive(true);
            methyl.SetActive(false);
            indicatorDrop.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
        else if (indicatorVariation.value == 1)
        {
            methyl.SetActive(true);
            phenopthalein.SetActive(false);
            indicatorDrop.GetComponent<SpriteRenderer>().color = new Color32(238, 218, 107, 255);
        }

        if (isTransformed == true)
        {
            valueHolder = fill.currentVal;
        }
        if (isTransformed == false)
        {
            fillDifference = valueHolder - fill.CurrentVal;
        }
        Debug.Log("fill Difference is " + fillDifference);
        if (indicatorVariation.value == 0 && (buretteKnob.value == 1 || buretteKnob.value == 2)) // using phenophthlaine as indicator
        {
            if (analyteVariation.value == 0 && titrantVariation.value == 0 && !isTransformed)
            {
                if (molesController.burette_moles > 0)
                {
                    if (molesController.burette_moles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference >= 7f && fillDifference <= 9f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference >= 7f && fillDifference <= 9f) && pipetteDrop)
                            {
                                if (ShakeEffectHandler.isShaking)
                                {
                                    ColorlessTransition(7);
                                }
                                else
                                {
                                    ColorlessTransition(15);
                                }
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 17.5f || fillDifference == 18f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 17.5f || fillDifference == 18f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                    }
                    else if (molesController.burette_moles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 2.5f || fillDifference == 3f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 2.5f || fillDifference == 3f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 5f || fillDifference == 6.5f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 5f || fillDifference == 6.5f) && pipetteDrop)
                            {
                                shakeHandler();
                            }

                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 7.5f || fillDifference == 8f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 7.5f || fillDifference == 8f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                    }

                }
                else if (molesController.conicalFlaskMoles > 0)
                {
                    if (molesController.conicalFlaskMoles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 19.5f || fillDifference == 20f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 19.55f || fillDifference == 20f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                    }
                    else if (molesController.conicalFlaskMoles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 13f || fillDifference == 13.5f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 13f || fillDifference == 13.5f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                    }

                }
                else
                {

                    if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                    {
                        if ((fillDifference == 5f || fillDifference == 6.5f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                        {
                            ColorlessTransition(5);
                        }
                        else if ((fillDifference == 5f || fillDifference == 6.5f) && pipetteDrop)
                        {
                            shakeHandler();
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                    {
                        if ((fillDifference == 10f || fillDifference == 10.5f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                        {
                            ColorlessTransition(5);
                        }
                        else if ((fillDifference == 10f || fillDifference == 10.5f) && pipetteDrop)
                        {
                            shakeHandler();
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == 20)
                    {
                        if ((fillDifference == 14f || fillDifference == 13.5f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                        {
                            ColorlessTransition(5);
                        }
                        else if ((fillDifference == 14f || fillDifference == 13.5f) && pipetteDrop)
                        {
                            shakeHandler();
                        }
                    }
                }

            }
            if (analyteVariation.value == 0 && titrantVariation.value == 0 && !isTransformed)
            {
                if (molesController.burette_moles > 0)
                {
                    if (molesController.burette_moles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 10.5f || fillDifference == 10f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 10.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                if (ShakeEffectHandler.isShaking)
                                {
                                    ColorlessTransition(7);
                                }
                                else
                                {
                                    ColorlessTransition(15);
                                }
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 17.5f || fillDifference == 18f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 17.5f || fillDifference == 18f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                    }
                    else if (molesController.burette_moles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 2.5f || fillDifference == 3f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 2.5f || fillDifference == 3f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 5f || fillDifference == 6.5f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 5f || fillDifference == 6.5f) && pipetteDrop)
                            {
                                shakeHandler();
                            }

                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                    }

                }
                else if (molesController.conicalFlaskMoles > 0)
                {
                    if (molesController.conicalFlaskMoles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 19.5f || fillDifference == 20f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 19.55f || fillDifference == 20f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                    }
                    else if (molesController.conicalFlaskMoles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 13f || fillDifference == 13.5f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                            {
                                ColorlessTransition(5);
                            }
                            else if ((fillDifference == 13f || fillDifference == 13.5f) && pipetteDrop)
                            {
                                shakeHandler();
                            }
                        }
                    }

                }
                else
                {

                    if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                    {
                        if ((fillDifference == 5f || fillDifference == 6.5f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                        {
                            ColorlessTransition(5);
                        }
                        else if ((fillDifference == 5f || fillDifference == 6.5f) && pipetteDrop)
                        {
                            shakeHandler();
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                    {
                        if ((fillDifference == 10f || fillDifference == 10.5f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                        {
                            ColorlessTransition(5);
                        }
                        else if ((fillDifference == 10f || fillDifference == 10.5f) && pipetteDrop)
                        {
                            shakeHandler();
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == 20)
                    {
                        if ((fillDifference == 14f || fillDifference == 13.5f) && pipetteDrop && ShakeEffectHandler.isShaking == true)
                        {
                            ColorlessTransition(5);
                        }
                        else if ((fillDifference == 14f || fillDifference == 13.5f) && pipetteDrop)
                        {
                            shakeHandler();
                        }
                    }
                }

            }
            //base to acid
            if (analyteVariation.value == 1 && titrantVariation.value == 1 && !isTransformed)
            {
                if (molesController.burette_moles > 0)
                {
                    if (molesController.burette_moles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 13.5f || fillDifference == 14f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 18.5f || fillDifference == 19f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                    }
                    else if (molesController.burette_moles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 3.5f || fillDifference == 4f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 5.5f || fillDifference == 6f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 8.5f || fillDifference == 9f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5); ;
                            }
                        }
                    }

                }
                else if (molesController.conicalFlaskMoles > 0)
                {
                    if (molesController.conicalFlaskMoles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 14.5f || fillDifference == 15f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 20.5f || fillDifference == 21f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                    }
                    else if (molesController.conicalFlaskMoles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5); ;
                            }
                        }
                    }

                }
                else
                {

                    if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                    {
                        if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                        {
                            ColorlessTransition(5);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                    {
                        if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                        {
                            ColorlessTransition(5);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == 20)
                    {
                        if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                        {
                            ColorlessTransition(5); ;
                        }
                    }
                }

            }
            if (analyteVariation.value == 3 && titrantVariation.value == 1 && !isTransformed)
            {
                if (molesController.burette_moles > 0)
                {
                    if (molesController.burette_moles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 10.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 13.5f || fillDifference == 14f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 18.5f || fillDifference == 19f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                    }
                    else if (molesController.burette_moles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 3.5f || fillDifference == 4f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 5.5f || fillDifference == 6f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 8.5f || fillDifference == 9f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8); ;
                            }
                        }
                    }

                }
                else if (molesController.conicalFlaskMoles > 0)
                {
                    if (molesController.conicalFlaskMoles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 14.5f || fillDifference == 15f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 20.5f || fillDifference == 21f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                    }
                    else if (molesController.conicalFlaskMoles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                    }

                }
                else
                {

                    if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                    {
                        if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                        {
                            ColorlessTransition(8);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                    {
                        if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                        {
                            ColorlessTransition(8);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == 20)
                    {
                        if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                        {
                            ColorlessTransition(8); ;
                        }
                    }
                }

            }
            if (analyteVariation.value == 0 && titrantVariation.value == 2 && !isTransformed)
            {
                if (molesController.burette_moles > 0)
                {
                    if (molesController.burette_moles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 7.5f || fillDifference == 8f) && pipetteDrop)
                            {
                                ColorlessTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop)
                            {
                                ColorlessTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 17.5f || fillDifference == 18f) && pipetteDrop)
                            {
                                ColorlessTransition(6);
                            }
                        }
                    }
                    else if (molesController.burette_moles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 2.5f || fillDifference == 3f) && pipetteDrop)
                            {
                                ColorlessTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 5f || fillDifference == 6.5f) && pipetteDrop)
                            {
                                ColorlessTransition(7);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 7.5f || fillDifference == 8f) && pipetteDrop)
                            {
                                ColorlessTransition(5); ;
                            }
                        }
                    }

                }
                else if (molesController.conicalFlaskMoles > 0)
                {
                    if (molesController.conicalFlaskMoles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                ColorlessTransition(7);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop)
                            {
                                ColorlessTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 19.5f || fillDifference == 20f) && pipetteDrop)
                            {
                                ColorlessTransition(6);
                            }
                        }
                    }
                    else if (molesController.conicalFlaskMoles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                            {
                                ColorlessTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                            {
                                ColorlessTransition(7);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                            {
                                ColorlessTransition(7); ;
                            }
                        }
                    }

                }
                else
                {

                    if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                    {
                        if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                        {
                            ColorlessTransition(7);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                    {
                        if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                        {
                            ColorlessTransition(7);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == 20)
                    {
                        if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                        {
                            ColorlessTransition(7); ;
                        }
                    }
                }

            }
            if (analyteVariation.value == 2 && titrantVariation.value == 2 && !isTransformed)
            {
                if (molesController.burette_moles > 0)
                {
                    if (molesController.burette_moles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 7.5f || fillDifference == 8f) && pipetteDrop)
                            {
                                ColorlessTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop)
                            {
                                ColorlessTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 17.5f || fillDifference == 18f) && pipetteDrop)
                            {
                                ColorlessTransition(6);
                            }
                        }
                    }
                    else if (molesController.burette_moles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 2.5f || fillDifference == 3f) && pipetteDrop)
                            {
                                ColorlessTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 5f || fillDifference == 6.5f) && pipetteDrop)
                            {
                                ColorlessTransition(7);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 7.5f || fillDifference == 8f) && pipetteDrop)
                            {
                                ColorlessTransition(5); ;
                            }
                        }
                    }

                }
                else if (molesController.conicalFlaskMoles > 0)
                {
                    if (molesController.conicalFlaskMoles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                ColorlessTransition(7);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop)
                            {
                                ColorlessTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 19.5f || fillDifference == 20f) && pipetteDrop)
                            {
                                ColorlessTransition(6);
                            }
                        }
                    }
                    else if (molesController.conicalFlaskMoles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                            {
                                ColorlessTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                            {
                                ColorlessTransition(7);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                            {
                                ColorlessTransition(7); ;
                            }
                        }
                    }

                }
                else
                {

                    if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                    {
                        if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                        {
                            ColorlessTransition(7);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                    {
                        if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                        {
                            ColorlessTransition(7);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == 20)
                    {
                        if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                        {
                            ColorlessTransition(7); ;
                        }
                    }
                }

            }
            if (analyteVariation.value == 1 && titrantVariation.value == 3 && !isTransformed)
            {
                if (molesController.burette_moles > 0)
                {
                    if (molesController.burette_moles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 13.5f || fillDifference == 14f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 18.5f || fillDifference == 19f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                    }
                    else if (molesController.burette_moles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 3.5f || fillDifference == 4f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 5.5f || fillDifference == 6f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 8.5f || fillDifference == 9f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5); ;
                            }
                        }
                    }

                }
                else if (molesController.conicalFlaskMoles > 0)
                {
                    if (molesController.conicalFlaskMoles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 14.5f || fillDifference == 15f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 20.5f || fillDifference == 21f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                    }
                    else if (molesController.conicalFlaskMoles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(5); ;
                            }
                        }
                    }

                }
                else
                {

                    if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                    {
                        if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                        {
                            ColorlessTransition(5);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                    {
                        if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                        {
                            ColorlessTransition(5);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == 20)
                    {
                        if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                        {
                            ColorlessTransition(5); ;
                        }
                    }
                }

            }
            if (analyteVariation.value == 3 && titrantVariation.value == 3 && !isTransformed)
            {
                if (molesController.burette_moles > 0)
                {
                    if (molesController.burette_moles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 10.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 13.5f || fillDifference == 14f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 18.5f || fillDifference == 19f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                    }
                    else if (molesController.burette_moles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 3.5f || fillDifference == 4f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 5.5f || fillDifference == 6f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 8.5f || fillDifference == 9f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8); ;
                            }
                        }
                    }

                }
                else if (molesController.conicalFlaskMoles > 0)
                {
                    if (molesController.conicalFlaskMoles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 14.5f || fillDifference == 15f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 20.5f || fillDifference == 21f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                    }
                    else if (molesController.conicalFlaskMoles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                            {
                                PhenopthleinToPinkTransition(8);
                            }
                        }
                    }

                }
                else
                {

                    if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                    {
                        if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                        {
                            ColorlessTransition(8);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                    {
                        if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                        {
                            ColorlessTransition(8);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == 20)
                    {
                        if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                        {
                            ColorlessTransition(8); ;
                        }
                    }
                }

            }
        }
        else if (indicatorVariation.value == 1 && (buretteKnob.value == 1 || buretteKnob.value == 2))
        {
            // acid to base
            if (analyteVariation.value == 0 && titrantVariation.value == 0 && !isTransformed)
            {
                if (molesController.burette_moles > 0)
                {
                    if (molesController.burette_moles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 7.5f || fillDifference == 8f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 17.5f || fillDifference == 18f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                    }
                    else if (molesController.burette_moles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 2.5f || fillDifference == 3f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 5f || fillDifference == 6.5f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 7.5f || fillDifference == 8f) && pipetteDrop)
                            {
                                MethyToRedTransition(5); ;
                            }
                        }
                    }

                }
                else if (molesController.conicalFlaskMoles > 0)
                {
                    if (molesController.conicalFlaskMoles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 19.5f || fillDifference == 20f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                    }
                    else if (molesController.conicalFlaskMoles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                            {
                                MethyToRedTransition(5); ;
                            }
                        }
                    }

                }
                else
                {

                    if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                    {
                        if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                        {
                            MethyToRedTransition(5);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                    {
                        if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                        {
                            MethyToRedTransition(5);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == 20)
                    {
                        if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                        {
                            MethyToRedTransition(5); ;
                        }
                    }
                }

            }
            if (analyteVariation.value == 2 && titrantVariation.value == 0 && !isTransformed)
            {
                if (molesController.burette_moles > 0)
                {
                    if (molesController.burette_moles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 13.5f || fillDifference == 14f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 18.5f || fillDifference == 19f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                    }
                    else if (molesController.burette_moles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 3.5f || fillDifference == 4f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 5.5f || fillDifference == 6f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 8.5f || fillDifference == 9f) && pipetteDrop)
                            {
                                MethyToRedTransition(5); ;
                            }
                        }
                    }

                }
                else if (molesController.conicalFlaskMoles > 0)
                {
                    if (molesController.conicalFlaskMoles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 14.5f || fillDifference == 15f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 20.5f || fillDifference == 21f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                    }
                    else if (molesController.conicalFlaskMoles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                            {
                                MethyToRedTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                            {
                                MethyToRedTransition(5); ;
                            }
                        }
                    }

                }
                else
                {

                    if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                    {
                        if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                        {
                            MethyToRedTransition(5);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                    {
                        if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                        {
                            MethyToRedTransition(5);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == 20)
                    {
                        if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                        {
                            MethyToRedTransition(5); ;
                        }
                    }
                }

            }
            //base to acid
            if (analyteVariation.value == 1 && titrantVariation.value == 1 && !isTransformed)
            {
                if (molesController.burette_moles > 0)
                {
                    if (molesController.burette_moles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 13.5f || fillDifference == 14f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 18.5f || fillDifference == 19f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                    }
                    else if (molesController.burette_moles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 3.5f || fillDifference == 4f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 5.5f || fillDifference == 6f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 8.5f || fillDifference == 9f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5); ;
                            }
                        }
                    }

                }
                else if (molesController.conicalFlaskMoles > 0)
                {
                    if (molesController.conicalFlaskMoles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 14.5f || fillDifference == 15f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 20.5f || fillDifference == 21f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                    }
                    else if (molesController.conicalFlaskMoles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5); ;
                            }
                        }
                    }

                }
                else
                {

                    if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                    {
                        if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                        {
                            MethyTYellowTransition(5);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                    {
                        if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                        {
                            MethyTYellowTransition(5);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == 20)
                    {
                        if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                        {
                            MethyTYellowTransition(5); ;
                        }
                    }
                }

            }
            if (analyteVariation.value == 3 && titrantVariation.value == 1 && !isTransformed)
            {
                if (molesController.burette_moles > 0)
                {
                    if (molesController.burette_moles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 10.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 13.5f || fillDifference == 14f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 18.5f || fillDifference == 19f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                    }
                    else if (molesController.burette_moles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 3.5f || fillDifference == 4f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 5.5f || fillDifference == 6f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 8.5f || fillDifference == 9f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8); ;
                            }
                        }
                    }

                }
                else if (molesController.conicalFlaskMoles > 0)
                {
                    if (molesController.conicalFlaskMoles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 14.5f || fillDifference == 15f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 20.5f || fillDifference == 21f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                    }
                    else if (molesController.conicalFlaskMoles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                    }

                }
                else
                {

                    if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                    {
                        if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                        {
                            MethyTYellowTransition(8);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                    {
                        if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                        {
                            MethyTYellowTransition(8);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == 20)
                    {
                        if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                        {
                            MethyTYellowTransition(8); ;
                        }
                    }
                }

            }
            //acid to base
            if (analyteVariation.value == 0 && titrantVariation.value == 2 && !isTransformed)
            {
                if (molesController.burette_moles > 0)
                {
                    if (molesController.burette_moles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 7.5f || fillDifference == 8f) && pipetteDrop)
                            {
                                MethyToRedTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop)
                            {
                                MethyToRedTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 17.5f || fillDifference == 18f) && pipetteDrop)
                            {
                                MethyToRedTransition(6);
                            }
                        }
                    }
                    else if (molesController.burette_moles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 2.5f || fillDifference == 3f) && pipetteDrop)
                            {
                                MethyToRedTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 5f || fillDifference == 6.5f) && pipetteDrop)
                            {
                                MethyToRedTransition(7);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 7.5f || fillDifference == 8f) && pipetteDrop)
                            {
                                MethyToRedTransition(5); ;
                            }
                        }
                    }

                }
                else if (molesController.conicalFlaskMoles > 0)
                {
                    if (molesController.conicalFlaskMoles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                MethyToRedTransition(7);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop)
                            {
                                MethyToRedTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 19.5f || fillDifference == 20f) && pipetteDrop)
                            {
                                MethyToRedTransition(6);
                            }
                        }
                    }
                    else if (molesController.conicalFlaskMoles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                            {
                                MethyToRedTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                            {
                                MethyToRedTransition(7);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                            {
                                MethyToRedTransition(7); ;
                            }
                        }
                    }

                }
                else
                {

                    if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                    {
                        if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                        {
                            MethyToRedTransition(7);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                    {
                        if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                        {
                            MethyToRedTransition(7);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == 20)
                    {
                        if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                        {
                            MethyToRedTransition(7); ;
                        }
                    }
                }

            }
            if (analyteVariation.value == 2 && titrantVariation.value == 2 && !isTransformed)
            {
                if (molesController.burette_moles > 0)
                {
                    if (molesController.burette_moles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 7.5f || fillDifference == 8f) && pipetteDrop)
                            {
                                MethyToRedTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop)
                            {
                                MethyToRedTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 17.5f || fillDifference == 18f) && pipetteDrop)
                            {
                                MethyToRedTransition(6);
                            }
                        }
                    }
                    else if (molesController.burette_moles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 2.5f || fillDifference == 3f) && pipetteDrop)
                            {
                                MethyToRedTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 5f || fillDifference == 6.5f) && pipetteDrop)
                            {
                                MethyToRedTransition(7);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 7.5f || fillDifference == 8f) && pipetteDrop)
                            {
                                MethyToRedTransition(5); ;
                            }
                        }
                    }

                }
                else if (molesController.conicalFlaskMoles > 0)
                {
                    if (molesController.conicalFlaskMoles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                MethyToRedTransition(7);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 12.5f || fillDifference == 13f) && pipetteDrop)
                            {
                                MethyToRedTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 19.5f || fillDifference == 20f) && pipetteDrop)
                            {
                                MethyToRedTransition(6);
                            }
                        }
                    }
                    else if (molesController.conicalFlaskMoles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                            {
                                MethyToRedTransition(6);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                            {
                                MethyToRedTransition(7);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                            {
                                MethyToRedTransition(7); ;
                            }
                        }
                    }

                }
                else
                {

                    if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                    {
                        if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                        {
                            MethyToRedTransition(7);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                    {
                        if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                        {
                            MethyToRedTransition(7);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == 20)
                    {
                        if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                        {
                            MethyToRedTransition(7); ;
                        }
                    }
                }

            }
            //base to acid
            if (analyteVariation.value == 1 && titrantVariation.value == 3 && !isTransformed)
            {
                if (molesController.burette_moles > 0)
                {
                    if (molesController.burette_moles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 13.5f || fillDifference == 14f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 18.5f || fillDifference == 19f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                    }
                    else if (molesController.burette_moles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 3.5f || fillDifference == 4f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 5.5f || fillDifference == 6f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 8.5f || fillDifference == 9f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5); ;
                            }
                        }
                    }

                }
                else if (molesController.conicalFlaskMoles > 0)
                {
                    if (molesController.conicalFlaskMoles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 14.5f || fillDifference == 15f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 20.5f || fillDifference == 21f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                    }
                    else if (molesController.conicalFlaskMoles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                            {
                                MethyTYellowTransition(5); ;
                            }
                        }
                    }

                }
                else
                {

                    if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                    {
                        if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                        {
                            MethyTYellowTransition(5);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                    {
                        if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                        {
                            MethyTYellowTransition(5);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == 20)
                    {
                        if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                        {
                            MethyTYellowTransition(5); ;
                        }
                    }
                }

            }
            if (analyteVariation.value == 3 && titrantVariation.value == 3 && !isTransformed)
            {
                if (molesController.burette_moles > 0)
                {
                    if (molesController.burette_moles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 10.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 13.5f || fillDifference == 14f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 18.5f || fillDifference == 19f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                    }
                    else if (molesController.burette_moles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 3.5f || fillDifference == 4f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 5.5f || fillDifference == 6f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 8.5f || fillDifference == 9f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8); ;
                            }
                        }
                    }

                }
                else if (molesController.conicalFlaskMoles > 0)
                {
                    if (molesController.conicalFlaskMoles == 1)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 9.5f || fillDifference == 10f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 14.5f || fillDifference == 15f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 20.5f || fillDifference == 21f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                    }
                    else if (molesController.conicalFlaskMoles == 2)
                    {
                        if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                        {
                            if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                        {
                            if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                        else if (ConicalFlaskVolume.volumeMin == 20)
                        {
                            if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                            {
                                MethyTYellowTransition(8);
                            }
                        }
                    }

                }
                else
                {

                    if (ConicalFlaskVolume.volumeMin == Random.Range(10, 15))
                    {
                        if ((fillDifference == 4.5f || fillDifference == 5f) && pipetteDrop)
                        {
                            MethyTYellowTransition(8);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == Random.Range(15, 20))
                    {
                        if ((fillDifference == 7f || fillDifference == 7.5f) && pipetteDrop)
                        {
                            MethyTYellowTransition(8);
                        }
                    }
                    else if (ConicalFlaskVolume.volumeMin == 20)
                    {
                        if ((fillDifference == 9f || fillDifference == 9.5f) && pipetteDrop)
                        {
                            MethyTYellowTransition(8); ;
                        }
                    }
                }

            }
        }


    }

    public void resetEverything()
    {

        if (resetDropdown.value == 0)
        {
            resetButton.interactable = false;
            resetTime();
            isTransformed = false;
            fill.CurrentVal = 0;
            DropParticle.Stop();
            DropParticle.gameObject.SetActive(false);
            liquidFlowParticle.SetActive(false);
            stream.SetActive(false);
            titrantVariation.interactable = true;
            molesController.BMoles1.interactable = true;
            molesController.BMoles2.interactable = true;
            dropController.resetDrops();
            titrantVariation.value = 0;
            analyteVariation.value = 0;
            indicatorVariation.value = 0;
            buretteKnob.value = 0;
            analyteVariation.interactable = true;
            titrantVariation.interactable = true;
            indicatorVariation.interactable = true;
            beakerToggle.interactable = true;
            ConicalFlaskVolume.volumeSlider.value = 10;
            ConicalFlaskVolume.volumeSlider.interactable = true;
            molesController.burette_moles = 1;
            molesController.conicalFlaskMoles = 0;
            ShakeEffectHandler.isShaking = false;
        }
        if (resetDropdown.value == 1)
        {
            resetButton.interactable = true;
            fill.CurrentVal = 0;
            DropParticle.Stop();
            DropParticle.gameObject.SetActive(false);
            liquidFlowParticle.SetActive(false);
            stream.SetActive(false);
            titrantVariation.interactable = true;
            molesController.BMoles1.interactable = true;
            titrantVariation.value = 0;
            buretteKnob.value = 0;
            analyteVariation.interactable = true;
            titrantVariation.interactable = true;
            indicatorVariation.interactable = true;
            beakerToggle.interactable = true;
            ConicalFlaskVolume.volumeSlider.value = 10;
            ConicalFlaskVolume.volumeSlider.interactable = true;
            molesController.conicalFlaskMoles = 0;
        }
        if (resetDropdown.value == 2)
        {
            resetButton.interactable = true;
            resetTime();
            isTransformed = false;
            //fill.CurrentVal = 0;
            fillDifference = 0;
            DropParticle.Stop();
            DropParticle.gameObject.SetActive(false);
            liquidFlowParticle.SetActive(false);
            stream.SetActive(false);
            dropController.resetDrops();
            titrantVariation.value = 0;
            analyteVariation.value = 0;
            indicatorVariation.value = 0;
            buretteKnob.value = 0;
            analyteVariation.interactable = true;
            indicatorVariation.interactable = true;
            ConicalFlaskVolume.volumeSlider.value = 10;
            ConicalFlaskVolume.volumeSlider.interactable = true;
            ShakeEffectHandler.isShaking = false;

        }

    }

    // slider that controls the titration liquid flow 
    public void OnValueChanged(float value)
    {
        if (buretteKnob.value == 1)
        {
            if (fill.CurrentVal == 0)
            {
                var localReftoParticle = DropParticle.main;
                localReftoParticle.playOnAwake = false;
            }
            else
            {
                Vibration.Vibrate(60);
                DropParticle.gameObject.SetActive(true);
                var localReftoParticle = DropParticle.main;
                localReftoParticle.playOnAwake = true;
                liquidFlowParticle.SetActive(false);
                StopCoroutine(flowController);
                StartCoroutine(dropSolution);
            }

        }
        else if (buretteKnob.value == 2)
        {
            if (fill.CurrentVal == 0)
            {
                liquidFlowParticle.SetActive(false);
            }
            else
            {
                Vibration.Vibrate(60);
                //  analyteVariation.enabled = false;
                var localReftoParticle = DropParticle.main;
                localReftoParticle.playOnAwake = false;


                liquidFlowParticle.SetActive(true);

                StartCoroutine(flowController);
                StopCoroutine(dropSolution);
                // StartCoroutine(colorTransition);
            }

        }
        else if (buretteKnob.value == 0)
        {
            var localReftoParticle = DropParticle.main;
            localReftoParticle.playOnAwake = false;
            DropParticle.gameObject.SetActive(false);

            liquidFlowParticle.SetActive(false);
            StopCoroutine(dropSolution);
            StopCoroutine(flowController);
        }
    }

    // Titrant Variation DropDown
    public void handleTitrantVariation()
    {
        if (titrantVariation.value == 0)
        {
            content.GetComponent<Image>().color = new Color32(198, 198, 198, 121);
            fill.CurrentVal = 0;
            buretteKnob.value = 0;
        }
        if (titrantVariation.value == 1)
        {
            content.GetComponent<Image>().color = new Color32(216, 242, 255, 164);
            fill.CurrentVal = 0;
            buretteKnob.value = 0;
        }
        if (titrantVariation.value == 2)
        {
            content.GetComponent<Image>().color = new Color32(198, 198, 198, 121);
            fill.CurrentVal = 0;
            buretteKnob.value = 0;
        }
        if (titrantVariation.value == 3)
        {
            content.GetComponent<Image>().color = new Color32(216, 242, 255, 164);
            fill.CurrentVal = 0;
            buretteKnob.value = 0;
        }
    }

    // analyte Variation DropDown
    public void handleAnalyteVariation()
    {

        if (analyteVariation.value == 0)
        {
            // analyteNotation.text = "15ml NaOH";
            dropController.sodium_hydroxide.GetComponent<Image>().color = new Color32(216, 242, 255, 164);


        }
        if (analyteVariation.value == 1)
        {
            // analyteNotation.text = "15ml CaOH";
            dropController.sodium_hydroxide.GetComponent<Image>().color = new Color32(198, 198, 198, 121);
        }
        if (analyteVariation.value == 2)
        {
            // analyteNotation.text = "15ml CaOH";
            dropController.sodium_hydroxide.GetComponent<Image>().color = new Color32(216, 242, 255, 164);
        }
        if (analyteVariation.value == 3)
        {
            // analyteNotation.text = "15ml CaOH";
            dropController.sodium_hydroxide.GetComponent<Image>().color = new Color32(198, 198, 198, 121);
        }
    }

    public void fillUp()
    {
        StartCoroutine(fillBurette);
    }

    public void startFillDelay()
    {
        stream.SetActive(true);
    }
    IEnumerator LiquidFill()
    {

        do
        {
            if (fill.currentVal == fill.MaxVal)
            {
                stream.SetActive(false);
                buretteKnob.enabled = true;
                titrantVariation.enabled = true;
                stopFlow();

            }
            else
            {
                resetButton.interactable = true;
                titrantVariation.interactable = false;
                buretteKnob.value = 0;
                buretteKnob.enabled = false;
                if (titrantVariation.value == 0)
                {
                    stream.GetComponent<Image>().color = new Color32(234, 234, 234, 90);
                }
                else
                {
                    stream.GetComponent<Image>().color = new Color32(234, 234, 234, 50);
                }

            }
            fill.CurrentVal++;
            yield return new WaitForSeconds(0.5f);
        } while (fill.CurrentVal >= 0);
    }

    public void Flow()
    {
        StartCoroutine(flowController);

    }
    IEnumerator LiquidDrop()
    {

        while (fill.CurrentVal >= 0)
        {
            analyteVariation.interactable = false;
            titrantVariation.interactable = false;
            indicatorVariation.interactable = false;
            fill.CurrentVal -= 0.5f;
            //if(buretteKnob.value == 0)
            if (fill.currentVal == 0)
            {
                var localReftoParticle = DropParticle.main;
                localReftoParticle.playOnAwake = false;
                DropParticle.Stop();
            }
            else
            {
                DropParticle.Play();
            }
            yield return new WaitForSeconds(4f);
        }
    }

    IEnumerator LiquidFlow()
    {

        while (fill.CurrentVal >= 0)
        {
            fill.CurrentVal -= 1f;
            DropParticle.Stop();
            if (fill.currentVal == 0)
            {
                liquidFlowParticle.SetActive(false);
                var localReftoParticle = DropParticle.main;
                localReftoParticle.playOnAwake = false;
                DropParticle.Stop();
            }
            yield return new WaitForSeconds(2f);
        }
    }

    public void stopFlow()
    {
        buretteKnob.enabled = true;
        StopCoroutine(flowController);
        StopCoroutine(dropSolution);
        StopCoroutine(fillBurette);
        stream.SetActive(false);
        valueHolder = fill.CurrentVal;
    }
    public void resetTime()
    {
        time = 0;
        StopAllCoroutines();
    }

    public void ColorlessTransition(float time_taken)
    {
        dropController.sodium_hydroxide.DOColor(new Color32(234, 234, 234, 109), time_taken);
        isTransformed = true;
    }
    public void PhenopthleinToPinkTransition(float time_taken)
    {
        dropController.sodium_hydroxide.DOColor(new Color32(251, 0, 253, 243), time_taken);
        isTransformed = true;
    }
    public void MethyToRedTransition(float time_taken)
    {
        dropController.sodium_hydroxide.DOColor(new Color32(226, 16, 109, 255), time_taken);
        isTransformed = true;
    }
    public void MethyTYellowTransition(float time_taken)
    {
        dropController.sodium_hydroxide.DOColor(new Color32(237, 217, 40, 255), time_taken);
        isTransformed = true;
    }

}
