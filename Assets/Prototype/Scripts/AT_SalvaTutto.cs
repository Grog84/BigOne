﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_SalvaTutto : MonoBehaviour {
    private AT_ProvaSalvataggio[] objWithSaveScript;
	// Use this for initialization
	void Start () {
      
      //  Debug.Log("Found " + Prova.Length + " element");
	}
    private void Awake()
    {
        objWithSaveScript = Object.FindObjectsOfType<AT_ProvaSalvataggio>();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveAllObj();
        //LoadAllObj();
            /*
           

            foreach (AT_ProvaSalvataggio c in Prova)
            {
                c.SaveData();

            }
            */
        }
    }
    void SaveAllObj()
    {
        
          //
       
        foreach (AT_ProvaSalvataggio c in objWithSaveScript)
        {
            c.SaveData();

        }
    }
    void LoadAllObj()
    {

        // Prova = Object.FindObjectsOfType<AT_ProvaSalvataggio>();

        foreach (AT_ProvaSalvataggio c in objWithSaveScript)
        {
            c.LoadData();

        }
    }
}
