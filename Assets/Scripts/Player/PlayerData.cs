using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    public float WalkSpeed = 2.7f;
    public float RunSpeed = 5f;
    public float GravityForce = 9.8f;
    public float TurnSmoothTime = 0.1f;
    public float TurnSmoothVelocity;
}
