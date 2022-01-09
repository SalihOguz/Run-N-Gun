using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Start()
    {
        transform.DORotate(Vector3.up * 360f, 10f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
    }
}
