using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayOneShotAudio : MonoBehaviour
{
    [SerializeField, Required]
    private AudioClip audioClip;

    [SerializeField, Required]
    private AudioSource audioSource;

    public void Play()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
