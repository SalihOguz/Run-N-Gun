using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BreakableObstaclePart : MonoBehaviour
{
    void OnEnable()
    {
        transform.DOScale(Vector3.zero, 2f).SetEase(Ease.InCirc).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
