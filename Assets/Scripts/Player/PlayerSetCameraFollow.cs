using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Mirror;

public class PlayerSetCameraFollow : NetworkBehaviour
{
    [Header("Settings")]
    [SerializeField] private CinemachineFreeLook _FLC;
    private Transform _PlayerBody;

    private void Update()
    {
        _PlayerBody = FindObjectOfType<CharacterController>().transform;
        if(_FLC.Follow != null)
            return;
        //print("Cam");   
        
        if(_PlayerBody != null)
        {
            _FLC.Follow = _PlayerBody;
            _FLC.LookAt = _PlayerBody;
        }
    }
}
