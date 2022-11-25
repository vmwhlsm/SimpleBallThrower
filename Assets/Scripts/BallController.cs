using System;
using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Slingshot _slingshot;

    private readonly Dictionary<int, BallData> _dictionary = new();

    private IEnumerator RemoveAfter(int id, float seconds)
    {
        yield return new WaitForSeconds(seconds);

        var obj = _dictionary[id].Obj;
        Destroy(obj);
    }

    private void Start()
    {
        _slingshot.BallCreated += data =>
        {
            var id = data.Obj.GetInstanceID();
            _dictionary.Add(id, data);
        };

        _slingshot.BallThrown += (id, force) =>
        {
            var data = _dictionary[id];
            var dataRigidbody = data.Rigidbody;
            dataRigidbody.GetComponent<Collider2D>().enabled = true;
            dataRigidbody.isKinematic = false;
            dataRigidbody.AddForce(force);

            StartCoroutine(RemoveAfter(id, 5f));
        };
    }
}