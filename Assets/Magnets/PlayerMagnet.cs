using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    public static Vector2 destination;
    public static bool isMagneting = false;

    public float power = 1f;
    public int mode = 1;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(destination);
        if (isMagneting)
        {
            //float angle = Mathf.Atan((destination.y - transform.position.y) / (destination.x - transform.position.x));
            //Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            //float angle = Vector2.SignedAngle(new Vector2(1, 0), destination - new Vector2(transform.position.x, transform.position.y));
            //Vector2 dir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

            // gets the angle as a vector
            Vector2 dir = destination - (Vector2)transform.position;
            dir.Normalize();

            // distance is used to reduce power
            float distance = Mathf.Sqrt(Mathf.Pow(dir.x - transform.position.x, 2) + Mathf.Pow(dir.y - transform.position.y, 2));

            Vector2 force = new Vector2();
            // doesn't add force if the character is already too fast
            if (Mathf.Abs(rb.velocity.x) < Mathf.Abs(power * dir.x))
            {
                force.x = dir.x;
            }
            if (Mathf.Abs(rb.velocity.y) < Mathf.Abs(power * dir.y))
            {
                force.y = dir.y;
            }

            rb.AddRelativeForce(force * power / Mathf.Pow(distance, mode));
        }
    }

    void OnCancelMagnet()
    {
        isMagneting = false;
    }
}