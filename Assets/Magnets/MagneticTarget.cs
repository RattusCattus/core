using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagneticTarget : MonoBehaviour
{
    public float radius = 0.5f;

    void OnStartMagnet() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (Mathf.Sqrt(Mathf.Pow(mousePos.x - transform.position.x, 2) + Mathf.Pow(mousePos.y - transform.position.y, 2)) <= radius)
        {
            PlayerMagnet.isMagneting = true;
            PlayerMagnet.destination = new Vector2(transform.position.x, transform.position.y);
        }
    }
}