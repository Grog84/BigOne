using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AT_ProvaSalvataggio : MonoBehaviour
{
   
    [Header("Parametri da salvare dell'oggetto", order =1)]
    [Tooltip("Salvare la rotazione di un oggetto?")]
    public bool savePosition = true;
    [Tooltip("Salvare la rotazione di un oggetto?")]
     public bool saveRotation = false;//Necessita prova tecnica HardCoded
    [Space]
    [HideInInspector]public bool isOnCover = false;//Sperimentale
    [Header("Impostazioni caricamento / salvataggio")]
    [Tooltip("Caricare ultima posizione ('se disponibile') all'avvio della applicazione?")]
    public bool setOnAwake = false;
    [Tooltip("Salvare le impostazioni memorizate alla chiusura della applicazione?")]
    public bool memorizeOnClose = true;
    [Tooltip("Salvare ultima posizione oggetto alla chiusura della app?")]
    public bool saveOnClose = false;

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
        if (setOnAwake)
        {
            LoadData();
        }
   
    }
    // Use this for initialization
    void Start()
    {
 
       // ObjPos = new ObjectPosition { x = 0, y = 0, z = 0, xRotation = 0, yRotation=0, zRotation=0 };
    }
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F6))
        {
            SaveData();
          
        }
        if (Input.GetKeyDown(KeyCode.F7))
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
        if (saveOnClose)
        {
            SaveData();
        }
    }
    //Caricamento dati (Se presenti)
    private void LoadData()
    {
        if (savePosition)
        {
            if (PlayerPrefs.HasKey(this.gameObject.name + "PositionX") && PlayerPrefs.HasKey(this.gameObject.name + "PositionY") && PlayerPrefs.HasKey(this.gameObject.name + "PositionZ"))
            {
                Debug.Log("Caricate Coordinate di: " + this.gameObject.name + " x=" + ObjPos.x + " y=" + ObjPos.y + " z=" + ObjPos.z);
                this.transform.position = new Vector3(PlayerPrefs.GetFloat(this.gameObject.name + "PositionX"), PlayerPrefs.GetFloat(this.gameObject.name + "PositionY"), PlayerPrefs.GetFloat(this.gameObject.name + "PositionZ"));
            }
          
        }
        if(saveRotation)
        {
            if (PlayerPrefs.HasKey(this.gameObject.name + "RotationX") && PlayerPrefs.HasKey(this.gameObject.name + "RotationY") && PlayerPrefs.HasKey(this.gameObject.name + "RotationZ"))
            {
                Debug.Log("Caricata Rotazione di: " + this.gameObject.name + " x=" + ObjPos.xRotation + " y=" + ObjPos.yRotation + " z=" + ObjPos.zRotation);
                this.transform.position = new Vector3(PlayerPrefs.GetFloat(this.gameObject.name + "RotationX"), PlayerPrefs.GetFloat(this.gameObject.name + "RotationY"), PlayerPrefs.GetFloat(this.gameObject.name + "RotationZ"));
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
            PlayerPrefs.SetFloat(this.gameObject.name + "PositionX", ObjPos.x);
            PlayerPrefs.SetFloat(this.gameObject.name + "PositionY", ObjPos.y);
            PlayerPrefs.SetFloat(this.gameObject.name + "PositionZ", ObjPos.z);
            Debug.Log("Salvate Coordinate di: " + this.gameObject.name + " x=" + ObjPos.x + " y=" + ObjPos.y + " z=" + ObjPos.z);
        }
        if(saveRotation)
        {
            ObjPos.xRotation = this.transform.rotation.x;
            ObjPos.yRotation = this.transform.rotation.y;
            ObjPos.zRotation = this.transform.rotation.z;
            PlayerPrefs.SetFloat(this.gameObject.name + "RotationX", ObjPos.x);
            PlayerPrefs.SetFloat(this.gameObject.name + "RotationY", ObjPos.y);
            PlayerPrefs.SetFloat(this.gameObject.name + "RotationZ", ObjPos.z);
            Debug.Log("Salvata Rotazione di: " + this.gameObject.name + " x=" + ObjPos.xRotation + " y=" + ObjPos.yRotation + " z=" + ObjPos.zRotation);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
             Debug.Log("Saved checkpoint at x: "+collision.transform.position.x+" y: "+ collision.transform.position.y +" z: "+collision.transform.position.z);
            SaveData();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
             Debug.Log("Walked throw a checkpoint at"+ other.transform.position.x + " y: " + other.transform.position.y + " z: " + other.transform.position.z);
            SaveData();
        }
    }
   /* #region 3rdPartyScript
    void FadeFromBlack()
    {
      //  blackScreen.color = Color.black;
        blackScreen.canvasRenderer.SetAlpha(1.0f);
         blackScreen.CrossFadeAlpha(0.0f, fadeOutTime, false);
    }
    #endregion*/
}
