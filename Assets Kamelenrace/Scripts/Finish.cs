using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private TMP_Text youWin;
    [SerializeField] private Collider2D finishLine;
    private bool isPlayerNear = false;



    // Update is called once per frame
    void Update()
    {
        if (isPlayerNear) 
        {
            youWin.text = "POGGIES";
        }
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("OH LAWD HE CLOSE");
            isPlayerNear = true;
        }
    }

}
