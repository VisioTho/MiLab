using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG;

public class MetalReaction : MonoBehaviour
{
    public changeColor changeMagnesiumColor;
    public zincColorChange zincColor;

    public IronColorChange ironColor;
    public GameObject copperMetals;
    public GameObject zincMetals;
    public GameObject ironMetals;
    public GameObject magnesiumMetals;
    public GameObject[] metals, metalsB, metalsC, metalsD;
    public GameObject sulphate;
    public GameObject sulphate2;
    public GameObject sulphate3;
    public GameObject sulphate4;
    public GameObject particles, zincParticles, bubbleParticles;
    Vector3 initialPosition;
    Vector3 initialScale;
    public Button removeMetalButton;

    public TMP_Text solutionNotation, reactionNotation;

    public TMP_Dropdown sulphateDrop;

    private void Start()
    {
        // changeMagnesiumColor = gameObject.GetComponent("changeColor") as changeColor;
        initialPosition = metals[0].transform.position;
        initialScale = metals[0].transform.localScale;


    }

    void Update()
    {
        copperSulphateReaction();
        ironSulphateReaction();
        zincSulphateReaction();
        magnesiumSulphateReaction();
        if (copperReaction.counter >= 1)
        {
            removeMetalButton.interactable = true;
        }
        if (zincReaction.counter >= 1)
        {
            removeMetalButton.interactable = true;
        }
        if (ironReaction.counter >= 1)
        {
            removeMetalButton.interactable = true;
        }
        if (magnesiumReaction.counter >= 1)
        {
            removeMetalButton.interactable = true;
        }

    }

