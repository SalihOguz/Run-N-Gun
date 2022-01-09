using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolsController : MonoBehaviour
{
    [SerializeField] private List<BulletPool> bulletPoolsList;

    public void Shoot(Vector3 muzzlePoint, BulletType bulletType)
    {
        bulletPoolsList[(int) bulletType].Shoot(muzzlePoint);
    }
}
