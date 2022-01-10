using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BreakableObstacle : MonoBehaviour
{
    [SerializeField] private MeshRenderer shell;
    [SerializeField] private List<Rigidbody> rigidbodyList;
    [SerializeField] private int health;
    [SerializeField] private TextMeshPro healthText;
    [SerializeField] private Collider collider;

    private void Start()
    {
        healthText.text = health.ToString();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Bullet"))
        {
            health = Math.Max(health - 1, 0);
            healthText.text = health.ToString();

            if (health == 0)
            {
                healthText.gameObject.SetActive(false);
                shell.enabled = false;
                Vector3 pos = other.transform.position;
                for (int i = 0; i < rigidbodyList.Count; i++)
                {
                    rigidbodyList[i].gameObject.SetActive(true);
                    rigidbodyList[i].AddForceAtPosition((Vector3.up + (transform.position - pos).normalized) * 200f, other.transform.position);
                }

                collider.enabled = false;
            }
        }
    }
}
