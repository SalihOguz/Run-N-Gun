using System;
using UnityEngine;

public class ObstacleBase : MonoBehaviour
{
    private Vector3 _initialLocalPos;
    private Quaternion _initialLocalRotation;
    private Transform _transform;

    protected virtual void Init()
    {
        _transform = transform;
        _initialLocalPos = _transform.localPosition;
        _initialLocalRotation = _transform.localRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            OnBulletCollide(other);
        }
    }

    protected virtual void OnBulletCollide(Collider other)
    {
        
    }
    
    public virtual void ResetObstacle()
    {
        _transform.localPosition = _initialLocalPos;
        _transform.localRotation = _initialLocalRotation;
    }
}
