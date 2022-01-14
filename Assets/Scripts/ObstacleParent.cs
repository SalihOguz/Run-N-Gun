using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleParent : MonoBehaviour
{
    [SerializeField] private List<ObstacleBase> obstacleList;

    public void ResetObstacles()
    {
        for (int i = 0; i < obstacleList.Count; i++)
        {
            obstacleList[i].ResetObstacle();
        }
    }
}