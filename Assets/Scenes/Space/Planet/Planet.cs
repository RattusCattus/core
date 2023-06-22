using UnityEngine;

public class Planet : MonoBehaviour
{
    public static bool inRange;   
    GameObject highlight;
    string planetName;
    float radius;
    
    void Awake() {
        highlight = transform.GetChild(0).gameObject;
        planetName = gameObject.name;
        radius = GetComponent<CircleCollider2D>().radius;
    }

    void Update() {
        // check if ship is inRange and if touch
        if (inRange && Input.touchCount > 0 && !Ship.isFlying) {
            Touch touch = Input.GetTouch(0);
            
            if ((Camera.main.ScreenToWorldPoint(touch.position) - transform.position).magnitude < radius) {
                GameManager.gameManager.Load(planetName);
                inRange = false;
            } 
        }
    }
    
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Ship") {
            GameManager.currentPlanet = gameObject.name;
            highlight.SetActive(true);
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Ship") {
            highlight.SetActive(false);
            inRange = false;
        }
    }
}
