using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renderCircle : MonoBehaviour
{
    public Renderer renderRondje;

    public void onClick()
    {
        if (renderRondje.enabled == false)
        {
            renderRondje.enabled = true;
        }
        else
        {
            renderRondje.enabled = false;
        }
        
    }
}
