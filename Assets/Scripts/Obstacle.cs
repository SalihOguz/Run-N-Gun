using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Vector3 pos = other.transform.position;
            rigidbody.AddForceAtPosition((Vector3.up + (transform.position - pos).normalized) * 500f, other.transform.position);
        }
    }
}
