using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public string sceneToLoad = "WorldMap";
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
