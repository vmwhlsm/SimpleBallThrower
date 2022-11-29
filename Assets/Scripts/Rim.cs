using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class Rim : MonoBehaviour
{
    private AudioSource _audioSource;
    public event UnityAction Goaled;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Goaled += _audioSource.Play;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball _))
        {
            Goaled?.Invoke();
        }
    }

    private void OnDestroy()
    {
        Goaled -= _audioSource.Play;
    }
}
