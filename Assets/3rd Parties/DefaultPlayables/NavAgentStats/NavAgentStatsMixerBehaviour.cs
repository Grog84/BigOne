using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.AI;

public class NavAgentStatsMixerBehaviour : PlayableBehaviour
{
    float m_DefaultSpeed;
    float m_DefaultAcceleration;
    float m_DefaultAngularSpeed;

    NavMeshAgent m_TrackBinding;
    bool m_FirstFrameHappened;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        m_TrackBinding = playerData as NavMeshAgent;

        if (m_TrackBinding == null)
            return;

        if (!m_FirstFrameHappened)
        {
            m_DefaultSpeed = m_TrackBinding.speed;
            m_DefaultAcceleration = m_TrackBinding.acceleration;
            m_DefaultAngularSpeed = m_TrackBinding.angularSpeed;
            m_FirstFrameHappened = true;
        }

        int inputCount = playable.GetInputCount ();

        float blendedSpeed = 0f;
        float blendedAcceleration = 0f;
        float blendedAngularSpeed = 0f;
        float totalWeight = 0f;
        float greatestWeight = 0f;
        int currentInputs = 0;

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<NavAgentStatsBehaviour> inputPlayable = (ScriptPlayable<NavAgentStatsBehaviour>)playable.GetInput(i);
            NavAgentStatsBehaviour input = inputPlayable.GetBehaviour ();
            
            blendedSpeed += input.speed * inputWeight;
            blendedAcceleration += input.acceleration * inputWeight;
            blendedAngularSpeed += input.angularSpeed * inputWeight;
            totalWeight += inputWeight;

            if (inputWeight > greatestWeight)
            {
                greatestWeight = inputWeight;
            }

            if (!Mathf.Approximately (inputWeight, 0f))
                currentInputs++;
        }

        m_TrackBinding.speed = blendedSpeed + m_DefaultSpeed * (1f - totalWeight);
        m_TrackBinding.acceleration = blendedAcceleration + m_DefaultAcceleration * (1f - totalWeight);
        m_TrackBinding.angularSpeed = blendedAngularSpeed + m_DefaultAngularSpeed * (1f - totalWeight);
    }

    public override void OnGraphStop (Playable playable)
    {
        m_FirstFrameHappened = false;

        if (m_TrackBinding == null)
            return;

        m_TrackBinding.speed = m_DefaultSpeed;
        m_TrackBinding.acceleration = m_DefaultAcceleration;
        m_TrackBinding.angularSpeed = m_DefaultAngularSpeed;
    }
}
