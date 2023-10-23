using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class EquationGenerator : MonoBehaviour
{
    public TMP_Text equationText;

    public int result;

    public int operand1;

    public int operand2;

    public bool isAddition;

    private List<int> remainingResults = new List<int>();

    private void Start()
    {
        InitializeRemainingResults();
        InvokeRepeating("GenerateEquation", 0f, 10f);
    }

    private void InitializeRemainingResults()
    {
        for (int i = 0; i <= 1000; i++)
        {
            remainingResults.Add(i);
        }
        Shuffle(remainingResults);
    }


    public void GenerateEquation()
    {
        if (equationText == null)
        {
            Debug.LogError("TMP Text component not assigned. Please assign a TMP Text component to the 'equationText' field in the Inspector.");
            return;
        }

        // Pop the next result from the shuffled list
        result = remainingResults[0];
        remainingResults.RemoveAt(0);

        operand1 = UnityEngine.Random.Range(0, 100);
        operand2 = UnityEngine.Random.Range(0, 100);

        // Determine whether to generate an addition or subtraction equation
        isAddition = UnityEngine.Random.Range(0, 2) == 0;

        if (isAddition)
        {
            result = operand1 + operand2;
        }
        else
        {
            result = operand1 - operand2;
            // Ensure result doesn't go below 0
            result = Mathf.Max(result, 0);
        }
    }


    public void Update()
    {
        if (result < 100 && result > 0)
        {
            if (isAddition)
            {
                equationText.text = $"{operand1} + {operand2} = ...";
            }
            else
            {
                equationText.text = $"{operand1} - {operand2} = ...";
            }
        }
        else
        {
            GenerateEquation();
        }
    }

    // Fisher-Yates shuffle algorithm to shuffle the list
    private void Shuffle(List<int> list)
    {
        int n = list.Count;
        for (int i = 0; i < n; i++)
        {
            int r = i + UnityEngine.Random.Range(0, n - i);
            int temp = list[i];
            list[i] = list[r];
            list[r] = temp;
        }
    }
}
