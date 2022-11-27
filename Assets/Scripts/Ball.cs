using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteController))]
[RequireComponent(typeof(ParticleSystem))]

public class Ball : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private SpriteController _spriteController;

    private void OnEnable()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _spriteController = GetComponent<SpriteController>();
        Sprite sprite = _spriteController.ChangeSprite();
        _particleSystem.textureSheetAnimation.AddSprite(sprite);
    }
}
