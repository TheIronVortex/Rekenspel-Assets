using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckPostiton : MonoBehaviour
{
    public Transform spriteTransform;
    public float xThreshold;
    public TMP_Text victoryText;

    void Update()
    {
        if (spriteTransform.position.x > xThreshold)
        {
            victoryText.text = "You win!!!";
        }
    }
}
