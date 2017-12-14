using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using System;
using System.IO;


    [Serializable]
    public class Profile
    {
        public string idProfile;

        public int LastScene;

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

            StreamWriter sw = File.CreateText(path);
            sw.Close();

            File.WriteAllText(path, json);
        }
        public static Profile LoadProfile(string path)
        {
            string json = File.ReadAllText(path);

            return JsonUtility.FromJson<Profile>(json);


        }

    }
