using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FlameController : MonoBehaviour
{
    private const bool V = true;

    //reference to flame particle system
    public ParticleSystem flame;

    // orange flame color
    Color flameorange = new Color(0.9058824f, 0.5333334f, 0.03529412f);
    // blue flame color
    Color flameblue = new Color(0.1215686f, 0.7823045f, 0.9098039f);
    //reference to gas hissing sound audio source
    [SerializeField] private AudioSource gasHiss;

    //Start is called before the first frame
    void Start()
    {
        //assign default color (safety flame) to flame particle system
        Gradient grad = new Gradient();
        var col = flame.colorOverLifetime;
        col.enabled = V;
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(flameorange, 0.0f), new GradientColorKey(flameorange, 1.0f), new GradientColorKey(Color.white, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        col.color = grad;

        //no emission of flame particles on wake
        flame.Stop();
    }

    //update is called once every frame
    void Update()
    {
        // pause gas hissing sound if 'flame' is emitting particles
        if (flame.isEmitting)
        {
            gasHiss.Pause();
        }
    }

    /*function controlling the "gas" slider*/
    public void adjustFlame(float val)
    {
        //variable reference for .main flame particle system
        var main = flame.main;
        // adjust lifetime of particles according to slider's position
        main.startLifetime = val;
    }

    /*function controlling the "air holes" slider*/
    public void adjustHeat(float val)
    {
        //local reference to colorOverlifetime of the flame particle system
        var col = flame.colorOverLifetime;

        col.enabled = V;

        //local grad variable used to change colorOverlifetime value based on slider position
        Gradient grad = new Gradient();

        // if "air holes" slider position is at n then assign gradient values xyz as the new colorOverLifetime values
        if (val == 3)
        {
            grad.SetKeys(new GradientColorKey[] { new GradientColorKey(flameorange, 0.0f), new GradientColorKey(flameorange, 1.0f), new GradientColorKey(Color.white, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        }

        if (val == 2)
        {
            grad.SetKeys(new GradientColorKey[] { new GradientColorKey(flameblue, 0.0f), new GradientColorKey(Color.red, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f), new GradientAlphaKey(0.0f, 1.0f) });
        }

        if (val == 1)
        {
            grad.SetKeys(new GradientColorKey[] { new GradientColorKey(flameblue, 0.0f), new GradientColorKey(Color.black, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        }

        if (val == 0)
        {
            grad.SetKeys(new GradientColorKey[] { new GradientColorKey(flameblue, 0.0f), new GradientColorKey(Color.black, 1.0f), new GradientColorKey(flameblue, 0.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 0.8f), new GradientAlphaKey(0.0f, 0.0f) });
        }

        // let the value of grad be the new colorOverLifetime value of the flame particle system
        col.color = grad;

    }

    [SerializeField] private TMP_Text onofflabel;
    public static bool isOpened = false;
    /*this function controls the "Gas" button that toggles the particle system to play or stop playing*/
    public void toggleFlame()
    {
        //if flame particle is not emitting 
        if (!flame.isEmitting)
        {
            isOpened = true;
            onofflabel.text = "On";
            gasHiss.Play();
        }
        else
        {
            isOpened = false;
            flame.Stop();
            gasHiss.Pause();
            onofflabel.text = "Off";
        }


    }

}
