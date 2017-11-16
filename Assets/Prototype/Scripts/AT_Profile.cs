using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AT_Profile 
{
    public string idProfile;
    public bool[] completedLevel;
    public int currentLevelIndex;

    public AT_Profile(string _idProfile)
    {
        idProfile = _idProfile;

    }
}