using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Level" + Mathf.Min(PlayerPrefs.GetInt("Level"), 2));
    }
}
