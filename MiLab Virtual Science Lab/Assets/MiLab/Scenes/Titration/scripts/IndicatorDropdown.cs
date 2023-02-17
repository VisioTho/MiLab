using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Table : MonoBehaviour
{

    public string saveFileName;
    public TMP_InputField[] cellInput;
    public Toggle[] toggles;
    public string[] data;
    public bool[] checkmarkStates;
    

    private void Start()
    {
        LoadTableData();
    }

    private void Update()
    {
        Debug.Log("state is " + toggles[0].isOn);
    }
    //save data from table to file
    public void SaveTableData()
    {
        ExtractDataFromTableFi