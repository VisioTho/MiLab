using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubstanceManager : MonoBehaviour
{
    public class Substance
    {
        public GameObject stream, liquid, beaker;
        private Vector3 temp;
        public Renderer liquidRenderer;
        public Color liquidColor;

        //scales the size of the liquid object in each beaker when the jet stream is 'opened'
        public void fillBeakerWithSubstance()
        {
            this.temp = this.liquid.transform.localScale;
            if(temp.y<20.0f)
            {
                if (this.stream.activeSelf && this.beaker.activeSelf)
                {
                    const float V = 0.02f;
                    this.temp.y += V;
                    this.liquid.transform.localScale = temp;
                }
            }   
        }

        public void openJetStream()
        {
            this.stream.SetActive(true);
        }

        public void closeJetStream()
        {
            this.stream.SetActive(false);
        }

        //constructor for substance objects
        public Substance(GameObject stream, GameObject liquid, GameObject beaker)
        {
            this.stream = stream;
            this.liquid = liquid;
            this.beaker = beaker;
            
            this.liquidRenderer = liquid.GetComponent<Renderer>();
        }

        public void showTestTube()
        {
            this.beaker.SetActive(true);
        }

        public void hideTestTube()
        {
            this.beaker.SetActive(false);
        }
    }

    public GameObject[] jetStreams, liquids, beakers;
    public Image[] fluids;
    private Substance ethanoicAcid, hydrochloricAcid, ammoniaSolution, sodiumHydroxide;

    private void Awake()
    {
        foreach(GameObject i in jetStreams)
        {
            i.SetActive(false);
        }
    }
    void Start()
    {
        //initialize substances
        ethanoicAcid = new Substance(jetStreams[0], liquids[0],beakers[0]);
        hydrochloricAcid = new Substance(jetStreams[1], liquids[1], beakers[1]);
        ammoniaSolution = new Substance(jetStreams[2], liquids[2], beakers[2]);
        sodiumHydroxide = new Substance(jetStreams[3], liquids[3], beakers[3]);
    }

    private int testTubeSelectNumber;
    public void selectTestTube(int val)
    {
        if (val == 0)
        {
            ethanoicAcid.showTestTube();
            hydrochloricAcid.hideTestTube();
            sodiumHydroxide.hideTestTube();
            ammoniaSolution.hideTestTube();
        }
            
        if (val == 1)
        {
            ethanoicAcid.hideTestTube();
            hydrochloricAcid.showTestTube();
            sodiumHydroxide.hideTestTube();
            ammoniaSolution.hideTestTube();
        }
        if (val == 2)
        {
            ethanoicAcid.hideTestTube();
            hydrochloricAcid.hideTestTube();
            sodiumHydroxide.showTestTube();
            ammoniaSolution.hideTestTube();
        }
        if (val == 3)
        {
            ethanoicAcid.hideTestTube();
            hydrochloricAcid.hideTestTube();
            sodiumHydroxide.hideTestTube();
            ammoniaSolution.showTestTube();
        }

        testTubeSelectNumber = val;
    }

    public void OpenJetStreams()
    {
        int n =testTubeSelectNumber;
        if(n==0)
        {
            ethanoicAcid.openJetStream();
        }
        if(n==1)
        {
            hydrochloricAcid.openJetStream();
        }
        if(n==2)
        {
            sodiumHydroxide.openJetStream();
        }
        if(n==3)
        {
            ammoniaSolution.openJetStream();
        }
    }

    public void closeJetStream()
    {
        int n = testTubeSelectNumber;
        if (n == 0)
            ethanoicAcid.closeJetStream();
        if (n == 1)
            hydrochloricAcid.closeJetStream();
        if (n == 2)
            sodiumHydroxide.closeJetStream();
        if (n == 3)
            ammoniaSolution.closeJetStream();
    }

    public void changeColor()
    {
       
        if(ethanoicAcid.beaker.activeSelf && ethanoicAcid.liquid.transform.localScale.y >= 20.0f)
        {
            Color newColor = new Color(0.4f, 0.3f, 0.1f, 1f);
            fluids[0].GetComponent<Image>().color = new Color32(255, 216, 15, 255);
        }
        if (hydrochloricAcid.beaker.activeSelf && hydrochloricAcid.liquid.transform.localScale.y >= 20.0f)
        {
            Color newColor = new Color(0.4f, 0.3f, 0.1f, 1f);
            fluids[1].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
        if (ammoniaSolution.beaker.activeSelf && ammoniaSolution.liquid.transform.localScale.y >= 20.0f)
        {
            Color newColor = new Color(0.4f, 0.3f, 0.1f, 1f);
            fluids[2].GetComponent<Image>().color = new Color32(79, 86, 174, 255);
        }
        if (sodiumHydroxide.beaker.activeSelf && sodiumHydroxide.liquid.transform.localScale.y >= 20.0f)
        {
            Color newColor = new Color(0.4f, 0.3f, 0.1f, 1f);
            fluids[3].GetComponent<Image>().color = new Color32(71, 45, 144, 255);
        }

        PipetteDropHandler.isDropped = false;

    }

    // Update is called once per frame
    void Update()
    {
        ethanoicAcid.fillBeakerWithSubstance();
        hydrochloricAcid.fillBeakerWithSubstance();
        sodiumHydroxide.fillBeakerWithSubstance();
        ammoniaSolution.fillBeakerWithSubstance();

        if(PipetteDropHandler.isDropped)
        {
            changeColor();
        }
        
    }
}
