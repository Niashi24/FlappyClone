using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using FlappyClone;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    [SerializeField]
    private Collider2D topCollider, bottomCollider, triggerCollider;

    private void Awake()
    {
        GameManager.OnChangeGameState.Subscribe(GameStateChanged);
    }

    private void OnDestroy()
    {
        GameManager.OnChangeGameState.Unsubscribe(GameStateChanged);
    }

    private UniTask GameStateChanged(GameState state)
    {
        bool enabled = state == GameState.Game;
        topCollider.enabled = enabled;
        bottomCollider.enabled = enabled;
        triggerCollider.enabled = enabled;
        
        return UniTask.CompletedTask;
    }
}
