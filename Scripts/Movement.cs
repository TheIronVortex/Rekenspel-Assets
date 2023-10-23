using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] private KeyCode keyUp;
    [SerializeField] private KeyCode keyDown;
    [SerializeField] private KeyCode keyLeft;
    [SerializeField] private KeyCode keyRight;

    private Transform characterTransform;
    private Animator animator;

    void Start()
    {
        characterTransform = transform; // Get the Transform component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool moveUp = Input.GetKey(keyUp);
        bool moveDown = Input.GetKey(keyDown);
        bool moveLeft = Input.GetKey(keyLeft);
        bool moveRight = Input.GetKey(keyRight);

        // Check for input to move the object
        float horizontalInput = 0;
        float verticalInput = 0;

        if (moveUp)
        {
            verticalInput = moveSpeed;
        }
        else if (moveDown)
        {
            verticalInput = -moveSpeed;
        }

        if (moveRight)
        {
            horizontalInput = moveSpeed;
            characterTransform.localScale = new Vector3(1, 1, 1); // Set the scale to normal (no flip)
        }
        else if (moveLeft)
        {
            horizontalInput = -moveSpeed;
            characterTransform.localScale = new Vector3(-1, 1, 1); // Flip the character horizontally
        }

        // Set the velocity based on the input
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalInput, verticalInput);

        if (moveLeft || moveDown || moveRight)
        {
            //Idle animtion
            animator.SetBool("movement", true);
            if (moveUp)
            {
                animator.SetBool("moveUp", true);

            }

            else
            {
                animator.SetBool("moveUp", false);
            }

        }

        else if (moveUp)
        { 
            animator.SetBool("moveUp", true);
        }

        else 
        {
            animator.SetBool("movement", false);
            animator.SetBool("moveUp", false);

        }
    }
}
