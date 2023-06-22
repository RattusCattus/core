using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    public Rigidbody2D body;
    public static bool isFlying;

    [SerializeField] float flightSpeed;
    [SerializeField] float rotationSpeed;
    Vector2 direction;
    Animator animator;
    GameObject headlight;
    CinemachineVirtualCamera cinemachine;

    void Awake() {
        animator = GetComponent<Animator>();
        headlight = transform.GetChild(0).gameObject;
        isFlying = false;
    }

    void Start() {
        transform.position = GameManager.planets[GameManager.currentPlanet];
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
            isFlying = true;
            if (direction.x < 0) {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, (GetAngle(direction) * -1)), Time.deltaTime * rotationSpeed);
            } else {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, GetAngle(direction)), Time.deltaTime * rotationSpeed);
            }
        } else {
            isFlying = false;
        }
    }

    void AnimateAndZoom() {
        if (direction.magnitude > 0) {
            animator.SetBool("isFlying", true);
        } else {
            animator.SetBool("isFlying", false);
        }

        if (Planet.inRange) {
            ZoomCamera(25);
            ChangeSpeed(8);
        } else {
            ZoomCamera(32);
            ChangeSpeed(15);
        }
    }

    void OnMove(InputValue value) => direction = value.Get<Vector2>();

    void ChangeSpeed(float value) => flightSpeed = Mathf.Lerp(flightSpeed, value, 10f * Time.deltaTime);

    float GetAngle(Vector2 vector2) => 360 - (Mathf.Atan2(vector2.x, vector2.y) * Mathf.Rad2Deg * Mathf.Sign(vector2.x));

    void ZoomCamera(float value) {
        if (!cinemachine) {
            cinemachine = Camera.main.GetComponentInChildren<CinemachineVirtualCamera>(); 
        }
        cinemachine.m_Lens.OrthographicSize = Mathf.Lerp(cinemachine.m_Lens.OrthographicSize, value, 2f * Time.deltaTime);
    }
}