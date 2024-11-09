using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySceneScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("River");
    }
}
