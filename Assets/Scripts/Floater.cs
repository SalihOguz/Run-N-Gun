using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Floater : MonoBehaviour
{
    void Start()
    {
        transform.DOMove(transform.position + Vector3.up * 0.15f, 2f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetDelay(Random.Range(0, 2f));
    }
}
