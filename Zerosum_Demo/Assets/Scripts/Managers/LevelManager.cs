using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private float gameplayStartDelay = 2f;

    public static LevelManager instance;

    private int currentSceneIndex;
    public int CurrentSceneIndex { get { return currentSceneIndex; } }

    private void OnEnable()
    {
        EventManager.OnTapToplayButtonPressed.AddListener(StartGameplay);
        EventManager.OnNextLevelButtonPressed.AddListener(LoadNextScene);
    }

    private void OnDisable()
    {
        EventManager.OnTapToplayButtonPressed.RemoveListener(StartGameplay);
        EventManager.OnNextLevelButtonPressed.RemoveListener(LoadNextScene);
    }
    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        EventManager.OnSceneStart?.Invoke();
        instance = this;
    }
    
    private void StartGameplay()
    {
        EventManager.OnLevelStart?.Invoke();
    }

    private void LoadNextScene()
    {
        if (currentSceneIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
            return;
        }
        
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
