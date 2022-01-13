using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject tapToPlay;
    [SerializeField] private GameObject dragTut;
    [SerializeField] private GameObject successScreen;
    [SerializeField] private GameObject failScreen;
    [SerializeField] private TextMeshProUGUI levelText;
    
    [SerializeField] private WeaponControlller weaponControlller;
    
    private bool _isPlaying;
    private PlayerController _playerController;
    
    void Start()
    {
        levelText.text = "LEVEL " + (PlayerPrefs.GetInt("Level") + 1);
        _playerController = FindObjectOfType<PlayerController>();
        _playerController.OnDead += Lose;
        _playerController.OnWon += Won;
    }

    private void OnDestroy()
    {
        _playerController.OnDead -= Lose;
        _playerController.OnWon -= Won;
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
    
    public void Won()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        StartCoroutine(WonDelay());
    }

    private IEnumerator WonDelay()
    {
        yield return new WaitForSeconds(1.5f);
        successScreen.SetActive(true);
    }
    
    public void Lose()
    {
        StartCoroutine(LoseDelay());
    }

    private IEnumerator LoseDelay()
    {
        yield return new WaitForSeconds(1.5f);
        failScreen.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level" + Mathf.Min(PlayerPrefs.GetInt("Level"), 2));
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level" + Mathf.Min(PlayerPrefs.GetInt("Level"), 2));
    }
}
