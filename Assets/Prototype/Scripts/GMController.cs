using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMController : MonoBehaviour {


    public Animator FadeAnim;

    [HideInInspector] public static GMController instance = null;
    [HideInInspector] public Vector3 lastSeenPlayerPosition = new Vector3(1000f, 1000f, 1000f);
    [HideInInspector] public bool isFadeScreenVisible = true;
    [HideInInspector] public Transform[] allEnemiesTransform;

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

        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        allEnemiesTransform = new Transform[allEnemies.Length];
        for (int i = 0; i < allEnemiesTransform.Length; i++)
        {
            allEnemiesTransform[i] = allEnemies[i].transform;
        }
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

    public bool GetGameStatus()
    {
        return isGameActive;
    }

    public void FadeIn()
    {
        FadeAnim.SetBool("Fade", false);
        StartCoroutine(WaitAndActivate());
        isFadeScreenVisible = false;

    }

    private IEnumerator WaitAndActivate()
    {
        yield return new WaitForSeconds(1f);
        ActivateGame();
    }

    public void FadeOut()
    {
        FadeAnim.SetBool("Fade", true);
        StartCoroutine(WaitAndDeactivate());
        isFadeScreenVisible = true;

    }

    private IEnumerator WaitAndDeactivate()
    {
        yield return new WaitForSeconds(1f);
        DeactivateGame();
    }
}
