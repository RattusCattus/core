using UnityEngine;
using UnityEngine.InputSystem;

public class CatBehavior : MonoBehaviour
{
    public Transform planet;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    
    public float gravityPull;
    public float walkingSpeed;

    // private vars
    Rigidbody2D body;
    Vector2 inputVector;

    void Awake() => body = GetComponent<Rigidbody2D>();

    void Update() {
        Animate();
        
        // Debug.Logs go here so as not to slow down physics simulations??
        Debug.Log(inputVector.x);
    }

    void FixedUpdate() {
        Gravitate();
        Move();
    }
    
    void Animate() {
        animator.SetInteger("random", Random.Range(1, 4));
        if (inputVector.magnitude > 0) {
            animator.SetBool("isWalking", true);
        } else {
            animator.SetBool("isWalking", false);
        }
    }
    // InputSystem functions
    void OnMove(InputValue value) {
        inputVector = value.Get<Vector2>();
    }

    //homemade

    void Move() {
        if (inputVector.x > 0) {
            planet.Rotate(0f, 0f, (inputVector.x * walkingSpeed));   
        } else if (inputVector.x < 0) {
            planet.Rotate(0f, 0f, (inputVector.x * walkingSpeed));
        }
        
        // flip sprite based on direction of travel
        if (inputVector.x < 0) {
            spriteRenderer.flipX = true;
        } if (inputVector.x > 0) {
            spriteRenderer.flipX = false;
        }
    }

    void Gravitate() {
        body.AddForce((planet.position - transform.position) * gravityPull);
    }
}