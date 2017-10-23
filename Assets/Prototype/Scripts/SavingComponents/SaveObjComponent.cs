﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveGame
{
    public class SaveObjComponent : MonoBehaviour
    {

        [HideInInspector] public string saveObjName;

        [Header("Position parameters", order = 1)]
        [Tooltip("Save the object position")]
        public bool savePosition = true;
        [Tooltip("Save the object rotation")]
        public bool saveRotation = false;
        [Space]

        [Header("Saving settings")]
        [Tooltip("Load the object position (if available) when the scene start")]
        public bool setOnAwake = false;
        [Tooltip("Save the object when the applicatio is closed")]
        public bool memorizeOnClose = true;


        struct ObjectPosition
        {
            public float x;
            public float y;
            public float z;
            public float xRotation;
            public float yRotation;
            public float zRotation;

        }
        ObjectPosition ObjPos;


        private void Awake()
        {
            saveObjName = gameObject.name + transform.position.x.ToString() + transform.position.y.ToString() + transform.position.z.ToString();

            if (setOnAwake)
            {
                LoadData();
            }
        }

        private void OnApplicationQuit()
        {
            if (memorizeOnClose)
            {
                PlayerPrefs.Save();
            }
            if (GMController.instance.m_CheckpointManager.SaveOnClose)
            {
                SaveData();
            }
        }

        //Caricamento dati (Se presenti)
        public virtual void LoadData()
        {
            if (savePosition)
            {
                if (PlayerPrefs.HasKey(saveObjName + "PositionX") && PlayerPrefs.HasKey(saveObjName + "PositionY") && PlayerPrefs.HasKey(saveObjName + "PositionZ"))
                {
                    //Debug.Log("Caricate Coordinate di: " + saveObjName + " x=" + ObjPos.x + " y=" + ObjPos.y + " z=" + ObjPos.z);
                    transform.position = new Vector3(PlayerPrefs.GetFloat(gameObject.name + "PositionX"),
                        PlayerPrefs.GetFloat(saveObjName + "PositionY"), PlayerPrefs.GetFloat(saveObjName + "PositionZ"));
                }

            }
            if (saveRotation)
            {
                if (PlayerPrefs.HasKey(saveObjName + "RotationX") && PlayerPrefs.HasKey(saveObjName + "RotationY") && PlayerPrefs.HasKey(saveObjName + "RotationZ"))
                {
                    //Debug.Log("Caricata Rotazione di: " + saveObjName + " x=" + ObjPos.xRotation + " y=" + ObjPos.yRotation + " z=" + ObjPos.zRotation);
                    transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat(saveObjName + "RotationX"),
                        PlayerPrefs.GetFloat(saveObjName + "RotationY"), PlayerPrefs.GetFloat(saveObjName + "RotationZ"));
                }
            }

        }

        //Salvataggio dati (Posizione,Rotazioni), integrazione successica (, stato)
        public virtual void SaveData()
        {
            if (savePosition)
            {
                ObjPos.x = this.transform.position.x;
                ObjPos.y = this.transform.position.y;
                ObjPos.z = this.transform.position.z;
                PlayerPrefs.SetFloat(saveObjName + "PositionX", ObjPos.x);
                PlayerPrefs.SetFloat(saveObjName + "PositionY", ObjPos.y);
                PlayerPrefs.SetFloat(saveObjName + "PositionZ", ObjPos.z);
                //Debug.Log("Salvate Coordinate di: " + saveObjName + " x=" + ObjPos.x + " y=" + ObjPos.y + " z=" + ObjPos.z);
            }
            if (saveRotation)
            {
                ObjPos.xRotation = this.transform.rotation.x;
                ObjPos.yRotation = this.transform.rotation.y;
                ObjPos.zRotation = this.transform.rotation.z;
                PlayerPrefs.SetFloat(saveObjName + "RotationX", ObjPos.xRotation);
                PlayerPrefs.SetFloat(saveObjName + "RotationY", ObjPos.yRotation);
                PlayerPrefs.SetFloat(saveObjName + "RotationZ", ObjPos.zRotation);
                //Debug.Log("Salvata Rotazione di: " + saveObjName + " x=" + ObjPos.xRotation + " y=" + ObjPos.yRotation + " z=" + ObjPos.zRotation);

            }
        }
    }
}