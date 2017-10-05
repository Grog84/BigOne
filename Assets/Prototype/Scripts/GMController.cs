using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMController : MonoBehaviour {


    public Animator FadeAnim;

    [HideInInspector] public static GMController instance = null;
    [HideInInspector] public Vector3 lastSeenPlayerPosition = new Vector3(1000f, 1000f, 1000f);

    private bool isGameActive = false;

    static Vector3 resetPlayerPosition = new Vector3(1000f, 1000f, 1000f);


    void Awake() 
    {
        //Singleton
        //Check if instance already exists
        if (instance == null)
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            Destroy(gameObject);
    }

    public void ResetPlayerLastSeenPosition()
    {
        lastSeenPlayerPosition = resetPlayerPosition;
    }

    public void ActivateGame()
    {
        isGameActive = true;
    }

    public void DeactivateGame()
    {
        isGameActive = false;
    }

}
