using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsEmitter : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string m_EventPath;

    [HideInInspector] public bool playStep = false;

    // FMOD Parameters
    [HideInInspector] float audioWalk = 1f;
    [HideInInspector] float audioRun;
    [HideInInspector] float audioCrouch;

    FootstepsParameters m_footstepsParameters;

    string lastFloorName = "None";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (playStep)
        {
            playStep = false;
            PlayFootstepSound();
        }

    }

    void PlayFootstepSound()
    {
        GetFloorComposition();

        if (m_EventPath != null)
        {
            FMOD.Studio.EventInstance e = FMODUnity.RuntimeManager.CreateInstance(m_EventPath);
            e.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));

            SetParameter(e, "Regular_Walk", audioWalk);
            SetParameter(e, "Regular_Run", audioRun);
            SetParameter(e, "Regular_Crouch", audioCrouch);
            SetParameter(e, "Dirt", m_footstepsParameters.Dirt);
            SetParameter(e, "HiCutEQ_Walks", m_footstepsParameters.HiCutEQ_Walks);
            SetParameter(e, "LowCutEQ_Walks", m_footstepsParameters.LowCutEQ_Walks);
            SetParameter(e, "ReverbLevel", m_footstepsParameters.ReverbLevel);
            SetParameter(e, "ReverbDiffusion", m_footstepsParameters.ReverbDiffusion);
            SetParameter(e, "ReverbTime", m_footstepsParameters.ReverbTime);

            e.start();
            e.release();//Release each event instance immediately, there are fire and forget, one-shot instances. 
        }
    }

    void GetFloorComposition()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1000.0f))
        {
            Floor thisFloor = hit.transform.GetComponent<Floor>();
            string thisFloorName = thisFloor.GetFloorName();
            if (lastFloorName != thisFloorName)
            {
                m_footstepsParameters = thisFloor.GetFloorParameters();
            }
        }

    }


    void SetParameter(FMOD.Studio.EventInstance e, string name, float value)
    {
        FMOD.Studio.ParameterInstance parameter;
        FMOD.RESULT getOk = e.getParameter(name, out parameter);
        if (getOk == FMOD.RESULT.ERR_INVALID_PARAM)
        {
            return;
        }
        parameter.setValue(value);
    }

    public void MakeStep()
    {
        playStep = true;
    }
}