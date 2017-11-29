using StateMachine;
using System;
using UnityEngine;


[Serializable]
public class ActorData
{
    //public int indexSave;

    //public DateTime dateTime;

    public string name;

    public Vector3 pos;

    public Quaternion rot;

    [HideInInspector] public int isDoorOpen;

    [HideInInspector] public EnemiesAIStateController m_Controller;

    [HideInInspector] public GuardStates activeState;
}
