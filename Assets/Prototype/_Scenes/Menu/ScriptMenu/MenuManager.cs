using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public void GameStart()
    {
        SceneManager.LoadScene("FG_MappaP_01");
    }
}
