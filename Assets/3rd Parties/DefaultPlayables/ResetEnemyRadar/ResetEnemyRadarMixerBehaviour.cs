using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using AI;
using StateMachine;

public class ResetEnemyRadarMixerBehaviour : PlayableBehaviour
{
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {

        CharacterStateController trackBinding = playerData as CharacterStateController;

        if (!trackBinding)
            return;

        int inputCount = playable.GetInputCount ();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<ResetEnemyRadarBehaviour> inputPlayable = (ScriptPlayable<ResetEnemyRadarBehaviour>)playable.GetInput(i);
            ResetEnemyRadarBehaviour input = inputPlayable.GetBehaviour ();

            if(inputWeight > 0.5f && !input.radarReset)
            {
                GameObject enemyClose;
                enemyClose = trackBinding.m_CharacterController.CharacterTransform.Find("EnemyClose").gameObject;

                for (int j = 0; j < enemyClose.GetComponent<EnemyClose>().pointers.Count; j++)
                {
                    GameObject.Destroy(enemyClose.GetComponent<EnemyClose>().pointers[j]);
                }

                enemyClose.GetComponent<EnemyClose>().pointers.Clear();
                enemyClose.SetActive(false);
                input.radarReset = true;
            }

            // Use the above variables to process each frame of this playable.

        }
    }
}
