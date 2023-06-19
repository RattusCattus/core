using UnityEngine;

public class DockedShip : MonoBehaviour
{
    GameObject highlight;
    float radius;
    bool inRange;

    void Awake() {
        highlight = transform.GetChild(0).gameObject;
        radius = GetComponent<CircleCollider2D>().radius;
    }

    void Update() {
        // check if cat is inRange and if ship touched
        if (inRange && Input.touchCount > 0 && !Cat.isWalking) {
            Touch touch = Input.GetTouch(0);
            if ((Camera.main.ScreenToWorldPoint(touch.position) - transform.position).magnitude < (24)) {
                GameManager.gameManager.Load("Space");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            highlight.SetActive(true);
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            highlight.SetActive(false);
            inRange = false;
        }
    }
}
