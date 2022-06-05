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
    public GameObject copperMetals, zincMetals, ironMetals, magnesiumMetals;
    public GameObject[] metals, metalsB, metalsC, metalsD;
    public GameObject sulphate, sulphate2, sulphate3, sulphate4;
    public GameObject particles, zincParticles, bubbleParticles;

    Vector3 initialPosition;
    Vector3 initialScale;
    public Button removeMetalButton;

    public TMP_Text solutionNotation;
    public Toggle copperMetalToggle, zincMetalToggle, ironMetalToggle, magnesiumMetalToggle;

    public TMP_Dropdown sulphateDrop;
    public float time = 0;
    public float duration = 8;

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
        if (copperReaction.counter >= 1 || zincReaction.counter >= 1 || ironReaction.counter >= 1 || magnesiumReaction.counter >= 1)
        {
            removeMetalButton.interactable = true;
        }
        if ((sulphateDrop.value > 0) && copperReaction.counter >= 1 || zincReaction.counter >= 1 || ironReaction.counter >= 1 || magnesiumReaction.counter >= 1)
        {
            copperMetalToggle.interactable = false;
            zincMetalToggle.interactable = false;
            ironMetalToggle.interactable = false;
            magnesiumMetalToggle.interactable = false;
        }
    }

    public void resetEverything()
    {
        sulphateDrop.value = 0;
        resetTime();
        zincColor.resetTime();
        ironColor.resetTime();
        changeMagnesiumColor.resetTime();
        removeMetalButton.interactable = false;
        sulphateDrop.interactable = true;
        particles.SetActive(false);
        zincParticles.SetActive(false);
        bubbleParticles.SetActive(false);
        copperMetalToggle.interactable = true;
        zincMetalToggle.interactable = true;
        ironMetalToggle.interactable = true;
        magnesiumMetalToggle.interactable = true;

        // copper reset loop
        for (int i = 0; i < metals.Length; i++)
        {
            metals[i].transform.position = initialPosition;
            metals[i].GetComponent<Rigidbody2D>().simulated = true;
            metals[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            metals[i].gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
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
            metalsB[i].gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
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
            metalsC[i].gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }
        metalsC[0].transform.position = initialPosition;
        ironReaction.counter = 0;

        // magnesium reset loop
        for (int i = 0; i < metalsD.Length; i++)
        {
            metalsD[i].transform.position = initialPosition;
            changeMagnesiumColor.defaultColor();
            sulphate.GetComponent<SpriteRenderer>().color = new Color32(55, 162, 214, 166);
            sulphate2.GetComponent<SpriteRenderer>().color = new Color32(129, 125, 75, 72);
            sulphate3.GetComponent<SpriteRenderer>().color = new Color32(168, 192, 109, 76);
            metalsD[i].GetComponent<Rigidbody2D>().simulated = true;
            metalsD[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            metalsD[i].gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }
        metalsD[0].transform.position = initialPosition;
        magnesiumReaction.counter = 0;
    }
    public void resetMetals()
    {
        resetTime();
        zincColor.resetTime();
        ironColor.resetTime();
        changeMagnesiumColor.resetTime();
        removeMetalButton.interactable = false;
        sulphateDrop.interactable = true;
        particles.SetActive(false);
        zincParticles.SetActive(false);
        bubbleParticles.SetActive(false);

        // copper reset loop
        for (int i = 0; i < metals.Length; i++)
        {
            metals[i].transform.position = initialPosition;
            metals[i].GetComponent<Rigidbody2D>().simulated = true;
            metals[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            metals[i].gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
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
            metalsB[i].gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
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
            metalsC[i].gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }
        metalsC[0].transform.position = initialPosition;
        ironReaction.counter = 0;

        // magnesium reset loop
        for (int i = 0; i < metalsD.Length; i++)
        {
            metalsD[i].transform.position = initialPosition;
            changeMagnesiumColor.defaultColor();
            sulphate.GetComponent<SpriteRenderer>().color = new Color32(55, 162, 214, 166);
            sulphate2.GetComponent<SpriteRenderer>().color = new Color32(129, 125, 75, 72);
            sulphate3.GetComponent<SpriteRenderer>().color = new Color32(168, 192, 109, 76);
            metalsD[i].GetComponent<Rigidbody2D>().simulated = true;
            metalsD[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            metalsD[i].gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
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
            sulphateDrop.interactable = true;
        }
        if (sulphateDrop.value == 1 && copperReaction.counter == 1)
        {
            sulphateDrop.interactable = false;
            solutionNotation.text = "copper sulphate + copper";
        }
        if (sulphateDrop.value == 1 && zincReaction.counter == 1)
        {
            zincParticles.SetActive(true);
            sulphateDrop.interactable = false;
            zincColor.zincColorChanged();
            StartCoroutine(copperSulphateRColorTransition());
            Invoke("stopReaction", 170);
            solutionNotation.text = "copper sulphate + zinc";
        }
        if (sulphateDrop.value == 1 && ironReaction.counter == 1)
        {
            sulphateDrop.interactable = false;
            bubbleParticles.SetActive(true);
            ironColor.ironColorTransition();
            StartCoroutine(copperSulphateColorTransition2());
            Invoke("stopReaction", 150);
            solutionNotation.text = "copper sulphate + iron";

        }
        if (sulphateDrop.value == 1 && magnesiumReaction.counter == 1)
        {
            particles.SetActive(true);
            sulphateDrop.interactable = false;
            changeMagnesiumColor.ColorChanged();
            StartCoroutine(copperSulphateColorTransition3());
            Invoke("stopReaction", 130);
            solutionNotation.text = "copper sulphate + magnesium";
        }
    }

    public void zincSulphateReaction()
    {
        if (sulphateDrop.value == 0 && zincReaction.counter == 1)
        {
            sulphateDrop.interactable = true;
        }
        if (sulphateDrop.value == 2 && copperReaction.counter == 1)
        {
            sulphateDrop.interactable = false;
            solutionNotation.text = "zinc sulphate + copper";
        }
        if (sulphateDrop.value == 2 && zincReaction.counter == 1)
        {
            sulphateDrop.interactable = false;
            solutionNotation.text = "zinc sulphate + zinc";
        }
        if (sulphateDrop.value == 2 && ironReaction.counter == 1)
        {
            sulphateDrop.interactable = false;
            solutionNotation.text = "zinc sulphate + iron";
        }
        if (sulphateDrop.value == 2 && magnesiumReaction.counter == 1)
        {
            bubbleParticles.SetActive(true);
            sulphateDrop.interactable = false;
            changeMagnesiumColor.ColorChanged2();
            StartCoroutine(zincSulphateTransition());
            Invoke("stopReaction", 125);
            solutionNotation.text = "zinc sulphate + magnesium";
        }
    }

    public void ironSulphateReaction()
    {
        if (sulphateDrop.value == 0 && ironReaction.counter == 1)
        {
            sulphateDrop.interactable = true;
        }
        if (sulphateDrop.value == 3 && copperReaction.counter == 1)
        {
            sulphateDrop.interactable = false;
            solutionNotation.text = "iron sulphate + copper";
        }
        if (sulphateDrop.value == 3 && zincReaction.counter == 1)
        {
            bubbleParticles.SetActive(true);
            sulphateDrop.interactable = false;
            zincColor.zincColorChanged2();
            StartCoroutine(ironSulphateZincTransition());
            Invoke("stopReaction", 140);
            solutionNotation.text = "iron sulphate + zinc";
        }
        if (sulphateDrop.value == 3 && ironReaction.counter == 1)
        {
            sulphateDrop.interactable = false;
            solutionNotation.text = "iron sulphate + iron";
        }
        if (sulphateDrop.value == 3 && magnesiumReaction.counter == 1)
        {
            particles.SetActive(true);
            sulphateDrop.interactable = false;
            changeMagnesiumColor.magIronTransition();
            StartCoroutine(ironSulphateMagTransition());
            Invoke("stopReaction", 130);
            solutionNotation.text = "iron sulphate + magnesium";
        }
    }

    public void magnesiumSulphateReaction()
    {
        if (sulphateDrop.value == 0 && magnesiumReaction.counter == 1)
        {
            sulphateDrop.interactable = true;
        }
        if (sulphateDrop.value == 4 && copperReaction.counter == 1)
        {
            sulphateDrop.interactable = false;
            solutionNotation.text = "magnesium sulphate + copper";
        }
        if (sulphateDrop.value == 4 && zincReaction.counter == 1)
        {
            sulphateDrop.interactable = false;
            solutionNotation.text = "magnesium sulphate + zinc";
        }
        if (sulphateDrop.value == 4 && ironReaction.counter == 1)
        {
            sulphateDrop.interactable = false;
            solutionNotation.text = "magnesium sulphate + iron";
        }
        if (sulphateDrop.value == 4 && magnesiumReaction.counter == 1)
        {
            sulphateDrop.interactable = false;
            solutionNotation.text = "magnesium sulphate + magnesium";
        }
    }

    public void stopReaction()
    {
        particles.SetActive(false);
        bubbleParticles.SetActive(false);
        zincParticles.SetActive(false);
    }
    public void resetTime()
    {
        time = 0;
        StopAllCoroutines();
    }

    IEnumerator copperSulphateRColorTransition()
    {
        Color startColor = sulphate.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(123, 149, 152, 105);

        while (time < duration)
        {
            sulphate.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sulphate.GetComponent<SpriteRenderer>().color = endColor;
    }

    IEnumerator copperSulphateColorTransition2()
    {
        Color startColor = sulphate.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(168, 192, 109, 76);

        while (time < duration)
        {
            sulphate.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sulphate.GetComponent<SpriteRenderer>().color = endColor;
    }
    IEnumerator copperSulphateColorTransition3()
    {
        Color startColor = sulphate.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(26, 138, 255, 47);

        while (time < duration)
        {
            sulphate.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sulphate.GetComponent<SpriteRenderer>().color = endColor;
    }

    IEnumerator zincSulphateTransition()
    {
        Color startColor = sulphate2.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(147, 147, 147, 96);

        while (time < duration)
        {
            sulphate2.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sulphate2.GetComponent<SpriteRenderer>().color = endColor;
    }

    IEnumerator ironSulphateZincTransition()
    {
        Color startColor = sulphate3.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(129, 125, 75, 45);

        while (time < duration)
        {
            sulphate3.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sulphate3.GetComponent<SpriteRenderer>().color = endColor;
    }

    IEnumerator ironSulphateMagTransition()
    {
        Color startColor = sulphate3.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(147, 147, 147, 96);

        while (time < duration)
        {
            sulphate3.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sulphate3.GetComponent<SpriteRenderer>().color = endColor;
    }

}
