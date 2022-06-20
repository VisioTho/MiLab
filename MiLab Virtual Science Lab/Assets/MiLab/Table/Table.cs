using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Table : MonoBehaviour
{
    public TMP_InputField[] cells;
    public float[] cellData;

    private void Start()
    {
        CollectTableData();
    }

    private void CollectTableData()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            cellData[i] = float.Parse(cells[i].text);
        }
    }

    public void SaveTableData()
    {
        CollectTableData();
    }

    public void LoadTableData()
    {

    }
}
