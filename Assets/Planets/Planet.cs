using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField]
    List<Animator> animators;
    

    void Awake() {
        foreach (Animator animator in animators) { animator.enabled = false; }
    }

    // Planet only animates if player is in orbit
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Ship" || collider.gameObject.tag == "Player") {
            Debug.Log("You're orbiting " + gameObject.name + "!");
            foreach (Animator animator in animators) { animator.enabled = true; }
            // enable minimap
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Ship" || collider.gameObject.tag == "Player") {
            foreach (Animator animator in animators) { animator.enabled = false; }
            // disable minimap
        }
    }
}
