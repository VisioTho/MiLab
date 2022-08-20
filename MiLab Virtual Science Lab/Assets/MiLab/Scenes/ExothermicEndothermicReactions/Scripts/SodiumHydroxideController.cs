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

            if (ThermometerManager.isImmersed)
            {
                Debug.Log("sodium is " + sodiumHydroxide.changeInTemperature);
                RiseMercuryLevels(temperatureDropRate, sodiumHydroxide.changeInTemperature);
            }

            else
                CollapseMercuryLevels(temperatureDropRate, initialTemperatureLevels.y);
        }

        if (stirTime > 1.2f)
        {

            if (counter == 1)
            {
                var tempChange = Random.Range(2.4f, 2.5f);
                sodiumHydroxide.changeInTemperature = tempChange;
          
            }
            else if (counter == 2)
            {
                var tempChange = Random.Range(2.6f, 2.7f);
                sodiumHydroxide.changeInTemperature = tempChange;
               
            }
            else if (counter == 3)
            {
                var tempChange = Random.Range(2.8f, 2.9f);
                sodiumHydroxide.changeInTemperature = tempChange;
            }
            else if (counter >= 4)
            {
                var tempChange = Random.Range(3.0f, 3.1f);
                sodiumHydroxide.changeInTemperature = tempChange;
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
    
