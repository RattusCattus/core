using UnityEngine;
using UnityEngine.InputSystem;

public class CatBehavior : MonoBehaviour
{
    public Transform planet;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    
    public float gravityPull;
    public float walkingSpeed;
    public float rotationSpeed;

    // private vars
    Rigidbody2D body;
    Vector2 inputDirection;

    void Awake() => body = GetComponent<Rigidbody2D>();

    void Update() {
        Animate();

        // Debug.Logs go here so as not to slow down physics simulations??

        Debug.Log(GetRotation()-180);
    }

    void FixedUpdate() {
        // simulate gravity
        body.AddForce(GetGravityDirection() * gravityPull);
        Move();
        Rotate();
    }
    
    void Animate() {
        animator.SetInteger("random", Random.Range(1, 4));
        if (inputDirection.magnitude > 0) {
            animator.SetBool("isWalking", true);
        } else {
            animator.SetBool("isWalking", false);
        }
    }
    // InputSystem functions
    void OnMove(InputValue value) {
        inputDirection = value.Get<Vector2>();
    }

    // OnTap

    // move rigidbody based on input
    void Move() {
        //float angle = GetRotation() - 180;
        if (inputDirection.x > 0) {
            // addforce perpendicular to the direction of gravity
            body.AddForce(Vector2.Perpendicular(GetGravityDirection()*walkingSpeed));
        } else if (inputDirection.x < 0){
            body.AddForce(Vector2.Perpendicular(GetGravityDirection()* -walkingSpeed));
        } else {
            // stop the body when not moving??
            body.velocity = GetGravityDirection() * gravityPull;
        }
        
        // flip sprite based on direction of travel
        if (inputDirection.x > 0) {
            spriteRenderer.flipX = true;
        } else {
            spriteRenderer.flipX = false;
        }
    }

    // rotate transform based on direction of planet
    void Rotate() {
        float angle = GetRotation();
        if (GetGravityDirection().x < 0) {
            transform.rotation = Quaternion.Euler(0f, 0f, -angle);
        } else {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
        }
    }

    float GetRotation() {
        // how does this work?
        Vector2 gravityDirection = GetGravityDirection();
        return 360 - (Mathf.Atan2(gravityDirection.x, gravityDirection.y) * Mathf.Rad2Deg * Mathf.Sign(gravityDirection.x));
    }

    Vector2 GetGravityDirection() {
        return (planet.position - transform.position);
    }
}