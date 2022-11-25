using System;
using UnityEngine;
using Random = System.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteController : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    
    private SpriteRenderer _spriteRenderer;
    private Random _random = new Random();
    
    public Sprite ChangeSprite()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        int index = _random.Next(0, _sprites.Length);
        _spriteRenderer.sprite = _sprites[index];

        return _sprites[index];
    }
}
