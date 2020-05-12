using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    public void LoadNextScreen()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex+1;
        SceneManager.LoadScene(nextIndex);
    }
    public void LoadPrevScreen()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex -1;
        SceneManager.LoadScene(nextIndex);
    }
    public void Exit()

    {
        Application.Quit();
    }
}
