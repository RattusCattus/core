using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gravity : MonoBehaviour
{
    public Rigidbody2D body;
    public Transform planet;
    
    public float gravityPull;

    void Awake() => body = GetComponent<Rigidbody2D>();

    void FixedUpdate() => body.AddForce(getDirection());

    Vector2 getDirection() {
        return (planet.position - transform.position) * gravityPull;
    }
}