using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SaveShit : MonoBehaviour
{

    private class SaveObject
    {
        public Vector3 nerdPosition;
    }

    private void Save()
    {
        Vector3 playerPosition = transform.position;

        SaveObject saveObject = new SaveObject {
            nerdPosition = playerPosition
        };
        string json = JsonUtility.ToJson(saveObject);

        File.WriteAllText(Application.dataPath + "/save.txt", json);


    }

    void Awake()
    {
        SaveObject saveObject = new SaveObject
        {
            
        };
        string json = JsonUtility.ToJson(saveObject);

        SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(json);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
