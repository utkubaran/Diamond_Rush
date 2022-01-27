using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPanel : MonoBehaviour
{
    public void OnPlayButtonPressed()
    {
        string filePath = DataManager.instace.FilePath;
        int nextSceneIndex = !System.IO.File.Exists(filePath) ? SceneManager.GetActiveScene().buildIndex + 1 : nextSceneIndex = DataManager.instace.Load().lastLevelIndex; 
        SceneManager.LoadScene(nextSceneIndex);
    }
}
