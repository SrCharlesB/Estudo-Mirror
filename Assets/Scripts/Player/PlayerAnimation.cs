using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerAnimation : CharacterAnimation
{
    [Header("Settings")]
    [SerializeField] private PlayerController _PlayerController;
    [SerializeField] private CharacterMovementAnimationsKeys _Keys;
    private void Update()
    {
        _NetAnimator.animator.SetBool(_Keys.Move, _PlayerController.GetMove());
        _NetAnimator.animator.SetBool(_Keys.Running, _PlayerController.GetRunning());
    }
}
