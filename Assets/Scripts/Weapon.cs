using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    public UnityAction<Vector3, BulletType> OnShoot;
    
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private ParticleSystem muzzleParticle;
    [SerializeField] private float fireRate = 5f;
    [SerializeField] private int bulletPerBurst = 1;
    [SerializeField] private BulletType bulletType;

    private float _shootTimer;
    private bool _canShoot = true;

    private void Update()
    {
        if (!_canShoot)
        {
            return;
        }
        
        _shootTimer += Time.deltaTime;

        if (_shootTimer >= 1f / fireRate)
        {
            _shootTimer = 0;
            for (int i = 0; i < bulletPerBurst; i++)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        muzzleParticle.Play();
        Debug.Log(muzzlePoint.position.x + "Weapon");
        OnShoot?.Invoke(muzzlePoint.position, bulletType);
    }

    public void Stop()
    {
        _canShoot = false;
        rigidbody.isKinematic = false;
        rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }
}