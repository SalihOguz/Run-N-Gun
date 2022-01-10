using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Bullet"))
        {
            Vector3 pos = other.transform.position;
            rigidbody.AddForceAtPosition((Vector3.up + (transform.position - pos).normalized) * 200f, other.transform.position);
        }
    }
}
