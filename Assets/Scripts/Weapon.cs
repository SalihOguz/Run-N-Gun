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
    
    // [SerializeField] private Transform bulletParent;
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private float fireRate = 5f;
    [SerializeField] private int bulletPerBurst = 1;

    [SerializeField] private BulletType bulletType;
    
    // [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    // private CinemachineBasicMultiChannelPerlin _camShake;
    
    private float _shootTimer;
    
    void Start()
    {
        // _camShake = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
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
        OnShoot?.Invoke(muzzlePoint.position, bulletType);
    }


    // private void CamShake()
    // {
    //     DOTween.To(() => _camShake.m_AmplitudeGain, x => _camShake.m_AmplitudeGain = x, 
    //         1, 1f/(fireRate/2f)).OnComplete(() =>
    //     {
    //         DOTween.To(() => _camShake.m_AmplitudeGain, x => _camShake.m_AmplitudeGain = x,
    //             0, 1f/(fireRate/2f));
    //     });
    // }
}
