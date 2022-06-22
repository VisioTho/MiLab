
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
   public static void SaveTable( Table table)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        TableData tableData = new TableData(table);

        string tempFileName = tableData.fileName;
        string path = GetPath(tempFileName);
        FileStream stream = new FileStream(path, FileMode.Create);

        
        formatter.Serialize(stream, tableData);
        stream.Close();
    }

    //get the name of the file set in inspector 
    private static string GetPath(string saveFileName)
    {
        return Application.persistentDataPath +"/" +saveFileName;
    }

    public static TableData LoadTable(Table table)
    {
        TableData tableData = new TableData(table);
        string path = GetPath(tableData.fileName);
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            TableData data = formatter.Deserialize(stream) as TableData;

            stream.Close();

            return data;
           
        }
        else
        {
            Debug.LogError("File not found in " + path);
            return null;
        }
    }
}
