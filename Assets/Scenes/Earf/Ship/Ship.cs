using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Ship : MonoBehaviour
{
    public Rigidbody2D body;
    public Collider2D magnetCollider;
    public GameObject cat;

    [SerializeField]
    float flightSpeed;
    [SerializeField]
    float rotationSpeed;

    Vector2 direction;
    PlayerInput shipInput;
    SpriteRenderer spriteRenderer;
    Collider2D shipCollider;
    Animator animator;
    CinemachineVirtualCamera cinemachine;
    string planetName;
    GameObject highlight;
    GameObject headlight;

    void Awake() {
        shipCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        shipInput = GetComponent<PlayerInput>();
        cinemachine = Camera.main.GetComponentInChildren<CinemachineVirtualCamera>();
        highlight = transform.GetChild(0).gameObject;
        headlight = transform.GetChild(1).gameObject;
    }

    void FixedUpdate() {
        MoveAndRotate();
    }

    void Update() {
        AnimateAndZoom();
    }

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

    void AnimateAndZoom() {
        if (direction.magnitude > 0) {
            animator.SetBool("isFlying", true);
        } else {
            animator.SetBool("isFlying", false);
        }

        if (Planet.inRange) {
            CameraZoom(25);
            ChangeSpeed(8);
        } else if (!Planet.inRange && Cat.zoomCamera) {
            CameraZoom(32);
            ChangeSpeed(15);
        }
    }

    void OnMove(InputValue value) => direction = value.Get<Vector2>();

    float getAngle(Vector2 vector2) {
        return 360 - (Mathf.Atan2(vector2.x, vector2.y) * Mathf.Rad2Deg * Mathf.Sign(vector2.x));
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Asteroid") {
            highlight.SetActive(true);
            // change highlight color
        }

        if (collider.gameObject.tag == "Player") {
            highlight.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Planet") {
        }

        if (collider.gameObject.tag == "Player") {
            highlight.SetActive(false);
        }
    }

    void CameraZoom(float value) {
        cinemachine.m_Lens.OrthographicSize = Mathf.Lerp(cinemachine.m_Lens.OrthographicSize, value, 2f * Time.deltaTime);
    }

    void ChangeSpeed(float value) {
        flightSpeed = Mathf.Lerp(flightSpeed, value, 10f * Time.deltaTime);
    }
}