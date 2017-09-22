using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Prototype/State")]
public class State : ScriptableObject {

    public AIAction[] actions;
    public Color sceneGizmosColor = Color.gray;

    // Every time we are calling this function we are evaluating all the actions and decisions connected to the state
    public void UpdateState(StateController controller)
    {
        DoActions(controller);
    }

    private void DoActions(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Execute(controller);
        }
    }
	
}
