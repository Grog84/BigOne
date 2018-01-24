using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NpcState { Random = 0, Normal = 1, Happy = 2, Sad = 3, Texting = 4, Injured = 5, CarryingObject = 6 }

public class CasualNpcAnimator : MonoBehaviour
{
    [HideInInspector] public Animator anim;
    public NpcState currentState;
    public GameObject crate;
    public GameObject smartphone;

    void Awake()
    {
        anim = GetComponent<Animator>();

        StartCoroutine(ChangeStance(currentState));

    }


    public IEnumerator ChangeStance(NpcState state)
    {
        anim.SetBool("IsSwitching", true);
        yield return new WaitForSeconds(0.1f);

        if ((state == NpcState.Random))
        {
            anim.SetInteger("Stance", Random.Range(1, 7));
            currentState = (NpcState)anim.GetInteger("Stance");
        }
        else
        {

            anim.SetInteger("Stance", (int)state);
            currentState = (NpcState)anim.GetInteger("Stance");
        }

        if (currentState == NpcState.CarryingObject)
        {
            crate.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            crate.GetComponent<MeshRenderer>().enabled = false;
        }

        if (currentState == NpcState.Texting)
        {
            smartphone.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            smartphone.GetComponent<MeshRenderer>().enabled = false;
        }

        yield return new WaitForSeconds(0.1f);
        anim.SetBool("IsSwitching", false);
    }
}
