using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public Score scoreLeft;
    public Score scoreRight;
    [SerializeField] private TextMesh pointCounter;
    [HideInInspector] public int point;

    private void Start()
    {
        point = 0;
    }

    void Update()
    {
        pointCounter.text = Convert.ToString(point);
    }
}
