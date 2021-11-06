// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class fillBurette : MonoBehaviour
// {
//     public TMP_Text buretteReader;
//     private float updatedReading = 50f;

//     [SerializeField]
//     private Image ReadingBar;
//     public float maxReading = 40f;

//     public void buretteFill()
//     {
//         while (updatedReading > 0)
//         {
//             buretteReader.text = (float)updatedReading + " ml";
//             ReadingBar.fillAmount = updatedReading / maxReading;

//             updatedReading++;
//         }
//     }

//     public void buretteDrop()
//     {

//     }
// }
