using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject tapToPlay;
    [SerializeField] private GameObject dragTut;
    
    [SerializeField] private WeaponControlller weaponControlller;
    
    private bool _isPlaying;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (_isPlaying) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        _isPlaying = true;
        tapToPlay.SetActive(false);
        dragTut.SetActive(false);
        weaponControlller.SetWeaponActive(0);
    }
}
