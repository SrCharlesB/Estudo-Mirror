using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerSetup : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private List<Behaviour> _Components;

    private void Awake()
    {
        MouseLock.Lock(true);
    }

    public void OnEnablePlayer(bool state)
    {
        foreach(Behaviour component in _Components)
        {
            component.enabled = state;
        }
    }
}