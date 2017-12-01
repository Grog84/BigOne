using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.BT;

public class TestBTDM : MonoBehaviour {

    public BehaviourTreeDM m_Tree;

    BTDMStringConverter converter = new BTDMStringConverter();

    private void Start()
    {
        converter.m_Tree = m_Tree;
        converter.WriteTree();
    }

}
