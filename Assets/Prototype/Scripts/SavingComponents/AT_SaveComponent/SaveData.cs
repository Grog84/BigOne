using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using Convertitore;
using UnityEngine;

public class SaveData  {

    public static ActorContainer actorContainer = new ActorContainer();

    public delegate void SerializeAction();
    public static event SerializeAction OnLoaded;
    public static event SerializeAction OnBeforeSave;


  static  Converter C = new Converter();
    public static void Load(string path,Actor[] actors)
    {
        actorContainer = LoadActors(path);

        foreach (Actor a in actors)
        {
            for (int i = 0; i < actorContainer.actors.Count; i++)
            {
                if (actorContainer.actors[i].name == a.gameObject.name)
                {
                    a.data.name = a.gameObject.name;
                    a.data.pos = actorContainer.actors[i].pos;
                    a.gameObject.transform.position = a.data.pos;
                }
            }
        }
        OnLoaded();
        ClearActorList();
    }


    public static void Save(string path, ActorContainer actors)
    {
        OnBeforeSave();
        SaveActors(path, actors);
        ClearActorList();
    }

    public static void addActorData(ActorData data)
    {
        actorContainer.actors.Add(data);
    }


    public static void ClearActorList()
    {
        actorContainer.actors.Clear();
    }

    private static ActorContainer LoadActors(string path)
    {
        string json = File.ReadAllText(path);
        string[] savedData;
        string save = "";
        savedData = json.Split(' ');
        //for (int i = 0; i < savedData.Length; i++)
        //{
        //    save += (char)Convert.ToInt32(C.FromTo(16, 10, savedData[i]));
        //}

        return JsonUtility.FromJson<ActorContainer>(json);  
    }
    public static void SaveQuestContainer(string path,string Container)
    {

        string save = "";
        StreamWriter sw = File.CreateText(path);
        sw.Close();
        foreach (char a in Container)
        {
            save += C.FromTo(10, 16, Convert.ToInt32(a).ToString()) + " ";
        }
        Container = save;

        File.WriteAllText(path, Container);

    }
    private static void SaveActors(string path, ActorContainer actors)
    {
        string json = JsonUtility.ToJson(actors);
     
    
        string save = "";
        StreamWriter sw = File.CreateText(path);
        sw.Close();
        //foreach (char a in json)
        //{
        //    save += C.FromTo(10, 16, Convert.ToInt32(a).ToString()) + " ";
        //}
        //json = save;

        File.WriteAllText(path, json);
    }

   
}
