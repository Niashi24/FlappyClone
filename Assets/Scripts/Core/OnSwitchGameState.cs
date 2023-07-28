using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using FlappyClone;
using UnityEngine;
using UnityEngine.Events;

public class OnSwitchGameState : MonoBehaviour
{
    [SerializeField]
    private UnityEvent unityEvent;

    [SerializeField]
    private GameState gameStateTrigger;

    private void OnEnable()
    {
        GameManager.OnChangeGameState.Subscribe(TriggerAsync);
    }

    private void OnDisable()
    {
        GameManager.OnChangeGameState.Unsubscribe(TriggerAsync);
    }

    private UniTask TriggerAsync(GameState gameState)
    {
        Trigger(gameState);
        return UniTask.CompletedTask;
    }

    public void Trigger(GameState gameState)
    {
        if (gameState != gameStateTrigger) return;
        
        unityEvent?.Invoke();
    }
}
