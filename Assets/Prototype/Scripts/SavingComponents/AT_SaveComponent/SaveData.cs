using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData  {

    public static ActorContainer actorContainer = new ActorContainer();

    public delegate void SerializeAction();
    public static event SerializeAction OnLoaded;
    public static event SerializeAction OnBeforeSave;

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

        return JsonUtility.FromJson<ActorContainer>(json);

    }

    private static void SaveActors(string path, ActorContainer actors)
    {
        string json = JsonUtility.ToJson(actors);

        StreamWriter sw = File.CreateText(path);
        sw.Close();

        File.WriteAllText(path, json);


    }
}
