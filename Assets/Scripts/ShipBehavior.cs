using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ShipBehavior : MonoBehaviour
{
    public Rigidbody2D body;    
    public SpriteRenderer spriteRenderer;

    public float flightSpeed;
    public float rotationSpeed;
    public float frameRate;

    Vector2 direction;

    void Awake() => body = GetComponent<Rigidbody2D>();

    void FixedUpdate() => MoveAndRotate();

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

    void OnMove(InputValue value) => direction = value.Get<Vector2>();

    float getAngle(Vector2 vector2) {
        return 360 - (Mathf.Atan2(vector2.x, vector2.y) * Mathf.Rad2Deg * Mathf.Sign(vector2.x));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Earf") {
            SceneManager.LoadScene("planet1");
        }
    }
}