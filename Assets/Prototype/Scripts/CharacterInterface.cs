using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using StateMachine;

public class CharacterInterface : MonoBehaviour {

    [HideInInspector] public _CharacterController m_CharController;
    [HideInInspector] public CharacterStateController m_CharStateController;

    bool defeatCoroutinePlaying = false;

    public void DefeatPlayer()
    {
        //Debug.Log("DefeatCharacter");
        m_CharController.m_Animator.SetBool("isDead", true); // dovrebbe esser lo stato
        m_CharController.isDefeated = true;
    }

    public void RevivePlayer()
    {
        //Debug.Log("RevivePlayer");
        m_CharController.m_Animator.SetFloat("Forward", 0f);
        m_CharStateController.TransitionToState(m_CharStateController.gameStartState);
        ResetAnimator();
    }

    public void ResetAnimator()
    {
        //Debug.Log("RESET");
       // m_CharController.m_Animator.SetBool("isDead", false);
        foreach (AnimatorControllerParameter parameter in m_CharController.m_Animator.parameters)
        {
            m_CharController.m_Animator.SetBool(parameter.name, false);
        }
    }

    private IEnumerator PlayerDefeatSequence()
    {
        //Debug.Log("Defeat Sequence");

        //yield return null;
        GMController.instance.isCharacterPlaying = CharacterActive.None;
        //while (GMController.instance.deathTimer <=  GMController.instance.fadeOutTime)
        //{
        //    GMController.instance.deathTimer += Time.deltaTime;
        //    yield return null;
        //}

        while (!GMController.instance.fadeOutFinished)
        {
            GMController.instance.deathTimer += Time.deltaTime;
            yield return null;
        }

        m_CharController.m_Animator.SetBool("isDead", false);
        yield return null;
        GMController.instance.deathTimer = 0;
        GMController.instance.fadeOutFinished = false;

        // Temporary checks given the current animator structure
        if (m_CharController.m_Animator.GetBool("isClimbing"))
        {
            m_CharController.m_Animator.SetBool("isClimbing", false);
        }
        if (m_CharController.m_Animator.GetBool("onBoard"))
        {
            m_CharController.m_Animator.SetBool("onBoard", false);
        }
        if (m_CharController.m_Animator.GetBool("onLedge"))
        {
            m_CharController.m_Animator.SetBool("onLedge", false);
        }
        if (m_CharController.m_Animator.GetBool("Crouch"))
        {
            m_CharController.m_Animator.SetBool("Crouch", false);
        }
        if (!m_CharController.m_Animator.GetBool("isWalking"))
        {
            m_CharController.m_Animator.SetBool("isWalking", true);
        }

        m_CharController.isDefeated = false;
        defeatCoroutinePlaying = false;
        //yield return StartCoroutine(GMController.instance.WaitAndRestart());
    }

    private void Awake()
    {
        m_CharController = GetComponent<_CharacterController>();
        m_CharStateController = GetComponent<CharacterStateController>();
    }

    private void Update()
    {
        if (m_CharController.isDefeated && !defeatCoroutinePlaying)
        {
            defeatCoroutinePlaying = true;
            StartCoroutine(PlayerDefeatSequence());
        }
    }
}
