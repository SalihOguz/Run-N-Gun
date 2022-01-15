using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CamShakeController : MonoBehaviour
{
    public static CamShakeController Instance;

    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private PostProcessVolume postProcessVolume;
    
    private CinemachineBasicMultiChannelPerlin _camShake;
    private Bloom _bloom;
    private ChromaticAberration _chromaticAberration;
    private Vignette _vignette;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _camShake = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        postProcessVolume.profile.TryGetSettings(out _bloom);
        postProcessVolume.profile.TryGetSettings(out _chromaticAberration);
        postProcessVolume.profile.TryGetSettings(out _vignette);
    }

    public void CamShake()
    {
        DOTween.Kill("CamShake");
        DOTween.To(() => _camShake.m_AmplitudeGain, x => _camShake.m_AmplitudeGain = x, 2, 0.2f).SetId("CamShake").OnComplete(() =>
        {
            DOTween.To(() => _camShake.m_AmplitudeGain, x => _camShake.m_AmplitudeGain = x, 0, 0.1f).SetId("CamShake");
        });

        DOTween.To(() => _bloom.intensity.value, x => _bloom.intensity.value = x, 4, 0.2f).SetId("CamShake").OnComplete(() =>
        {
            DOTween.To(() => _bloom.intensity.value, x => _bloom.intensity.value = x, 0, 0.1f).SetId("CamShake");
        });
        
        DOTween.To(() => _chromaticAberration.intensity.value, x => _chromaticAberration.intensity.value = x, 1, 0.2f).SetId("CamShake").OnComplete(() =>
        {
            DOTween.To(() => _chromaticAberration.intensity.value, x => _chromaticAberration.intensity.value = x, 0, 0.1f).SetId("CamShake");
        });
        
        DOTween.To(() => _vignette.intensity.value, x => _vignette.intensity.value = x, 0.4f, 0.2f).SetId("CamShake").OnComplete(() =>
        {
            DOTween.To(() => _vignette.intensity.value, x => _vignette.intensity.value = x, 0, 0.1f).SetId("CamShake");
        });

    }
}
