using UnityEngine;
using UnityEngine.InputSystem;

public class ShipBehavior : MonoBehaviour
{
    public Rigidbody2D body;    
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public float flightSpeed;
    public float rotationSpeed;

    Vector2 direction;

    void FixedUpdate() => MoveAndRotate();
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
}