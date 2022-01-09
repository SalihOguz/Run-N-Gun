using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPooler : MonoBehaviour
{
    [SerializeField] private List<Transform> platformList;
    [SerializeField] private Transform player;
    [SerializeField] private float platformLength = 5f;

    private void Update()
    {
        if (platformList[0].position.z <= player.position.z - platformLength * 2)
        {
            Pool();
        }
    }

    private void Pool()
    {
        platformList[0].position = platformList[platformList.Count - 1].position + Vector3.forward * platformLength;

        Transform first = platformList[0];
        for (int i = 0; i < platformList.Count; i++)
        {
            if (i == platformList.Count - 1)
            {
                platformList[i] = first;
            }
            else
            {
                platformList[i] = platformList[i + 1];
            }
        }
    }
}
