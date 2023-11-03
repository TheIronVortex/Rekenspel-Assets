using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingFrom : MonoBehaviour
{
    private string lastSceneName; // Variable to store the last scene name

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Store the last scene name when a new scene is loaded
        lastSceneName = scene.name;
        Debug.Log("Last Scene Name: " + lastSceneName);
    }
}