using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public Transform planet;
    
    public float gravityPull;
    public float jumpForce;
    public float walkingSpeed;

    // private vars
    Rigidbody2D body;
    Vector2 directionHoz;

    void Awake() => body = GetComponent<Rigidbody2D>();

    void FixedUpdate() {
        // simulate gravity
        body.AddForce(getGravityDirection() * gravityPull);

        Move();
    }

    // InputSystem functions
    void OnMove(InputValue value) => directionHoz = value.Get<Vector2>();
    void OnJump() => body.AddForce(-1 * getGravityDirection() * jumpForce);

    // homemade
    void Move() {
        body.AddForce(directionHoz * walkingSpeed);
        // make horizontal
    }

    Vector2 getGravityDirection() {
        return (planet.position - transform.position);
    }
}