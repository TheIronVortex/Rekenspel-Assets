using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballCamera : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera filedCamera;
    private bool isPlayerNear = false;

    void Start()
    {
        mainCamera.enabled = true;
        filedCamera.enabled = false;
    }

    void Update()
    {
        if (isPlayerNear)
        {
            mainCamera.enabled = false;
            filedCamera.enabled = true;
        }
        else
        {
            mainCamera.enabled = true;
            filedCamera.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
