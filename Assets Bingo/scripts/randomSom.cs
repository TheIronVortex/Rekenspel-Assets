using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using System.Runtime.CompilerServices;

public class EquationGenerator : MonoBehaviour
{
    public TMP_Text equationText;

    public int result;
    public int lastResult;

    public int operand1;
    public int operand2;
    public bool isAddition;

    private List<int> remainingResults = new();
    private List<int> seenResults = new();

    private float equationDisplayTime = 15f; // tijd om de volgende som te laten zien
    private float displayStartTime = 0f; // tijd sinds wanneer de som er is
    private bool youHaveWonFlag = false; // check de win, word nog niks mee gedaan

    public void SetYouHaveWonFlag()
    {
        youHaveWonFlag = true;
    }

    private void Start()
    {
        InitializeRemainingResults();
        GenerateEquation();
    }

    public void YouHaveWon()
    {
        if (equationText != null)
        {
            equationText.text = "You've won!";
        }
    }


    private void InitializeRemainingResults()
    {
        for (int i = 0; i <= 10; i++)
        {
            remainingResults.Add(i);
        }
        Shuffle(remainingResults);
    }

    public int GenerateEquation()
    {
        if (equationText == null)
        {
            Debug.LogError("TMP Text component not assigned.");
            return 0;
        }

        operand1 = UnityEngine.Random.Range(0, 100);
        operand2 = UnityEngine.Random.Range(0, 100);

        isAddition = UnityEngine.Random.Range(0, 2) == 0;

        result = isAddition ? operand1 + operand2 : operand1 - operand2;
        result = Mathf.Max(result, 0);
        return result;
    }

    private bool checkSeen(int res)
    {
        return seenResults.Contains(res);
    }

    private void addSeen(int res)
    {
        if (res < 100 && res > 0 && !checkSeen(res))
        {
            Debug.Log($"Adding {res}");
            seenResults.Add(res);
        }
    }

    private void logSeen()
    {
        foreach (int res in seenResults)
        {
            Debug.Log($"Res: {res}, Seen: {checkSeen(res)}");
        }
    }

    public void Update()
    {
        // Log all seen
        logSeen();

        if (Time.time - displayStartTime >= equationDisplayTime)
        {
            GenerateNewEquation();
        }

        // Stop updating if length 99
        if (seenResults.Count >= 99)
        {
            return;
        }

        if (result >= 100 || result <= 0 || (checkSeen(result) && lastResult != result))
        {
            GenerateNewEquation();
        }
        else if (checkSeen(result))
        {
            if (Time.time - displayStartTime < equationDisplayTime)
            {
                Debug.Log($"Showing {result} (last {lastResult}, length {seenResults.Count})");
                equationText.text = $"{operand1} {(isAddition ? '+' : '-')} {operand2} = {result}";
            }
        }


    }



    private void GenerateNewEquation()
    {
        int newResult = GenerateEquation();
        if (!checkSeen(newResult)) //  kijk of het niewe resultaat nier in de lijst staat
        {
            addSeen(newResult); //voeg result toe aan de lijst
            lastResult = newResult;
            displayStartTime = Time.time;
            result = newResult; //  update the resultaar
        }
        else
        {
            // maak niewe som todat hij nog niet bestaat
            GenerateNewEquation();
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