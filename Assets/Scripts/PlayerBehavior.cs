using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public Transform planet;
    
    public float speed;
    public float gravityPull;
    public float jumpForce;
    public float walkingSpeed;

    public Animator anim;

    // private vars
    Rigidbody2D body;
    Vector2 directionHoz;

    void Awake() => body = GetComponent<Rigidbody2D>();

    void Update() {
        Animate();
    }

    void FixedUpdate() {
        // simulate gravity
        body.AddForce(getGravityDirection() * gravityPull);
        Move();
    }
    
    void Animate() {
        if (directionHoz.magnitude > 0) {
            if (directionHoz.x < 0) {
                transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            } else {
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            anim.SetBool("isWalking", true);
        } else {
            anim.SetBool("isWalking", false);
        }
    }
    // InputSystem functions
    void OnMove(InputValue value) {
        directionHoz = value.Get<Vector2>();
    }

    // void OnJump() => anim.SetBool("isWalking", false);
   
    // homemade
    void Move() {
        body.AddForce(directionHoz * walkingSpeed);
        // make horizontal
    }

    Vector2 getGravityDirection() {
        return (planet.position - transform.position);
    }
}