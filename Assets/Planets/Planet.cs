using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    
    public List<Animator> animators;
    public GameObject planet;
    public GameObject cat;
    public GameObject ship;

    void Awake() {
        foreach (Animator animator in animators) { animator.enabled = false; }
    }

    // Planet only animates if player is in orbit
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Ship") {
            Debug.Log("You're orbiting " + planet.name + "!");
            foreach (Animator animator in animators) { animator.enabled = true; }

            // Move to ShipBehavior
            Instantiate(cat, ship.transform.position, Quaternion.identity);
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Ship") {
            foreach (Animator animator in animators) { animator.enabled = false; }
        }
    }
}
