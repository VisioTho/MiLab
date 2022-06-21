
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
   public static void SaveTable( Table table)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = GetPath();
        FileStream stream = new FileStream(path, FileMode.Create);

        TableData tableData = new TableData(table);
        formatter.Serialize(stream, tableData);
        stream.Close();
    }

    private static string GetPath()
    {
        return Application.persistentDataPath + "/tabledata.milab";
    }

    public static TableData LoadTable()
    {
        string path = GetPath();
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
            Debug.LogError("File not foun in " + path);
            return null;
        }
    }
}
