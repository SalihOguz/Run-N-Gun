using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float time = 10f;
    
    void Start()
    {
        transform.DORotate(Vector3.up * 360f, time).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
    }
}
