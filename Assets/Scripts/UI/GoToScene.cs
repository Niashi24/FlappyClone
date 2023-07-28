using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using FlappyClone;
using UnityEngine;

public class GoToScene : MonoBehaviour
{
    [SerializeField]
    private AppState newAppState = AppState.Game;

    [SerializeField]
    private string newScene = "Game Scene";

    public void Go()
    {
        GameManager.I.ChangeAppState(newAppState).Forget();
        GameManager.I.LoadScene(newScene).Forget();
    }
}
