using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class AT_Profile 
{
    public string idProfile;

    public int LastScene;
    
    [Serializable]
    public struct customDateTime
    {
        public int year; public int month;        public int day;
       
        public int hour;    public int minute; public int second;
             
    }


    public customDateTime dateTime;

    public bool[] completedLevel;
   
    //public AT_Profile()
    //{
    //    completedLevel = new bool[SceneManager.sceneCountInBuildSettings];
    //    for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
    //    {
    //        completedLevel[i] = false;
    //    }
    //}

    public void Save()
    {
        LastScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void Load()
    {


    }


   
}