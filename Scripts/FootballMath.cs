using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class FootballMath : MonoBehaviour
{

    [SerializeField] private TextMesh mathQuestion;
    [SerializeField] private TextMesh awnserLeft;
    [SerializeField] private TextMesh awnserRight;

    private int randomNumber;
    private int result;
    private int operand1;
    private int operand2;
    private bool isAddition;
    private List<int> remainingResults = new List<int>();
    public char correctGoal;
    private int randomGoal;

    private void Start()
    {
        InitializeRemainingResults();
        GenerateEquation();
    }

    private void InitializeRemainingResults()
    {
        for (int i = 0; i <= 100; i++)
        {
            remainingResults.Add(i);
        }
        Shuffle(remainingResults);
    }


    public void GenerateEquation()
    {
        if (mathQuestion == null)
        {
            Debug.LogError("TMP Text component not assigned. Please assign a TMP Text component to the 'equationText' field in the Inspector.");
            return;
        }

        if (remainingResults.Count == 0)
        {
            Debug.LogWarning("All numbers from 0 to 100 have been used as answers. You can reset or handle this case as needed.");
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

        randomNumber = UnityEngine.Random.Range(1, 99);
        randomGoal = UnityEngine.Random.Range(0, 2);
    }
    public void Update()
    {
        if (result < 100 && result > 0)
        {
            
            if (randomGoal == 0) 
            {
                awnserLeft.text = Convert.ToString(result);
                awnserRight.text = Convert.ToString(randomNumber);
                correctGoal = 'L';
            }
            else
            {
                awnserRight.text = Convert.ToString(result);
                awnserLeft.text = Convert.ToString(randomNumber);
                correctGoal = 'R';

            }


            if (isAddition)
            {
                mathQuestion.text = $"{operand1} + {operand2} = ...";
            }
            else
            {
                mathQuestion.text = $"{operand1} - {operand2} = ...";
            }
        }
        else
        {
            GenerateEquation();
        }
    }

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

