using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Table : MonoBehaviour
{
    public TMP_Text[] cells;
    public TMP_InputField[] cellInput;
    public string data , data2, data3, data4, data5, data6, data7, data8, data9, data10, data11, data12, data13, data14, data15, data16, data17, data18, data19, data20;
    

    private void Start()
    {
        //data = float.Parse(cells[0].text);
    }

    private void CollectTableData()
    {
       // cellData[0] = cells[0].text;
        /*for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i].text != null)
                cellData[i] = cells[i].text;
            
        }*/
    }

    public void SaveTableData()
    {
        data = cells[0].text;
        data2 = cells[1].text;
        data3 = cells[2].text;
        data4 = cells[3].text;
        data5 = cells[4].text;
        data6 = cells[5].text;
        data7 = cells[6].text;
        data8 = cells[7].text;
        data9 = cells[8].text;
        data10 = cells[9].text;
        data11 = cells[10].text;
        data12 = cells[11].text;
        data13 = cells[12].text;
        data14 = cells[13].text;
        data15 = cells[14].text;
        data16 = cells[15].text;
        data17 = cells[16].text;
        data18 = cells[17].text;
        data19 = cells[18].text;
        data20 = cells[19].text;

        //CollectTableData();
        SaveSystem.SaveTable(this);

        
    }

    public void LoadTableData()
    {
        TableData data = SaveSystem.LoadTable();
        Debug.Log("give me" +data.cellData);

        cellInput[0].text = data.cellData;
        cellInput[1].text = data.cellData2;

       //cells[0].text = data.cellData;
        
    }
}
