using System.Collections.Generic;
using UnityEngine;

public class Cookian : MonoBehaviour {
    [SerializeField] float rotationSpeed;
    [SerializeField] float gravityPull;
    [SerializeField] Transform planet;
    [SerializeField] float startSpeed;
    [SerializeField] List<Collider2D> collidersToIgnore;

    Rigidbody2D body;
    bool pushed = false;

    void Awake() {
        body = GetComponent<Rigidbody2D>();
        // ignore collisions with certain game objects
        foreach (Collider2D collider in collidersToIgnore) {
            Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), collider, true);
        }
    }

    void FixedUpdate() {
        if (!pushed) {
            body.AddForce(new Vector2(0f, startSpeed));
            pushed = true;
        }

        transform.Rotate(0f, 0f, rotationSpeed);
        Gravitate();
    }

    void Gravitate() => body.AddForce((planet.position - transform.position) * gravityPull);
}
