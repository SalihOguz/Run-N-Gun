using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstaclePooler : MonoBehaviour
{
    [SerializeField] private List<ObstacleParent> obstaclePoolList;
    [SerializeField] private Transform groundCollider;
    [SerializeField] private List<Transform> doorList;
    
    [SerializeField] private Transform player;
    [SerializeField] private Transform finish;
    
    private List<ObstacleParent> _obstacleUsedList;
    private int _levelLength;
    private int _currentLength;
    private int _doorIndex;

    private void Start()
    {
        _obstacleUsedList = new List<ObstacleParent>();
        _levelLength = 150 + PlayerPrefs.GetInt("Level") * 20;

        groundCollider.localScale = new Vector3(1,1,(_levelLength / 5) + 10);
        
        for (int i = 0; i < 5; i++)
        {
            PoolNewObstacle();
        }
    }

    private void Update()
    {
        if (_obstacleUsedList[0].transform.position.z <= player.position.z - 30)
        {
            Pool();
        }
    }
    
    private void Pool()
    {
        if (_currentLength >= _levelLength)
        {
            return;
        }
        
        RemoveOldObstacle(0);
        PoolNewObstacle();
    }

    private void RemoveOldObstacle(int index)
    {
        ObstacleParent oldObstacleParent = _obstacleUsedList[index];
        oldObstacleParent.gameObject.SetActive(false);
        oldObstacleParent.ResetObstacles();
        obstaclePoolList.Add(oldObstacleParent);
        _obstacleUsedList.RemoveAt(index);
    }

    private void PoolNewObstacle()
    {
        int rnd = Random.Range(0, obstaclePoolList.Count);
        ObstacleParent newObstacleParent = obstaclePoolList[rnd];
        obstaclePoolList.RemoveAt(rnd);
        _obstacleUsedList.Add(newObstacleParent);
        _currentLength += Random.Range(15, 20);
        newObstacleParent.transform.position =  Vector3.forward * _currentLength;
        newObstacleParent.gameObject.SetActive(true);
        
        if (_currentLength >= _levelLength)
        {
            finish.transform.position = Vector3.forward * (30f + _currentLength) + Vector3.right * -2.5f;
            finish.gameObject.SetActive(true);
            enabled = false;
        }
        // else if (_currentLength >= _levelLength / 3f)
        // {
        //     _currentLength += Random.Range(10, 15);
        //     doorList[_doorIndex].transform.position = Vector3.forward * _currentLength;
        //     doorList[_doorIndex].gameObject.SetActive(true);
        //     _doorIndex++;
        // }
    }
}