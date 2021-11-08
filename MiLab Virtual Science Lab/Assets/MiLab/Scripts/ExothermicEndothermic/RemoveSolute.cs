using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveSolute : TemperatureReaction
{
    public ToggleGroup toggleGroup;

    public void RemoveSol()
    {
        ResetTemperature();
    }

    public void ResetSolute()
    {
        RemoveSol();
    }
}
