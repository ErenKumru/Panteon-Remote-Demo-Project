﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int GetLevel()
    {
        return SceneManager.GetActiveScene().buildIndex + 1;
    }

    //public void RestartLevel()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}
}
