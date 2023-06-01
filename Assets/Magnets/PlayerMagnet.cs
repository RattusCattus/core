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
            rb.AddForce(new Vector2(power/(destination.x - transform.position.x), power/(destination.y - transform.position.y)));
        }
    }
}
