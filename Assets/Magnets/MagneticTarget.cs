using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagneticTarget : MonoBehaviour
{
    void OnStartMagnet(InputValue value) {
        Vector2 mousePos = value.Get<Vector2>();
        RaycastHit hit;

        Debug.Log(mousePos);
        
        if (Physics.Raycast(new Vector3(mousePos.x, mousePos.y, 1), new Vector3(0, -90, 0), out hit))
        {
            if (hit.collider == GetComponent<Collider>()) 
            {
                PlayerMagnet.isMagneting = true;
                PlayerMagnet.destination = new Vector2(transform.position.x, transform.position.y);
            }
        }
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                PlayerMagnet.destination = new Vector2(transform.position.x, transform.position.y);
                PlayerMagnet.isMagneting = true;
            }
        }
    }
}
*/