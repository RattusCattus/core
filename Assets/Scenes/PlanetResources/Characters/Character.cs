using UnityEngine;

public class Character : MonoBehaviour {
    Rigidbody2D body;
    GameObject highlight;

    void Awake() {
        highlight = transform.GetChild(0).gameObject;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            highlight.SetActive(true);
            Dialogue.dialogue.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            highlight.SetActive(false);
            Dialogue.dialogue.SetActive(false);
        }
    }
}
