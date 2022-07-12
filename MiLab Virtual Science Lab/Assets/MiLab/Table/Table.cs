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

    //save data from table to file
    public void SaveTableData()
    {
        ExtractDataFromTableFields();
        ExtractDataFromToggles();

        SaveSystem.SaveTable(this);


        // get input from fields
        void ExtractDataFromTableFields()
        {
            if (cellInput != null)
            {
                for (int i = 0; i < cellInput.Length; i++)
                {
                    data[i] = cellInput[i].text;
                }

            }
        }

        //get input from toggles
        void ExtractDataFromToggles()
        {  
            if(toggles != null)
            {
                for (int i = 0; i < toggles.Length; i++)
                {
                    if (!toggles[i].isOn)
                        checkmarkStates[i] = toggles[i].isOn;
                    else
                        checkmarkStates[i] = toggles[i].isOn;
                }
            }
                
        }
    }

   
    // load data from file back into the table
    public void LoadTableData()
    {
        TableData data = SaveSystem.LoadTable(this);

        LoadFileDataIntoCells(data);

        //populate table fields in inspector with last saved information
        void LoadFileDataIntoCells(TableData data)
        {
            if(cellInput != null)
            {
                for (int i = 0; i < cellInput.Length; i++)
                {
                    if (data.cellData[i] != "0")
                        cellInput[i].text = data.cellData[i];
                }
            }

            if(toggles != null)
            {
                for (int i=0; i < toggles.Length; i++)
                {
                    toggles[i].isOn = data.checkmarkState[i]; 
                }
            }
            
        }

    } 
    
    public void ClearTableContents()
    {
        foreach (TMP_InputField a in cellInput)
        {
            a.text = "";
        }
    }
}
