using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetNeedle : MonoBehaviour
{

    public SwitchController switchControl;
    public VoltmeterController voltmeterController;
    //  public AmmeterController ammeterController;
    public Quaternion currentRotation;
    public Quaternion targetRotation;
    public GameObject rotationParent;
    public static float rot_duration;
    public static float z_rotation_angle;
    void Start()
    {
        rot_duration = 1f;
        z_rotation_angle = 0;
    }

    private void OnMouseDown()
    {
        StartCoroutine(needleRotation(targetRotation));
    }

    // Update is called once per frame
    void Update()
    {
        if (switchControl.switch_is_on == false)
        {
            z_rotation_angle = 169.797f;
            targetRotation = Quaternion.Euler(new Vector3(0, 0, z_rotation_angle));
            StartCoroutine(needleRotation(targetRotation));
        }
        else if (switchControl.switch_is_on == true)
        {
            Debug.Log("switch is back on");
            voltmeterController.UpdateSpeed();
            //  ammeterController.UpdateSpeed();
        }
    }

    IEnumerator needleRotation(Quaternion targetRotation)
    {
        float rot_time = 0;
        Quaternion startRotation = rotationParent.transform.rotation;
        while (rot_time < rot_duration)
        {
            rotationParent.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, rot_time / rot_duration);
            rot_time += Time.deltaTime;
            yield return null;
        }
        rotationParent.transform.rotation = targetRotation;
        rot_time = 0;
    }
}
