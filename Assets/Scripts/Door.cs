using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private List<Transform> doorEdges;
    [SerializeField] private List<int> weaponId;
    [SerializeField] private List<ParticleSystem> particle;
    [SerializeField] private List<GameObject> weaponList;

    private WeaponControlller _weaponControlller;
    
    void Start()
    {
        _weaponControlller = FindObjectOfType<WeaponControlller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Vector3.Distance(other.transform.position, doorEdges[0].position) <=
                Vector3.Distance(other.transform.position, doorEdges[1].position))
            {
                _weaponControlller.SetWeaponActive(weaponId[0]);
                particle[0].Play();
                weaponList[0].SetActive(false);
            }
            else
            {
                _weaponControlller.SetWeaponActive(weaponId[1]);
                particle[1].Play();
                weaponList[1].SetActive(false);
            }
    
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
