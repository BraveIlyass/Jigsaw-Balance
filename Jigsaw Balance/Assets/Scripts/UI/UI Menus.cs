using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenus : MonoBehaviour
{
    [SerializeField] int levelScene;
    [SerializeField] int controlsScene;
     public void PlayGame()
    {
        SceneManager.LoadScene(levelScene);
    }

     public void Controls()
    {
        SceneManager.LoadScene(controlsScene);
    } 
     public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
