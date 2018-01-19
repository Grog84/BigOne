using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

[CreateAssetMenu(menuName = "ParicleDB")]
[Serializable]
public class ParticleDB: ScriptableObject
{
    [BoxGroup("ParticleDB")]
    [TableMatrix(HorizontalTitle = "Texture", VerticalTitle = "State")]
    //public GameObject[,] LabledTable = new GameObject[15, 10];
    public GameObject[,] MyDB = new GameObject[10,3];
	
}
