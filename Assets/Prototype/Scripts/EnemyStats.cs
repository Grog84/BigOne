using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Prototype/Stats/Enemy")]
public class EnemyStats : ScriptableObject {

    // Steering
    public float speed = 3.0f;
    public float angularSpeed = 180f;
    public float acceleration = 10f;
    public float stoppingDistance = 2f;

}
