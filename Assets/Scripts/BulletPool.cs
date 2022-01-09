using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BulletPool
{
    public List<Bullet> BulletList;

    public void Shoot(Vector3 muzzlePoint)
    {
        Bullet bullet = BulletList[0];
        bullet.Shoot(muzzlePoint);
        BulletList.Remove(bullet);
        BulletList.Add(bullet);
    }
}
