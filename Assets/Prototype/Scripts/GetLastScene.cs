using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetLastScene : MonoBehaviour {
    private Text LastScene;

    public void Start()
    {
        LastScene = this.gameObject.GetComponent<Text>();
   
        string lastScene= SaveGame.SaveObjComponent.GetLastScene();
        LastScene.text = lastScene;
    }
}
