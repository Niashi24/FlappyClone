using System;
using System.Collections;
using System.Collections.Generic;
using FiniteStateMachine;
using Player;
using Sirenix.OdinInspector;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class UpdateValueOfState : MonoBehaviour
{
    [SerializeField, Required]
    private PlayerStateMachine stateMachine;

    [SerializeField, Required]
    private PlayerStateVariable playerStateVariable;

    private void OnEnable()
    {
        stateMachine.OnStateChange += UpdateVariable;
    }

    private void OnDisable()
    {
        stateMachine.OnStateChange -= UpdateVariable;
    }

    private void UpdateVariable(PlayerState newState)
    {
        playerStateVariable.Value = newState;
    }
}
