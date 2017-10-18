using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObjComponent : MonoBehaviour {

    public string saveObjName;
    [Space]

    [Header("Parametri da salvare dell'oggetto", order = 1)]
    [Tooltip("Salvare la rotazione di un oggetto?")]
    public bool savePosition = true;
    [Tooltip("Salvare la rotazione di un oggetto?")]
    public bool saveRotation = false;//Necessita prova tecnica HardCoded
    [Space]
    
    [Header("Impostazioni caricamento / salvataggio")]
    [Tooltip("Caricare ultima posizione ('se disponibile') all'avvio della applicazione?")]
    public bool setOnAwake = false;
    [Tooltip("Salvare le impostazioni memorizate alla chiusura della applicazione?")]
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

    private void OnEnable()
    {
        saveObjName = gameObject.name;
    }

    private void Awake()
    {
        
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
    public void LoadData()
    {
        if (savePosition)
        {
            if (PlayerPrefs.HasKey(saveObjName + "PositionX") && PlayerPrefs.HasKey(saveObjName + "PositionY") && PlayerPrefs.HasKey(saveObjName + "PositionZ"))
            {
                Debug.Log("Caricate Coordinate di: " + saveObjName + " x=" + ObjPos.x + " y=" + ObjPos.y + " z=" + ObjPos.z);
                transform.position = new Vector3(PlayerPrefs.GetFloat(gameObject.name + "PositionX"),
                    PlayerPrefs.GetFloat(saveObjName + "PositionY"), PlayerPrefs.GetFloat(saveObjName + "PositionZ"));
            }

        }
        if (saveRotation)
        {
            if (PlayerPrefs.HasKey(saveObjName + "RotationX") && PlayerPrefs.HasKey(saveObjName + "RotationY") && PlayerPrefs.HasKey(saveObjName + "RotationZ"))
            {
               Debug.Log("Caricata Rotazione di: " + saveObjName + " x=" + ObjPos.xRotation + " y=" + ObjPos.yRotation + " z=" + ObjPos.zRotation);
                transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat(saveObjName + "RotationX"),
                    PlayerPrefs.GetFloat(saveObjName + "RotationY"), PlayerPrefs.GetFloat(saveObjName + "RotationZ"));
            }
        }

    }

    //Salvataggio dati (Posizione,Rotazioni), integrazione successica (, stato)
    public void SaveData()
    {
        if (savePosition)
        {
            ObjPos.x = this.transform.position.x;
            ObjPos.y = this.transform.position.y;
            ObjPos.z = this.transform.position.z;
            PlayerPrefs.SetFloat(saveObjName + "PositionX", ObjPos.x);
            PlayerPrefs.SetFloat(saveObjName + "PositionY", ObjPos.y);
            PlayerPrefs.SetFloat(saveObjName + "PositionZ", ObjPos.z);
            Debug.Log("Salvate Coordinate di: " + saveObjName + " x=" + ObjPos.x + " y=" + ObjPos.y + " z=" + ObjPos.z);
        }
        if (saveRotation)
        {
            ObjPos.xRotation = this.transform.rotation.x;
            ObjPos.yRotation = this.transform.rotation.y;
            ObjPos.zRotation = this.transform.rotation.z;
            PlayerPrefs.SetFloat(saveObjName + "RotationX", ObjPos.xRotation);
            PlayerPrefs.SetFloat(saveObjName + "RotationY", ObjPos.yRotation);
            PlayerPrefs.SetFloat(saveObjName + "RotationZ", ObjPos.zRotation);
            Debug.Log("Salvata Rotazione di: " + saveObjName + " x=" + ObjPos.xRotation + " y=" + ObjPos.yRotation + " z=" + ObjPos.zRotation);

        }
    }
}
