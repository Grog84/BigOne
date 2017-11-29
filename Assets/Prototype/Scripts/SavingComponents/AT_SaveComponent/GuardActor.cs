using UnityEngine;
using StateMachine;
public class GuardActor : Actor
{
    


    public override void Awake()
    {
        base.Awake();
        data.m_Controller = GetComponent<EnemiesAIStateController>();
    }
    public override void StoreData()
    {
        base.StoreData();
       
    }


    public override void LoadData()
    {
        base.LoadData();

    //    data.m_Controller.m_AgentController.hasHeardPlayer = false;
    //    data.m_Controller.m_AgentController.hasSeenPlayer = false;

    ////    data.m_Controller.m_AgentController.m_Animator.SetFloat("Forward", 0f);

       
    //    switch (data.activeState)
    //    {
    //        case GuardStates.Patrol:
    //            data.m_Controller.TransitionToState(data.m_Controller.patrolState);
              
    //            break;
    //        case GuardStates.CheckPosition:
              
    //            data.m_Controller.TransitionToState(data.m_Controller.checkNavPoint);
    //            break;
    //        case GuardStates.Inactive:
    //            data.m_Controller.TransitionToState(data.m_Controller.inactiveState);
    //            break;
    //        default:
    //            break;
    //    }

    }
    public override void ApplyData()
    {
        //data.activeState = data.m_Controller.saveState;
      

SaveData.addActorData(data);
    }

    private void OnEnable()
    {
        SaveData.OnLoaded += LoadData;
        SaveData.OnBeforeSave += StoreData;
        SaveData.OnBeforeSave += ApplyData;
    }
    private void OnDisable()
    {

        SaveData.OnLoaded -= LoadData;
        SaveData.OnBeforeSave -= StoreData;
        SaveData.OnBeforeSave -= ApplyData;
    }
}
