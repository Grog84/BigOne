using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using StateMachine;


public class CharacterInterface : MonoBehaviour {

    private _CharacterController m_CharacterController;
    private CharacterStateController m_CharacterStateController;

    public void RevivePlayer()
    {
        m_CharacterController.isDefeated = false;
        m_CharacterController.m_Animator.SetFloat("Forward", 0f);
        m_CharacterStateController.TransitionToState(m_CharacterStateController.gameStartState);
    }

    public void DefeatPlayer()
    {
        m_CharacterController.isDefeated = true;
        StartCoroutine(WaitAndRestart());
    }

    private IEnumerator WaitAndRestart()
    {
        yield return new WaitForSeconds(GMController.instance.deathAnimationTime);
        //FadeOut();
        yield return new WaitForSeconds(GMController.instance.fadeOutTime);
        RevivePlayer();
        //LoadCheckpoint();
        //FadeIn();

    }
}
