using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavScript : MonoBehaviour
{
    public float waitTime = 0.1f;
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}