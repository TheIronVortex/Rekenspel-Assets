using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class NumberGenerator : MonoBehaviour
{
    [SerializeField]
    private TMP_Text[] textObjects = new TMP_Text[24]; // Change the type to TMP_Text

    private void Start()
    {
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
        foreach (var textObject in textObjects)
        {
            textObject.text = uniqueNumbers.ElementAt(index).ToString();
            index++;
        }
    }
}
