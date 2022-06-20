using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableData
{
    public float[] cellData;

    public TableData(Table table)
    {
        for(int i=0; i < table.cells.Length; i++)
        {
            cellData[i] = table.cellData[i];
        }
    }
}
