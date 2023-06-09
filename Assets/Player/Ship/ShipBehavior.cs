using UnityEngine;
using UnityEngine.InputSystem;

public class ShipBehavior : MonoBehaviour
{
    public Rigidbody2D body;
    public Collider2D magnetCollider;
    public GameObject cat;

    public float flightSpeed;
    public float rotationSpeed;
    public static bool isDocked;

    Vector2 direction;
    PlayerInput shipInput;
    SpriteRenderer spriteRenderer;
    Collider2D shipCollider;
    Animator animator;

    void Awake() {
        shipCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        shipInput = GetComponent<PlayerInput>();
    }

    void FixedUpdate() {
        MoveAndRotate();
    }

    void Update() => Animate();

    void MoveAndRotate() {
        body.AddForce(direction * flightSpeed);

        if (direction.magnitude > 0) {
            if (direction.x < 0) {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, (getAngle(direction) * -1)), Time.deltaTime * rotationSpeed);
            } else {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, getAngle(direction)), Time.deltaTime * rotationSpeed);
            }
        }
    }

    void Animate() {
        if (direction.magnitude > 0) {
            animator.SetBool("isFlying", true);
        } else {
            animator.SetBool("isFlying", false);
        }
    }

    void OnMove(InputValue value) => direction = value.Get<Vector2>();

    float getAngle(Vector2 vector2) {
        return 360 - (Mathf.Atan2(vector2.x, vector2.y) * Mathf.Rad2Deg * Mathf.Sign(vector2.x));
    }

    // If ship collides with a magnet, dock.
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Dock") {
            isDocked = true;
            shipCollider.enabled = false;
            transform.rotation = collision.transform.rotation;
            this.enabled = false;
            animator.enabled = false;
            shipInput.enabled = false;

            Instantiate(cat, transform.position, collision.transform.rotation);
        }
    }
}