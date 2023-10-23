using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer2 : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private KeyCode spawnKey;
      
    void Start()
    {
        player.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(spawnKey) && player.activeSelf == false) 
        {
            player.SetActive(true);
        }
        else if (Input.GetKeyDown(spawnKey) && player.activeSelf == true) 
        {
            player.SetActive(false);
        }
    }
}