    public void resetEverything()
    {
        if (sulphateDrop.value == 0)
        {
            solutionNotation.text = " ";
        }
        if (sulphateDrop.value == 1)
        {
            solutionNotation.text = "copper sulphate";

        }
        if (sulphateDrop.value == 2)
        {
            solutionNotation.text = "zinc sulphate";
        }
        if (sulphateDrop.value == 3)
        {
            solutionNotation.text = "iron sulphate";
        }
        if (sulphateDrop.value == 4)
        {
            solutionNotation.text = "magnesium sulphate";
        }
        removeMetalButton.interactable = false;
        sulphateDrop.enabled = true;
        particles.SetActive(false);
        zincParticles.SetActive(false);
        bubbleParticles.SetActive(false);

        // copper reset loop
        for (int i = 0; i < metals.Length; i++)
        {
            metals[i].transform.position = initialPosition;
            metals[i].GetComponent<Rigidbody2D>().simulated = true;
            metals[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            metals[i].gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        }
        metals[0].transform.position = initialPosition;
        copperReaction.counter = 0;

        // zinc reset loop
        for (int i = 0; i < metalsB.Length; i++)
        {
            metalsB[i].transform.position = initialPosition;
            zincColor.defaultColor();
            metalsB[i].GetComponent<Rigidbody2D>().simulated = true;
            metalsB[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            metalsB[i].gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        }
        metalsB[0].transform.position = initialPosition;
        zincReaction.counter = 0;

        // iron reset loop
        for (int i = 0; i < metalsC.Length; i++)
        {
            metalsC[i].transform.position = initialPosition;
            ironColor.defaultColor();
            metalsC[i].GetComponent<Rigidbody2D>().simulated = true;
            metalsC[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            metalsC[i].gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        }
        metalsC[0].transform.position = initialPosition;
        ironReaction.counter = 0;

        // magnesium reset loop
        for (int i = 0; i < metalsD.Length; i++)
        {
            metalsD[i].transform.position = initialPosition;
            changeMagnesiumColor.defaultColor();
            sulphate.GetComponent<Image>().color = new Color32(55, 162, 214, 166);
            metalsD[i].GetComponent<Rigidbody2D>().simulated = true;
            metalsD[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            metalsD[i].gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        }
        metalsD[0].transform.position = initialPosition;
        magnesiumReaction.counter = 0;
    }

    public void handleSolutionInput(int val)
    {
        if (val == 0)
        {
            solutionNotation.text = " ";
            sulphate.SetActive(false);
            sulphate2.SetActive(false);
            sulphate3.SetActive(false);
            sulphate4.SetActive(false);
        }
        if (val == 1)
        {
            sulphate.SetActive(true);
            solutionNotation.text = "copper sulphate";
            sulphate2.SetActive(false);
            sulphate3.SetActive(false);
            sulphate4.SetActive(false);


        }
        if (val == 2)
        {
            sulphate2.SetActive(true);
            solutionNotation.text = "zinc sulphate";
            sulphate.SetActive(false);
            sulphate3.SetActive(false);
            sulphate4.SetActive(false);

        }
        if (val == 3)
        {
            sulphate3.SetActive(true);
            solutionNotation.text = "iron sulphate";
            sulphate2.SetActive(false);
            sulphate.SetActive(false);
            sulphate4.SetActive(false);
        }
        if (val == 4)
        {
            sulphate4.SetActive(true);
            solutionNotation.text = "magnesium sulphate";
            sulphate2.SetActive(false);
            sulphate3.SetActive(false);
            sulphate.SetActive(false);
        }
    }

    public void copperSulphateReaction()
    {
        if (sulphateDrop.value == 0 && copperReaction.counter == 1)
        {
            sulphateDrop.enabled = true;
            reactionNotation.text = "remove metal";
        }
        if (sulphateDrop.value == 1 && copperReaction.counter == 1)
        {
            sulphateDrop.enabled = false;
            solutionNotation.text = "copper sulphate + copper";
            reactionNotation.text = "remove solute";
        }
        if (sulphateDrop.value == 1 && zincReaction.counter == 1)
        {
            zincParticles.SetActive(true);
            sulphateDrop.enabled = false;
            zincColor.zincColorChanged();
            copperSulphateV();
            Invoke("copperSulphateV", 5);
            Invoke("stopReaction", 60);
            solutionNotation.text = "copper sulphate + zinc";
            reactionNotation.text = "remove solute";
        }
        if (sulphateDrop.value == 1 && ironReaction.counter == 1)
        {
            sulphateDrop.enabled = false;
            bubbleParticles.SetActive(true);
            ironColor.ironColorChanged();
            Invoke("copperSulphateVI", 6);
            Invoke("stopReaction", 60);
            solutionNotation.text = "copper sulphate + iron";
            reactionNotation.text = "remove solute";
        }
        if (sulphateDrop.value == 1 && magnesiumReaction.counter == 1)
        {
            particles.SetActive(true);
            sulphateDrop.enabled = false;
            changeMagnesiumColor.ColorChanged();
            Invoke("copperSulphateIV", 4);
            Invoke("stopReaction", 2);
            solutionNotation.text = "copper sulphate + magnesium";
            reactionNotation.text = "remove solute";
        }
    }

    public void zincSulphateReaction()
    {
        if (sulphateDrop.value == 0 && zincReaction.counter == 1)
        {
            sulphateDrop.enabled = true;
            reactionNotation.text = "remove metal";
        }
        if (sulphateDrop.value == 2 && copperReaction.counter == 1)
        {
            sulphateDrop.enabled = false;
            solutionNotation.text = "zinc sulphate + copper";
            reactionNotation.text = "remove solute";
        }
        if (sulphateDrop.value == 2 && zincReaction.counter == 1)
        {
            sulphateDrop.enabled = false;
            solutionNotation.text = "zinc sulphate + zinc";
            reactionNotation.text = "remove solute";
        }
        if (sulphateDrop.value == 2 && ironReaction.counter == 1)
        {
            sulphateDrop.enabled = false;
            solutionNotation.text = "zinc sulphate + iron";
            reactionNotation.text = "remove solute";
        }
        if (sulphateDrop.value == 2 && magnesiumReaction.counter == 1)
        {
            bubbleParticles.SetActive(true);
            sulphateDrop.enabled = false;
            changeMagnesiumColor.ColorChanged2();
            Invoke("zincSulphateIV", 4);
            Invoke("stopReaction", 40);
            solutionNotation.text = "zinc sulphate + magnesium";
            reactionNotation.text = "remove solute";
        }
    }

    public void ironSulphateReaction()
    {
        if (sulphateDrop.value == 0 && ironReaction.counter == 1)
        {
            sulphateDrop.enabled = true;
            reactionNotation.text = "remove metal";
        }
        if (sulphateDrop.value == 3 && copperReaction.counter == 1)
        {
            sulphateDrop.enabled = false;
            solutionNotation.text = "iron sulphate + copper";
            reactionNotation.text = "remove solute";
        }
        if (sulphateDrop.value == 3 && zincReaction.counter == 1)
        {
            bubbleParticles.SetActive(true);
            sulphateDrop.enabled = false;
            zincColor.zincColorChanged2();
            Invoke("IronSulphateIV", 7);
            Invoke("stopReaction", 40);
            solutionNotation.text = "iron sulphate + zinc";
            reactionNotation.text = "remove solute";
        }
        if (sulphateDrop.value == 3 && ironReaction.counter == 1)
        {
            sulphateDrop.enabled = false;
            solutionNotation.text = "iron sulphate + iron";
            reactionNotation.text = "remove solute";
        }
        if (sulphateDrop.value == 3 && magnesiumReaction.counter == 1)
        {
            particles.SetActive(true);
            sulphateDrop.enabled = false;
            changeMagnesiumColor.ColorChanged3();
            Invoke("IronSulphateV", 8);
            Invoke("stopReaction", 40);
            solutionNotation.text = "iron sulphate + magnesium";
            reactionNotation.text = "remove solute";
        }
    }

    public void magnesiumSulphateReaction()
    {
        if (sulphateDrop.value == 0 && magnesiumReaction.counter == 1)
        {
            sulphateDrop.enabled = true;
            reactionNotation.text = "remove metal";
        }
        if (sulphateDrop.value == 4 && copperReaction.counter == 1)
        {
            sulphateDrop.enabled = false;
            solutionNotation.text = "magnesium sulphate + copper";
            reactionNotation.text = "remove solute";
        }
        if (sulphateDrop.value == 4 && zincReaction.counter == 1)
        {
            sulphateDrop.enabled = false;
            solutionNotation.text = "magnesium sulphate + zinc";
            reactionNotation.text = "remove solute";
        }
        if (sulphateDrop.value == 4 && ironReaction.counter == 1)
        {
            sulphateDrop.enabled = false;
            solutionNotation.text = "magnesium sulphate + iron";
            reactionNotation.text = "remove solute";
        }
        if (sulphateDrop.value == 4 && magnesiumReaction.counter == 1)
        {
            sulphateDrop.enabled = false;
            solutionNotation.text = "magnesium sulphate + magnesium";
            reactionNotation.text = "remove solute";
        }
    }

    public void stopReaction()
    {
        particles.SetActive(false);
        bubbleParticles.SetActive(false);
        zincParticles.SetActive(false);
    }
    public void copperSulphateIV()
    {
        sulphate.GetComponent<Image>().color = new Color32(26, 138, 255, 47);
    }
    public void copperSulphateV()
    {
        sulphate.GetComponent<Image>().color = new Color32(123, 149, 152, 105);
    }
    public void copperSulphateVI()
    {
        sulphate.GetComponent<Image>().color = new Color32(123, 149, 152, 105);
    }


    public void zincSulphateIV()
    {
        sulphate2.GetComponent<Image>().color = new Color32(147, 147, 147, 96);
    }

    public void IronSulphateIV()
    {
        sulphate3.GetComponent<Image>().color = new Color32(147, 147, 147, 96);
    }
    public void IronSulphateV()
    {
        sulphate3.GetComponent<Image>().color = new Color32(147, 147, 147, 96);
    }

}
