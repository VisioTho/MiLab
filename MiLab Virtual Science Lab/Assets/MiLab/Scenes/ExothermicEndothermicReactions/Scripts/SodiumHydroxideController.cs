using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TemperatureReaction
{
    public static int counter;

    private void SodiumHydroxideReaction()
    {
        
        if (counter >= 1)
        {
            removeSoluteButton.interactable = true;
            chemicalDisplay.text = "NaOH (Sodium Hydroxide)";
            chemicalProduct1.text = "Na+ (Sodium ions)";
            chemicalProduct2.text = "OH+ (Hydroxide ions)";
        }
        if (stirTime > 1.2f)
        {
            if (transform.localScale.y > initialTemperatureLevels.y)
            {

            }

            if (counter == 1)
            {
                RiseMercuryLevels(temperatureDropRate, Random.Range(2.4f, 2.5f));
                //MeltSodiumHydroxide(0.00002f);

                //stirTime = 0f;
            }
            else if (counter == 2)
            {
                RiseMercuryLevels(temperatureDropRate, Random.Range(2.6f, 2.7f));
                //MeltSodiumHydroxide(0.00002f);

                //chemicalDisplay.text = "Water + Sodium Hydroxide";
            }
            else if (counter == 3)
            {
                RiseMercuryLevels(temperatureDropRate, Random.Range(2.8f, 2.9f));
                //MeltSodiumHydroxide(0.00002f);

                //removeSoluteButton.interactable = true;
                //chemicalDisplay.text = "Water + Sodium Hydroxide";
            }
            else if (counter >= 4)
            {
                RiseMercuryLevels(temperatureDropRate, Random.Range(3.0f, 3.1f));
                //MeltSodiumHydroxide(0.00002f);
                //chemicalDisplay.text = "Water + Sodium Hydroxide";

            }

        }
        else
        {
            
        }
    }

    void MeltSodiumHydroxide(float meltSpeed)
    {
        if (pellets[0].activeSelf && stopper == 0)
        {
            for (int i = 0; i < pellets.Length; i++)
            {
                if (pellets[i].activeSelf)
                {
                    Vector2 tempScale = pellets[i].transform.localScale;
                    var V = meltSpeed;
                    if (tempScale.y > 0.01 && tempScale.x > 0.01)
                    {
                        tempScale.y -= V;
                        tempScale.x -= V;

                        pellets[i].transform.localScale = tempScale;
                    }
                }
            }

        }
    }
}
    
