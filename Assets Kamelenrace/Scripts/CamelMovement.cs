using TMPro;
using UnityEngine;

public class CamelMovement : MonoBehaviour
{
    public TMP_InputField inputField;
    public float moveSpeed;
    public MathSystem mathSystem; // Reference to the MathSystem script

    public void Update()
    {
        if (mathSystem.movement)
        {
            // Move the sprite to the right by 5 units
            transform.Translate(Vector3.right * moveSpeed);
            Debug.Log("Moving Right");
            mathSystem.movement = false;
            Debug.Log(mathSystem.movement);
        }
        else
        {
            //  Debug.Log("vies vuil kut dingz");
        }
    }
}
