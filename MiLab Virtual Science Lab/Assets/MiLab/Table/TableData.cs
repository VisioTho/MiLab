using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TableData
{
    public string[] cellData;
    public bool[] checkmarkStates;
    public string fileName;

    // constructor for data collected from Table class
    // sets up the filename and input fields
    public TableData(Table table)
    {
        cellData = table.data;
        fileName = table.saveFileName;
        checkmarkStates = table.checkmarkStates;

    }
}
