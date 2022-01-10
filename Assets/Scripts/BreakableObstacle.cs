using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObstacle : MonoBehaviour
{
    [SerializeField] private MeshRenderer shell;
    [SerializeField] private List<Rigidbody> rigidbodyList;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Bullet"))
        {
            shell.enabled = false;
            Vector3 pos = other.transform.position;
            for (int i = 0; i < rigidbodyList.Count; i++)
            {
                rigidbodyList[i].gameObject.SetActive(true);
                rigidbodyList[i].AddForceAtPosition((Vector3.up + (transform.position - pos).normalized) * 200f, other.transform.position);
            }
        }
    }
}
