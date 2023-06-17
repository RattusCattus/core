using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{
    public static bool inRange;   
    GameObject highlight;
    string planetName;
    
    void Awake() {
        highlight = transform.GetChild(0).gameObject;
        planetName = gameObject.name;
    }

    void Update() {
        // if (inRange && planetClicked) {
        //     SceneManager.LoadScene(planetName);
        // }
    }
    
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Ship") {
            Debug.Log("You're orbiting " + gameObject.name + "!");
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
