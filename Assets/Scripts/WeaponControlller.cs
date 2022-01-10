using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponControlller : MonoBehaviour
{
    public UnityAction<bool> HasRifle;
    
    [SerializeField] private List<Weapon> weaponsList;

    private BulletPoolsController _bulletPoolsController;

    void Start()
    {
        _bulletPoolsController = FindObjectOfType<BulletPoolsController>();
        for (int i = 0; i < weaponsList.Count; i++)
        {
            weaponsList[i].OnShoot += OnShoot;
        }
    }

    private void OnShoot(Vector3 muzzlePos, BulletType bulletType)
    {
        _bulletPoolsController.Shoot(muzzlePos, bulletType);
    }

    public void SetWeaponActive(int id)
    {
        for (int i = 0; i < weaponsList.Count; i++)
        {
            weaponsList[i].gameObject.SetActive(id == i);
        }

        HasRifle?.Invoke(id == 2);
    }
}
