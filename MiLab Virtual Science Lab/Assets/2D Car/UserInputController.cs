using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputController : MonoBehaviour
{
    /*--------------------------------------------------------------------
                            Script Summary 
        Gets input for movement of 2D car using buttons in scene 
        (forward or backward). Interacts with carController.cs via static
         variable
    ------------------------------------------------------------------------                 
                                                                        */

  //state of the car                                                                 
  public static bool isForward, isBackward, isDiscelerating;

  //move the car forward
  public void moveforward()
  {
      //update state of the car
      isForward = true;
      isBackward = false;
      isDiscelerating = false;
  }

  //move the car backwards
  public void moveBackward()
  {
      //update state of the car
      isForward = false;
      isBackward = true;
      isDiscelerating = false;
  }

  //discelerate the car 
  public void discelerate()
  {
      //update state of the car
      isDiscelerating = true;
      isForward = false;
      isBackward = false;
  }
}
