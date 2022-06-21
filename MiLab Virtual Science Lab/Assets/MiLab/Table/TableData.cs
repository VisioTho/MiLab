using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TableData
{
    public string cellData, cellData2, cellData3, cellData4, cellData5, cellData6, cellData7, cellData8, cellData9, cellData10, cellData11, cellData12, cellData13, cellData14, cellData15, cellData16, cellData17, cellData18, cellData19, cellData20;

    public TableData(Table table)
    {

        cellData = table.data;
        cellData2 = table.data2;
        cellData3 = table.data3;
        cellData4 = table.data4;
        cellData5 = table.data5;
        cellData6 = table.data6;
        cellData7 = table.data7;
        cellData8 = table.data8;
        cellData9 = table.data9;
        cellData10 = table.data10;
        cellData11 = table.data11;
        cellData12 = table.data12;
        cellData13 = table.data13;
        cellData14 = table.data14;
        cellData15 = table.data15;
        cellData16 = table.data16;
        cellData17 = table.data17;
        cellData18 = table.data18;
        cellData19 = table.data19;
        cellData20 = table.data20;

    }
}
