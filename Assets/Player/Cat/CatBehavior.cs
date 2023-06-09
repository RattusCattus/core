using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CatBehavior : MonoBehaviour
{
    public float gravityPull;
    public float walkingSpeed;

    // private vars
    Rigidbody2D body;
    Vector2 inputVector;
    SpriteRenderer spriteRenderer;
    Animator animator;

    [SerializeField]
    Transform planet;

    CinemachineVirtualCamera cinemachine;

    void Awake() {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        cinemachine = Camera.main.GetComponentInChildren<CinemachineVirtualCamera>();
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
            animator.SetBool("isWalking", true);
        } else {
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

    // When cat spawns on planet, set planet and reset camera target.
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Planet") {
            planet = collider.gameObject.transform;
            cinemachine.Follow = transform;
            cinemachine.AddCinemachineComponent<CinemachineSameAsFollowTarget>();
            Debug.Log("You're on " + collider.gameObject.name + "!");
        }
    }

    void Gravitate() => body.AddForce((planet.position - transform.position) * gravityPull);
}