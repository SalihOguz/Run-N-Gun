using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 16f;
    [SerializeField] private float spreadAngle = 0.5f;
    [SerializeField] private ParticleSystem explodeParticle;
    [SerializeField] private MeshRenderer sphere;
    
    private bool _isFlying;
    private float _flyTimer;
    private float _maxFlyTime = 10f;

    private void Start()
    {
    }

    public void Shoot(Vector3 startPos)
    {
        gameObject.SetActive(false);
        transform.position = startPos;
        transform.eulerAngles = Vector3.up * Random.Range(-spreadAngle, spreadAngle);
        sphere.enabled = true;
        gameObject.SetActive(true);
        _isFlying = true;
        _flyTimer = 0;
    }

    private void Update()
    {
        if (!_isFlying)
        {
            return;
        }

        _flyTimer += Time.deltaTime;
        if (_flyTimer >= _maxFlyTime)
        {
            ReturnBack();
            return;
        }
        
        transform.position += transform.forward * (Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            StartCoroutine(Explode());
        }
    }

    private void ReturnBack()
    {
        _isFlying = false;
        gameObject.SetActive(false);
    }

    private IEnumerator Explode()
    {
        _isFlying = false;
        sphere.enabled = false;
        explodeParticle.Play();
        
        yield return new WaitForSeconds(0.5f);

        if (!_isFlying)
        {
            gameObject.SetActive(false);
        }
    }
}
