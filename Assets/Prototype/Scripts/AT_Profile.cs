using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/ProfileStats")]
public class AT_Profile : ScriptableObject
{
    public string idProfile;
    [SerializeField] public bool[] completedLevel;
    public int currentLevelIndex;
 
}