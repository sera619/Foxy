using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
public class SaveLoad : MonoBehaviour
{  
    public static void Save<T>(T objectToSave, string key){
        string path = Application.persistentDataPath + "/saves/";
        // erstellt Verzeichnis unter SystemPfad 
        Directory.CreateDirectory(path);
        // importiert den Binär - Formatierer
        BinaryFormatter formatter = new BinaryFormatter();
        
        using (FileStream fileStream = new FileStream(path + key + ".txt", FileMode.Create)){
            formatter.Serialize(fileStream,objectToSave);
        }
        Debug.Log("Obeject gespeichert: " + objectToSave);

    }

    public static T Load<T>(string key){
        string path = Application.persistentDataPath + "/saves/";
        BinaryFormatter formatter = new BinaryFormatter();
        T returnValue = default(T);
        using (FileStream fileStream = new FileStream(path + key + ".txt", FileMode.Open)){
            returnValue = (T)formatter.Deserialize(fileStream);
        }
        return returnValue;
    }


    public static bool SaveExists(string key){
        string path = Application.persistentDataPath + "/saves/" + key + ".txt";
        return File.Exists(path);
    }


    
    public static void SrslyDeleteAllSaveFiles(){
        string path = Application.persistentDataPath + "/saves/";
        DirectoryInfo directory = new DirectoryInfo(path);
        directory.Delete();
        Directory.CreateDirectory(path);
    }



}
