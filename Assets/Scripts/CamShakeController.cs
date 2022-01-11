using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class CamShakeController : MonoBehaviour
{
    public static CamShakeController Instance;

    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    
    private CinemachineBasicMultiChannelPerlin _camShake;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _camShake = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void CamShake()
    {
        DOTween.Kill("CamShake");
        DOTween.To(() => _camShake.m_AmplitudeGain, x => _camShake.m_AmplitudeGain = x, 
            2, 0.2f).SetId("CamShake").OnComplete(() =>
        {
            DOTween.To(() => _camShake.m_AmplitudeGain, x => _camShake.m_AmplitudeGain = x,
                0, 0.1f).SetId("CamShake");
        });
    }
}
