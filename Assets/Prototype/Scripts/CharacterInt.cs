using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using StateMachine;

public class CharacterInt : MonoBehaviour {

    public _CharacterController m_CharController;
    public CharacterStateController m_CharStateController;

    public void DefeatPlayer()
    {
        m_CharController.isDefeated = true;
    }

    public void RevivePlayer()
    {
        m_CharController.m_Animator.SetFloat("Forward", 0f);
        m_CharStateController.TransitionToState(m_CharStateController.gameStartState);
    }

    private IEnumerator PlayerDefeatSequence()
    {
        m_CharController.isDefeated = false;
        yield return StartCoroutine(GMController.instance.WaitAndRestart());
    }

    private void Update()
    {
        if (m_CharController.isDefeated)
        {
            StartCoroutine(PlayerDefeatSequence());
        }
    }
}
