using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/AIActions/CheckNavPoint")]
public class CheckNavPoint : _Action {

    public override void Execute(EnemiesAIStateController controller)
    {
        CheckPoint(controller);
    }

    private void CheckPoint(EnemiesAIStateController controller)
    {
        controller.m_AgentController.navPointTimer += Time.deltaTime;

        if(controller.m_AgentController.navPointTimer <= 2f)
        {
            float step = controller.m_AgentController.agentStats.angularSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(controller.m_AgentController.transform.forward, controller.m_AgentController.wayPointList[controller.m_AgentController.checkingWayPoint].facingDirection, step, 0.0f);
            controller.m_AgentController.transform.rotation = Quaternion.LookRotation(newDir);
        }
        else if (controller.m_AgentController.navPointTimer >= controller.m_AgentController.checkNavPointTime - 2f)
        {
            // start facing the next point of the navigation
            float step = controller.m_AgentController.agentStats.angularSpeed * Time.deltaTime;
            Vector3 targetDir = controller.m_AgentController.wayPointListTransform[controller.m_AgentController.nextWayPoint].position - controller.m_AgentController.transform.position;
            Vector3 newDir = Vector3.RotateTowards(controller.m_AgentController.transform.forward, targetDir, step, 0.0F);
            controller.m_AgentController.transform.rotation = Quaternion.LookRotation(newDir);

        }

        if (controller.m_AgentController.navPointTimer >= controller.m_AgentController.checkNavPointTime)
        {
            controller.m_AgentController.navPointTimer = 0;
            controller.m_AgentController.isCheckingNavPoint = false;
        }

    }
}
