using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
        SceneManager.LoadScene("Level" + Mathf.Min(PlayerPrefs.GetInt("Level"), 2));
    }
}
