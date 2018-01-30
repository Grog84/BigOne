using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerOnCheckPoint:MonoBehaviour
{
    public SaveManager Save;
    public Text Testo;



    private void Awake()
    {
        Save = FindObjectOfType<SaveManager>();
        Text[] temp = FindObjectsOfType<Text>();
        foreach(Text a in temp)
        {
            if(a.gameObject.name=="UI_Load")
            {
                Testo = a;

                Testo.gameObject.SetActive(false);

            }

        }
    }

    //private void OnTriggerEnter(Collider collision)
    //{
    //    if(collision.gameObject.name=="Boy"||collision.gameObject.name== "Mother")
    //    {
    //        Save.Save();
    //        Testo.gameObject.SetActive(true);
    //        StartCoroutine(SavingStuff());
    //    }
    //}
    //IEnumerator SavingStuff()
    //{
    //    for (int i = 0; i == 4; i++)
    //    {
    //        switch (Testo.text)
    //        {
    //            case "Saving": Testo.text += "."; yield return new WaitForSeconds(0.2f); break;

    //            case "Saving.": Testo.text += "."; yield return new WaitForSeconds(0.2f); break;
    //            case "Saving..": Testo.text += "."; yield return new WaitForSeconds(0.2f); break;

    //            case "Saving...": Testo.text = "Saving"; Testo.gameObject.SetActive(false); yield return new WaitForSeconds(0.2f); break;

    //        }
    //    }
    //    yield return null;
    //}
}
