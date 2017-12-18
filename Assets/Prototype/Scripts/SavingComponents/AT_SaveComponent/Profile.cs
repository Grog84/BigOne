using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using System;
using Convertitore;
using System.IO;


    [Serializable]
    public class Profile
    {
        public string idProfile;

        public int LastScene;
     static Converter C = new Converter();
    [Serializable]
        public struct customDateTime
        {
            public int year; public int month; public int day;

            public int hour; public int minute; public int second;

        }
        public customDateTime dateTime;

        public bool[] completedLevel;

        public void Save()
        {
            LastScene = SceneManager.GetActiveScene().buildIndex;
        }
        public static void SaveProfile(string path, Profile profile)
        {

            string json = JsonUtility.ToJson(profile);
        string save = "";
        StreamWriter sw = File.CreateText(path);
            sw.Close();
        foreach (char a in json)
        {
            save += C.FromTo(10, 16, Convert.ToInt32(a).ToString()) + " ";
        }
        json = save;
        File.WriteAllText(path, json);
        }
        public static Profile LoadProfile(string path)
        {
            string json = File.ReadAllText(path);
        string[] savedData;
        string save = "";
        savedData = json.Split(' ');
        for (int i = 0; i < savedData.Length; i++)
        {
            save += (char)Convert.ToInt32(C.FromTo(16, 10, savedData[i]));
        }
        return JsonUtility.FromJson<Profile>(save);


        }

    }
