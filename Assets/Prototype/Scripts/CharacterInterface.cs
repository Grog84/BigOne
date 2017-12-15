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
        m_CharController.m_Animator.SetBool("isDead", true); // dovrebbe esser lo stato
        m_CharController.isDefeated = true;
    }

    public void RevivePlayer()
    {
        m_CharController.m_Animator.SetFloat("Forward", 0f);
        m_CharController.m_Animator.SetBool("isDead", false); // dovrebbe esser lo stato
        m_CharStateController.TransitionToState(m_CharStateController.gameStartState);
    }

    private IEnumerator PlayerDefeatSequence()
    {
        //yield return null;
        GMController.instance.isCharacterPlaying = CharacterActive.None;
        while (GMController.instance.deathTimer <= GMController.instance.deathAnimationTime)
        {
            GMController.instance.deathTimer += Time.deltaTime;
            yield return null;
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
