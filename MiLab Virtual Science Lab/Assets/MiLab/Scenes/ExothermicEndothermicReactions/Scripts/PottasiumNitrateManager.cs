
using UnityEngine;

public partial class TemperatureReaction
{
    
    private void PottasiumNitrateReaction()
    {
        Debug.Log(stirTime + "is stirtime " + " pottasium nitrate change in temp is " + potassiumNitrate.changeInTemperature +" number of spoons is " +numberOfSpoons);
        if (numberOfSpoons >= 1)
        {
            removeSoluteButton.interactable = true;
            chemicalDisplay.text = "KNO3 (Pottasium Nitrate)";
            chemicalProduct1.text = "K+ (Pottasium ions)";
            chemicalProduct2.text = "NO3- (Nitrate)";

            if (ThermometerManager.isImmersed && potassiumNitrate.changeInTemperature!=0) 
                CollapseMercuryLevels(temperatureDropRate, potassiumNitrate.changeInTemperature);

            if(!ThermometerManager.isImmersed)
            {
                RiseMercuryLevels(temperatureDropRate, initialTemperatureLevels.y);
                
            }
            
                
        }

       

        if (stirTime > 1.2f)
        {  
            if (numberOfSpoons == 1)
            {
                
                var tempChange = Random.Range(1.7f, 1.8f);
                potassiumNitrate.changeInTemperature = tempChange;

            }

            else if (numberOfSpoons == 2)
            {
                var tempChange = Random.Range(1.5f, 1.6f);
                potassiumNitrate.changeInTemperature = tempChange;
                
            }
            else if (numberOfSpoons >= 3)
            {
                var tempChange = Random.Range(1.4f, 1.5f);
                potassiumNitrate.changeInTemperature = tempChange;
                
            }
           
        }

    }
}
