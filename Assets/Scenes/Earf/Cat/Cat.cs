using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Cat : MonoBehaviour
{
    public static bool zoomCamera = true;

    [SerializeField] float gravityPull;
    [SerializeField] float walkingSpeed;
    [SerializeField] Transform planet;
    Rigidbody2D body;
    Vector2 inputVector;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public static bool isWalking;

    void Awake() {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        zoomCamera = false;
    }

    void Update() {
        Animate();
        
        // Debug.Logs go here so as not to slow down physics simulations??
    }

    void FixedUpdate() {
        Gravitate();
        Move();
    }
    
    void Animate() {
        animator.SetInteger("random", Random.Range(1, 4));
        if (inputVector.magnitude > 0) {
            isWalking = true;
            animator.SetBool("isWalking", true);
        } else {
            isWalking = false;
            animator.SetBool("isWalking", false);
        }
    }

    void OnMove(InputValue value) => inputVector = value.Get<Vector2>();

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

    void Gravitate() => body.AddForce((planet.position - transform.position) * gravityPull);
}