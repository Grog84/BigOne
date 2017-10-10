﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/AIActions/LoadPatrolStats")]
public class LoadPatrolStats : _Action
{

    public override void Execute(EnemiesAIStateController controller)
    {
        LoadPatrolParams(controller);
    }

    private void LoadPatrolParams(EnemiesAIStateController controller)
    {
        controller.m_AgentController.loadStats("patrol");
    }
}
