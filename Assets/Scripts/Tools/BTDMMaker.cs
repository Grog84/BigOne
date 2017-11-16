using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.BT;

    public class BTDMMaker : MonoBehaviour {

    BehaviourTreeDM behaviourTree;
    List<GameObject> levels;
    List<GameObject> connections;

    void Start () {

        behaviourTree.AssignRootTask(levels[0].GetComponent<Task>());


    }

}
