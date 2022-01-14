using System;
using UnityEngine;

public class Obstacle : ObstacleBase
{
    [SerializeField] private Rigidbody rigidbody;

    private void Start()
    {
        base.Init();
    }

    protected override void OnBulletCollide(Collider other)
    {
        Vector3 pos = other.transform.position;
        rigidbody.AddForceAtPosition((Vector3.up + (transform.position - pos).normalized) * 200f, other.transform.position);
    }

    public override void ResetObstacle()
    {
        base.ResetObstacle();
        rigidbody.velocity = Vector3.zero;
    }
}
