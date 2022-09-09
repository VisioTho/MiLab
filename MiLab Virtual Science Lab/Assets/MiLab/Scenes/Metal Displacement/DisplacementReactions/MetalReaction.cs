using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MetalReaction : MonoBehaviour
{
    public GameObject copperMetals, zincMetals, ironMetals, magnesiumMetals;
    public GameObject[] metals, metalsB, metalsC, metalsD;
    public SpriteRenderer sulphate, sulphate2, sulphate3, sulphate4;
    public GameObject mag_copperSulphateParticles, mag_zincSulphateParticles, mag_ironSuphateParticles;

    Vector3 initialPosition;
    Vector3 initialScale;
    public Button removeMetalButton;

    //  public TMP_Text solutionNotation;
    public Toggle copperMetalToggle, zincMetalToggle, ironMetalToggle, magnesiumMetalToggle;

    //   public TMP_Dropdown sulphateDrop;
    public float time = 0;
    public float zincTime = 0;
    public float ironTime = 0;
    public float duration = 8;
    public int reactionDuration = 0;
    public static bool resetMetals = false;

    private void Start()
    {
        // changeMagnesiumColor = gameObject.GetComponent("changeColor") as changeColor;
        initialPosition = metals[0].transform.position;
        initialScale = metals[0].transform.localScale;
    }

    void Update()
    {
        // spriteDrag.copperCollided = true;

        // MetalDrag.copperCollided = true;
        // Debug.Log("wakaaaa" + MetalDrag.copperCollided);
        copperSulphateReaction();
        ironSulphateReaction();
        zincSulphateReaction();
        // magnesiumSulphateReaction();
        if (copperReaction.counter >= 1 || zincReaction.counter >= 1 || ironReaction.counter >= 1 || magnesiumReaction.counter >= 1)
        {
            removeMetalButton.interactable = true;
            copperMetalToggle.interactable = false;
            zincMetalToggle.interactable = false;
            ironMetalToggle.interactable = false;
            magnesiumMetalToggle.interactable = false;
            resetMetals = false;
        }
        if (resetMetals == true)
        {
            stopReaction();
        }
    }

    public void resetEverything()
    {
        resetTime();
        removeMetalButton.interactable = false;
        mag_copperSulphateParticles.SetActive(false);
        mag_zincSulphateParticles.SetActive(false);
        mag_ironSuphateParticles.SetActive(false);

        copperMetalToggle.interactable = true;
        zincMetalToggle.interactable = true;
        ironMetalToggle.interactable = true;
        magnesiumMetalToggle.interactable = true;
        MetalDrag.copperCollided = false;
        MetalDrag.zincCollided = false;
        MetalDrag.ironCollided = false;
        MetalDrag.magnesiumCollided = false;

        resetMetals = true;


        // copper reset loop
        for (int i = 0; i < metals.Length; i++)
        {
            metals[i].transform.position = initialPosition;
            metals[i].transform.localScale = initialScale;
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
            // zincColor.defaultColor();
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
            // changeMagnesiumColor.defaultColor();
            sulphate.GetComponent<SpriteRenderer>().color = new Color32(55, 162, 214, 166);
            sulphate2.GetComponent<SpriteRenderer>().color = new Color32(147, 147, 147, 96);
            sulphate3.GetComponent<SpriteRenderer>().color = new Color32(111, 105, 28, 175);
            metalsD[i].GetComponent<Rigidbody2D>().simulated = true;
            metalsD[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            metalsD[i].gameObject.GetComponent<CapsuleCollider2D>().enabled = true;

        }
        metalsD[0].transform.position = initialPosition;
        magnesiumReaction.counter = 0;
    }

    public void copperSulphateReaction()
    {
        if (MetalDrag.copperCollided && copperReaction.counter == 1)
        {

        }
        if (MetalDrag.copperCollided == true && zincReaction.counter >= 1)
        {
            StartCoroutine(copperSulphateRColorTransition());
        }
        if (MetalDrag.copperCollided && ironReaction.counter >= 1)
        {
            StartCoroutine(copperSulphateColorTransition2());


        }
        if (MetalDrag.copperCollided && magnesiumReaction.counter >= 1)
        {

            mag_copperSulphateParticles.SetActive(true);
            StartCoroutine(copperSulphateColorTransition3());

        }
    }

    public void zincSulphateReaction()
    {
        if (MetalDrag.zincCollided && magnesiumReaction.counter >= 1)
        {
            mag_zincSulphateParticles.SetActive(true);
            StartCoroutine(zincSulphateTransition());
            //Invoke("stopReaction", reactionDuration);
        }
    }

    public void ironSulphateReaction()
    {
        if (MetalDrag.ironCollided && copperReaction.counter >= 1)
        {
        }
        if (MetalDrag.ironCollided && zincReaction.counter >= 1)
        {
            StartCoroutine(ironSulphateZincTransition());
        }
        if (MetalDrag.ironCollided && ironReaction.counter >= 1)
        {

        }
        if (MetalDrag.ironCollided && magnesiumReaction.counter >= 1)
        {
            mag_ironSuphateParticles.SetActive(true);
            StartCoroutine(ironSulphateMagTransition());
            //Invoke("stopReaction", reactionDuration);
        }
    }

    public void stopReaction()
    {
        mag_copperSulphateParticles.SetActive(false);
        mag_zincSulphateParticles.SetActive(false);
        mag_ironSuphateParticles.SetActive(false);

    }
    public void resetTime()
    {
        time = 0;
        zincTime = 0;
        ironTime = 0;
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
        Color endColor = new Color32(219, 219, 219, 87);

        while (zincTime < duration)
        {
            sulphate2.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, zincTime / duration);
            zincTime += Time.deltaTime;
            yield return null;
        }
        sulphate2.GetComponent<SpriteRenderer>().color = endColor;
    }

    IEnumerator ironSulphateZincTransition()
    {
        Color startColor = sulphate3.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(129, 125, 75, 45);

        while (ironTime < duration)
        {
            sulphate3.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, ironTime / duration);
            ironTime += Time.deltaTime;
            yield return null;
        }
        sulphate3.GetComponent<SpriteRenderer>().color = endColor;
    }

    IEnumerator ironSulphateMagTransition()
    {
        Color startColor = sulphate3.GetComponent<SpriteRenderer>().color;
        Color endColor = new Color32(147, 147, 147, 96);

        while (ironTime < duration)
        {
            sulphate3.GetComponent<SpriteRenderer>().color = Color.Lerp(startColor, endColor, ironTime / duration);
            ironTime += Time.deltaTime;
            yield return null;
        }
        sulphate3.GetComponent<SpriteRenderer>().color = endColor;
    }

}
