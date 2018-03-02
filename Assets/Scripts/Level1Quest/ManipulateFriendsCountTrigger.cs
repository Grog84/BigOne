using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateFriendsCountTrigger : MonoBehaviour {

    bool triggered;
    Level1Quest level1quest;

    private void Start()
    {
        level1quest = FindObjectOfType<Level1Quest>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && triggered == false)
        {
            triggered = true;
            level1quest.friendsSaved++;
        }
    }
}
