﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System;

[Serializable]
public class NerdInfo
{
    public string Name;
    public Vector3 NerdPosition;
}

public class SaveShitServerBased : MonoBehaviour
{
    public GameObject TheFuckingNerd;

    public GameObject Load(string Name)
    {
        var request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/" + name);
        var response = (HttpWebResponse)request.GetResponse();

        using (var stream = response.GetResponseStream())
        {
            using (var reader = new StreamReader(stream))
            {
                var body = reader.ReadToEnd();
                var nerdInfo = JsonUtility.FromJson<NerdInfo>(body);
                var nerd = Instantiate(TheFuckingNerd, transform);

                nerd.transform.position = nerdInfo.NerdPosition;
                nerd.name = nerdInfo.Name;
            }
        }
        return null;
    }
    
    public void Save(string fileName, string savedata)
    {

        var request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/" + fileName);
        request.ContentType = "application/json";
        request.Method = "PUT";

       using (var streamWriter = new StreamWriter(request.GetRequestStream()))
       {
            streamWriter.Write(savedata);
            streamWriter.Close();
       }

        var httpResponse = (HttpWebResponse)request.GetResponse();

        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            Debug.Log(result);
        }

    }


}

