using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BreakableObstacle : MonoBehaviour
{
    [SerializeField] private MeshRenderer shell;
    [SerializeField] private int health;
    [SerializeField] private TextMeshPro healthText;
    [SerializeField] private Collider collider;
    [SerializeField] private ParticleSystem particle;

    private int _initialHealth;
    
    private void Start()
    {
        healthText.text = health.ToString();
        _initialHealth = health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            health = Math.Max(health - 1, 0);
            healthText.text = health.ToString();

            if (health == 0)
            {
                healthText.gameObject.SetActive(false);
                shell.enabled = false;
                particle.Play();

                collider.enabled = false;
            }
        }
    }

    public void ResetObstacle(Vector3 pos)
    {
        health = _initialHealth;
        healthText.text = health.ToString();
        healthText.gameObject.SetActive(true);
        shell.enabled = true;
        collider.enabled = true;
        transform.position = pos;
    }
}
