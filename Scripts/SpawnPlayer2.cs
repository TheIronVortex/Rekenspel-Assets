using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer2 : MonoBehaviour
{

    [SerializeField] private GameObject playerTwo;
    [SerializeField] private KeyCode spawnKey;
    [SerializeField] private GameObject playerOne;
      
    void Start()
    {
        playerTwo.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(spawnKey) && playerTwo.activeSelf == false) 
        {
            playerTwo.transform.position = playerOne.transform.position;
            playerTwo.SetActive(true);
        }
        else if (Input.GetKeyDown(spawnKey) && playerTwo.activeSelf == true) 
        {
            playerTwo.SetActive(false);
        }
    }
}
