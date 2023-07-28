using System;
using System.Collections;
using System.Collections.Generic;
using FlappyClone;
using Player;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    [SerializeField]
    private FloatReference groundSpeed = new FloatReference(67.5f);

    [SerializeField]
    private PlayerStateReference playerState = new PlayerStateReference(PlayerState.Idle);

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.I.GameState == GameState.GameOver) return;
        if (playerState.Value is PlayerState.Dead or PlayerState.Falling) return;
        
        _transform.Translate(Vector3.left * (groundSpeed.Value * Time.deltaTime));

        var spriteWidth = spriteRenderer.bounds.size.x;

        if (_transform.position.x < -spriteWidth / 2.0f)
        {
            _transform.position += Vector3.right * (spriteWidth * 2.0f);
        }
    }
}
