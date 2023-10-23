using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallBounce : MonoBehaviour
{

    Rigidbody2D rb;
    Vector3 lastVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
