using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private bool isPlayerNear = false;
    public KeyCode interactKey = KeyCode.E;
    public string sceneToLoad;
    public Renderer renderE;
    public Renderer renderBox;
    public Renderer renderText;

    private void Update()
    {
        if (isPlayerNear)
        {
            renderE.enabled = true;
            renderBox.enabled = true;
            renderText.enabled = true;

            if (Input.GetKeyDown(interactKey))
            {
                LoadScene();
            }
        }
        else
        {
            renderE.enabled = false;
            renderBox.enabled = false;
            renderText.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            // Display a prompt to inform the player how to interact with the door (e.g., "Press 'E' to enter").
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            // Remove the interaction prompt.
        }
    }

    private void LoadScene()
    {
        if (sceneToLoad != null)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}