using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.sceneCountInBuildSettings -1 < currentSceneIndex +1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
