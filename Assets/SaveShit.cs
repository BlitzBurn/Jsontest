using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SaveShit : MonoBehaviour
{
    public GameObject nerd;

    private class SaveObject
    {
        public Vector3 nerdPosition;
    }

    public void Save()
    {
        Vector3 playerPosition = transform.position;

        SaveObject saveObject = new SaveObject {
            nerdPosition = playerPosition
        };
        string json = JsonUtility.ToJson(saveObject);

        File.WriteAllText(Application.dataPath + "/save.txt", json);
        Debug.Log("Saved");


    }

    public void Load()
    {
        if (File.Exists(Application.dataPath+"/save.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/save.txt");

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            nerd.transform.position = saveObject.nerdPosition;

        }
    }

    void Awake()
    {
        SaveObject saveObject = new SaveObject
        {
            
        };
        string json = JsonUtility.ToJson(saveObject);

        SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(json);
    }

  
}
