using System;
using TMPro;
using UnityEngine;

public class BreakableObstacle : ObstacleBase
{
    [SerializeField] private MeshRenderer shell;
    [SerializeField] private int health;
    [SerializeField] private TextMeshPro healthText;
    [SerializeField] private Collider collider;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private Rigidbody rb;

    private int _initialHealth;
    private CamShakeController _camShakeController;
    
    private void Start()
    {
        base.Init();
        healthText.text = health.ToString();
        _initialHealth = health;
        _camShakeController = CamShakeController.Instance;
    }

    protected override void OnBulletCollide(Collider other)
    {
        health = Math.Max(health - 1, 0);
        healthText.text = health.ToString();

        if (health == 0)
        {
            healthText.gameObject.SetActive(false);
            shell.enabled = false;
            particle.Play();

            collider.enabled = false;
            _camShakeController.CamShake();
        }
    }

    public override void ResetObstacle()
    {
        base.ResetObstacle();
        health = _initialHealth;
        healthText.text = health.ToString();
        healthText.gameObject.SetActive(true);
        shell.enabled = true;
        collider.enabled = true;
        rb.velocity = Vector3.zero;
    }
}
