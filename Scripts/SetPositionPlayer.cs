using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetPositionPlayer : MonoBehaviour
{
    public GameObject playerSprite;

    private string sceneToLoad; 

    private void Awake()
    {
        sceneToLoad = PlayerPrefs.GetString("PlayerPosition");
    }
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
        switch (sceneToLoad)
        {
            case "Menu":
                playerSprite.transform.position = new Vector3 (-0.5f,0.2f,-0.2f);
                break;
            case "Bingo":
                playerSprite.transform.position = new Vector3 (3.5f,0,-0.2f);
                break;
            case "Kamelenrace":
                playerSprite.transform.position = new Vector3 (5.2f,-1f,-0.2f);
                break;
            default: 
                playerSprite.transform.position = new Vector3 (0,0,-0.2f);
                Debug.Log("Cannot load scene:" + sceneToLoad);
                break;
        }
    }
}
