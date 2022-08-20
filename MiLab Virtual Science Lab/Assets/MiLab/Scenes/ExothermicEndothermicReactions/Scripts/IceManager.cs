
using UnityEngine;

public partial class TemperatureReaction
{
    private float meltSpeed;
    private void IceReaction()
    {
        
         Debug.Log("Should start collapsing");
        if (iceCube.activeSelf == true) // if at least the first ice cube is active
        {
            if (ThermometerManager.isImmersed)
            {
                CollapseMercuryLevels(meltSpeed, ice.changeInTemperature);
            }
            else
                RiseMercuryLevels(temperatureDropRate, initialTemperatureLevels.y);

            if (stirTime > 1.2f)
            {
                var tempChange = Random.Range(0.4f, 0.2f);
                ice.changeInTemperature = tempChange;
                meltSpeed = temperatureDropRate;


                MeltIceCubes(0.00002f);
                removeSoluteButton.interactable = true;
                chemicalDisplay.text = "Water + Ice";
            }
            else
            {
               
                meltSpeed = 0.00002f;
                MeltIceCubes(0.0000002f);
            }
        }
    }

    //melt ice cubes gradually
    int stopper = 0; // prevents update from being called more than once on this function
    public void MeltIceCubes(float meltSpeed)
    {
        if (iceCube.activeSelf && stopper == 0)
        {
            for (int i = 0; i < iceCubes.Length; i++)
            {
                Vector2 tempScale = iceCubes[i].transform.localScale;
                var V = meltSpeed;
                if (tempScale.y > 0.001 && tempScale.x > 0.001)
                {
                    tempScale.y -= V;
                    tempScale.x -= V;
                    iceCubes[i].transform.localScale = tempScale;
                }
            }

        }
    }
}
