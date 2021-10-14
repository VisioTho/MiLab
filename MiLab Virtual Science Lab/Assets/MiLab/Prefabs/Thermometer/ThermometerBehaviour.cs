using UnityEngine;
public class ThermometerBehaviour: MonoBehaviour
{

    public void CollapseMercuryLevels(float speed, float dropBy)
    {
        Vector3 tempScale = transform.localScale;
        var V = speed;
        if (tempScale.y >= dropBy)
        {
            tempScale.y -= V;
            transform.localScale = tempScale;
        }
    }

    public void RiseMercuryLevels(float speed, float riseBy)
    {
        Vector3 tempScale = transform.localScale;
        var V = speed;
        if (tempScale.y <= riseBy)
        {
            tempScale.y += V;
            transform.localScale = tempScale;
        }

    }

    //calculate temperature from room temperature (24)
    public float CalculateTemperature()
    {
        float temperatureReading = (gameObject.transform.localScale.y / 1f) * 24f;
        return temperatureReading;
    }
}