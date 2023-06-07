using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    public static Vector2 destination;
    public static bool isMagneting = false;

    public float power = 1f;

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
            float angle = Vector2.Angle(transform.position, destination);
            Vector2 dir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

            float distance = Mathf.Sqrt(Mathf.Pow(dir.x - transform.position.x, 2) + Mathf.Pow(dir.y - transform.position.y, 2));

            Debug.Log(angle);
            Debug.Log(dir);
            rb.AddForce(dir * power/distance);
        }
    }

    void OnCancelMagnet()
    {
        isMagneting = false;
    }
}
