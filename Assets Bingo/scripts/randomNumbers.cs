using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class NumberGenerator : MonoBehaviour
{
    [SerializeField]
    private TMP_Text[] textObjects = new TMP_Text[24];

    [SerializeField]
    private EquationGenerator equationGenerator;

    private int[][] grid;

    private void Start()
    {
        grid = new int[5][];
        for (int i = 0; i < 5; i++)
        {
            grid[i] = new int[5];
        }

        GenerateUniqueNumbers();
    }

    private void GenerateUniqueNumbers()
    {
        HashSet<int> uniqueNumbers = new HashSet<int>();
        int minNumber = 1;
        int maxNumber = 99;

        while (uniqueNumbers.Count < textObjects.Length)
        {
            int randomNumber = Random.Range(minNumber, maxNumber + 1);
            if (!uniqueNumbers.Contains(randomNumber))
            {
                uniqueNumbers.Add(randomNumber);
            }
        }

        int index = 0;
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                grid[row][col] = uniqueNumbers.ElementAt(index);
                textObjects[index].text = grid[row][col].ToString();
                index++;
            }
        }

        CheckForWin();
    }

    private void CheckForWin()
    {
        // Check rows for 5 in a row
        for (int row = 0; row < 5; row++)
        {
            int count = 0;
            for (int col = 0; col < 5; col++)
            {
                if (grid[row][col] == 0)
                {
                    count = 0;
                }
                else
                {
                    count++;
                    if (count == 5)
                    {
                        // You've won!
                        equationGenerator.YouHaveWon();
                        return;
                    }
                }
            }
        }

        // Check columns for 5 in a row
        for (int col = 0; col < 5; col++)
        {
            int count = 0;
            for (int row = 0; row < 5; row++)
            {
                if (grid[row][col] == 0)
                {
                    count = 0;
                }
                else
                {
                    count++;
                    if (count == 5)
                    {
                        // You've won!
                        equationGenerator.YouHaveWon();
                        return;
                    }
                }
            }
        }

        // Check diagonals for 5 in a row
        int mainDiagonalCount = 0;
        int antiDiagonalCount = 0;

        for (int i = 0; i < 5; i++)
        {
            if (grid[i][i] == 0)
            {
                mainDiagonalCount = 0;
            }
            else
            {
                mainDiagonalCount++;
                if (mainDiagonalCount == 5)
                {
                    // You've won!
                    equationGenerator.YouHaveWon();
                    return;
                }
            }

            if (grid[i][4 - i] == 0)
            {
                antiDiagonalCount = 0;
            }
            else
            {
                antiDiagonalCount++;
                if (antiDiagonalCount == 5)
                {
                    // You've won!
                    equationGenerator.YouHaveWon();
                    return;
                }
            }
        }
    }
}
