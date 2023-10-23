using UnityEngine;
using TMPro;

public class MathSystem : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text feedbackText;
    public TMP_Text questionText;

    private int num1;
    private int num2;
    public int correctAnswer;
    public string currentQuestion;
    public int parsedUserAnswer;
    public bool movement;
    private void Awake()
    {
        // Generate the initial question when the game starts
        GenerateQuestion();
        Debug.Log("awak");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CheckAnswer();
        }

        if (!inputField.isFocused)
        {
            inputField.Select();
        }
    }

    public void CheckAnswer()
    {
        Debug.Log("CheckAnswer called");
        string userAnswer = inputField.text;

        if (int.TryParse(userAnswer, out parsedUserAnswer))
        {
            if (parsedUserAnswer == correctAnswer)
            {
                movement = true;
                Debug.Log(movement);
                DisplayFeedback("Correct!", Color.green);
            }
            else
            {
                DisplayFeedback($"Incorrect. The correct answer is {correctAnswer}.", Color.red);
            }
        }
        else
        {
            DisplayFeedback("Please enter a valid number.", Color.red);
        }

        inputField.text = "";
        GenerateQuestion();
    }

/*    public bool IsAnswerCorrect(int userAnswer)
    {
        return userAnswer == correctAnswer;
    }*/

    private void GenerateQuestion()
    {
        Debug.Log("generate question");
        num1 = Random.Range(1, 10);
        num2 = Random.Range(1, 10);

        int operation = Random.Range(1, 4);

        switch (operation)
        {
            case 1:
                correctAnswer = num1 + num2;
                currentQuestion = $"{num1} + {num2} = ";
                break;
            case 2:
                correctAnswer = num1 - num2;
                currentQuestion = $"{num1} - {num2} = ";
                break;
            case 3:
                correctAnswer = num1 * num2;
                currentQuestion = $"{num1} * {num2} = ";
                break;
                // You can uncomment and implement case 4 for division if needed
        }

        questionText.text = currentQuestion;
        inputField.ActivateInputField();
        feedbackText.text = "";
    }

    private void DisplayFeedback(string message, Color color)
    {
        feedbackText.text = message;
        feedbackText.color = color;
    }
}
