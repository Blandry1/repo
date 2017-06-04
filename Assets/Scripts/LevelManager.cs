using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadByIndex(int sceneIndex)
    {
        Debug.Log("onto next scene");
        SceneManager.LoadScene(sceneIndex + 1);
        
    }
    public void LoadToStart(int sceneIndex)
    {
        Debug.Log("beginning scene");
        SceneManager.LoadScene(0);

    }

    public void QuitOnClick()
    {
        Debug.Log("I want to quit!");
        Application.Quit();
    }
   
}
