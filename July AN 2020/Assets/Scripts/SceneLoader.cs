using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /*
    public void LaunchARScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void LaunchVRScene()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
    */
    public void LaunchScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);
    }
}
