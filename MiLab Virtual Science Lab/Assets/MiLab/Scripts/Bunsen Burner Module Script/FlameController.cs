using TMPro;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    private const bool V = true;

    public ParticleSystem flame;

    Color flameorange = new Color(0.9058824f, 0.5333334f, 0.03529412f);
    
    Color flameblue = new Color(0.1215686f, 0.7823045f, 0.9098039f);
   
    public AudioSource gasHiss;

    public SpriteRenderer bunsenBurnerSpriteRenderer;

    public Sprite[] bunsenBurnerSprites; 

    public TMP_Text onofflabel;

    public static bool gasOn = false;

    void Start()
    {
   
        AssignDefaultColorOverLifetime();

        flame.Stop();
    }

    //Assign default (yellowish orange) color over lifetime to flame particle system
    private void AssignDefaultColorOverLifetime()
    {
        Gradient grad = new Gradient();
        var col = flame.colorOverLifetime;
        col.enabled = V;
        grad.SetKeys(new GradientColorKey[]
        { new GradientColorKey(flameorange, 0.0f), new GradientColorKey(flameorange, 1.0f),
            new GradientColorKey(Color.white, 1.0f) }, new GradientAlphaKey[]
            { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });

        col.color = grad;
    }

    public void TurnGasOn()
    {
        if (!flame.isEmitting)
        {
            gasOn = true;
            onofflabel.text = "On";
            gasHiss.Play();
        }
        else
        {
            gasOn = false;
            flame.Stop();
            gasHiss.Pause();
            onofflabel.text = "Off";
        }
    }

    //function controlling the "gas" slider
    public void AdjustFlame(float val)
    {
        var main = flame.main;
        main.startLifetime = val;
    }

    //function controlling air holes slider
    public void AdjustHeat(float val)
    {
        var col = flame.colorOverLifetime;

        col.enabled = V;

        Gradient grad = new Gradient();

        //Change coloroverlifetime and burner sprite depending on slider adjustment
        switch (val)
        {
            case 3:
                ChangeBunsenBurnerSprite(0);
                grad.SetKeys(new GradientColorKey[] { new GradientColorKey(flameorange, 0.0f), new GradientColorKey(flameorange, 1.0f), new GradientColorKey(Color.white, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
                break;
            case 2:
                ChangeBunsenBurnerSprite(1);
                grad.SetKeys(new GradientColorKey[] { new GradientColorKey(flameblue, 0.0f), new GradientColorKey(Color.red, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f), new GradientAlphaKey(0.0f, 1.0f) });
                break;
            case 1:
                ChangeBunsenBurnerSprite(2);
                grad.SetKeys(new GradientColorKey[] { new GradientColorKey(flameblue, 0.0f), new GradientColorKey(Color.black, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
                break;
            case 0:
                ChangeBunsenBurnerSprite(3);
                grad.SetKeys(new GradientColorKey[] { new GradientColorKey(flameblue, 0.0f), new GradientColorKey(Color.black, 1.0f), new GradientColorKey(flameblue, 0.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 0.8f), new GradientAlphaKey(0.0f, 0.0f) });
                break;
        }

        // Assign new coloroverlifetime
        col.color = grad;

    }


    void Update()
    {
        PauseGasHissingSound();
    }    

    private void PauseGasHissingSound()
    {
        if (flame.isEmitting)
        {
            gasHiss.Pause();
        }
    }

    //swap bunsen burner sprites depending on slider values
    void ChangeBunsenBurnerSprite(int n)
    {
        bunsenBurnerSpriteRenderer.sprite = bunsenBurnerSprites[n];
    }

}
