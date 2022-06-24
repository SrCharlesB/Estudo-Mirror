using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform _CameraPivot;
    [SerializeField] private CharacterController _Controller;
    [SerializeField] private PlayerData _Data;

    //Internal
    private Vector3 _Move;
    private float _Speed => _Data.WalkSpeed;
    private bool _isRunning;
    private bool _isMove;

    private void Awake()
    {
        _CameraPivot = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {
        if(!isLocalPlayer)
            return;
        if(_CameraPivot == null)
            return;
        Move();
        Gravity();
        print("PlayerController.Update()");
    }

    private void Move()
    {
        float speedMove = _Data.WalkSpeed;
        Vector3 inputs = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if(inputs.magnitude < 0.1f)
            return;

        float targetAngle = Mathf.Atan2(inputs.x, inputs.y) * Mathf.Rad2Deg + _CameraPivot.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _Data.TurnSmoothVelocity, _Data.TurnSmoothTime);

        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        _Controller.Move(moveDirection.normalized * (Time.deltaTime * _Data.WalkSpeed));

        _isRunning = Input.GetButton("Run") && inputs.z > 0;
        _isMove = inputs.magnitude > 0.5f;
        print(inputs.magnitude); 
        //_Controller.Move(inputs);
        //print($"Run: {_isRunning}, Move: {inputs.magnitude}");
    }

    private void Gravity()
    {
        Vector3 gravity = new Vector3(0f, -(_Data.GravityForce * Time.deltaTime), 0f);
        _Controller.Move(gravity);
    }

    public bool GetMove()
    {
        bool move = _isMove; 
        return move;
    }

    public bool GetRunning()
    {
        bool running = _isRunning;
        return running;
    }
}
