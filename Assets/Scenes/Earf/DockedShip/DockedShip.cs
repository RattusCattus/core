using UnityEngine;

public class DockedShip : MonoBehaviour
{
    GameObject highlight;
    float radius;

    void Awake() {
        highlight = transform.GetChild(0).gameObject;
        radius = GetComponent<CircleCollider2D>().radius;
    }

    void Update() {
        // check if cat is inRange and if touched
        if (Input.touchCount > 0 && !Cat.isWalking) {
            Touch touch = Input.GetTouch(0);
            if ((Camera.main.ScreenToWorldPoint(touch.position) - transform.position).magnitude < radius + 2) {
                Debug.Log("hi");
                GameManager.gameManager.Load("Space");
            }
        }

        // check if ship is inRange and if touch
        // if (inRange && Input.touchCount > 0 && !Ship.isFlying) {
        //     Touch touch = Input.GetTouch(0);
            
        //     if ((Camera.main.ScreenToWorldPoint(touch.position) - transform.position).magnitude < radius) {
        //         GameManager.Load(planetName);
        //     } 
        // }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            highlight.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            highlight.SetActive(false);
        }
    }
}
