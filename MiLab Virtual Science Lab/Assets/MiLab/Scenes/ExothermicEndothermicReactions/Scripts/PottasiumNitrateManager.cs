
using UnityEngine;

public partial class TemperatureReaction
{
    private void PottasiumNitrateReaction()
    {
        if (emissionTime >= 1.5f)
        {
            removeSoluteButton.interactable = true;
            chemicalDisplay.text = "KNO3 (Pottasium Nitrate)";
            chemicalProduct1.text = "K+ (Pottasium ions)";
            chemicalProduct2.text = "NO3- (Nitrate)"; 
        }
        if (stirTime > 1.2f)
        {

            if (emissionTime > 1f && emissionTime < 4f)
            {
                var tempChange = Random.Range(1.7f, 1.8f);
                potassiumNitrate.changeInTemperature = tempChange;
                
                CollapseMercuryLevels(temperatureDropRate, potassiumNitrate.changeInTemperature);
                //removeSoluteButton.interactable = true;

            }

            else if (emissionTime > 4f && emissionTime < 8f)
            {
                var tempChange = Random.Range(1.5f, 1.6f);
                potassiumNitrate.changeInTemperature = tempChange;
                
                CollapseMercuryLevels(temperatureDropRate, potassiumNitrate.changeInTemperature);
                //removeSoluteButton.interactable = true;
                //chemicalDisplay.text = "Water + Pottasium Nitrate";
            }
            else if (emissionTime > 8f)
            {
                var tempChange = Random.Range(1.4f, 1.5f);
                potassiumNitrate.changeInTemperature = tempChange;
                
                CollapseMercuryLevels(temperatureDropRate, potassiumNitrate.changeInTemperature);
                //removeSoluteButton.interactable = true;
                //chemicalDisplay.text = "Water + Pottasium Nitrate";
            }

           
        }

        else
        {
           
        }

    }
}
