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
    Vector2 directionHoz;

    void Awake() => body = GetComponent<Rigidbody2D>();

    void Update() {
        Animate();

        // Debug.Logs go here so as not to slow down physics simulations??
    }

    void FixedUpdate() {
        // simulate gravity
        body.AddForce(GetGravityDirection() * gravityPull);
        Move();
        Rotate();
    }
    
    void Animate() {
        animator.SetInteger("random", Random.Range(1, 4));
        if (directionHoz.magnitude > 0) {
            animator.SetBool("isWalking", true);
        } else {
            animator.SetBool("isWalking", false);
        }
    }
    // InputSystem functions
    void OnMove(InputValue value) {
        directionHoz = value.Get<Vector2>();
    }

    // move rigidbody based on input
    void Move() {
        if (directionHoz.x > 0) {
            body.AddForce(new Vector2(1f, 0f) * walkingSpeed);
        } else {
            body.AddForce(new Vector2(-1f, 0f) * walkingSpeed);
        }
        
        // if (directionHoz.x > 0) {
        //     spriteRenderer.flipX = !spriteRenderer.flipX;
        // }
    }

    // rotate transform based on direction of planet
    void Rotate() {
        // how does this work?
        Vector2 gravityDirection = GetGravityDirection();
        float angle = 360 - (Mathf.Atan2(gravityDirection.x, gravityDirection.y) * Mathf.Rad2Deg * Mathf.Sign(gravityDirection.x));

        if (gravityDirection.x < 0) {
            transform.rotation = Quaternion.Euler(0f, 0f, -angle);
        } else {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
        }
    }

    Vector2 GetGravityDirection() {
        return (planet.position - transform.position);
    }
}