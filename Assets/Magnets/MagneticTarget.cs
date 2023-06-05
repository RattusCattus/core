using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagneticTarget : MonoBehaviour
{
    void OnStartMagnet() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit hit;
        
        mousePos.z = 0;

        Debug.Log(Camera.main.transform.position);
        Debug.Log(mousePos);
        Debug.Log(mousePos - Camera.main.transform.position);
        
        Debug.Log(Physics.Raycast(Camera.main.transform.position, (mousePos - Camera.main.transform.position)/2));

        if (Physics.Raycast(Camera.main.transform.position, mousePos - Camera.main.transform.position, out hit))
        {
            Debug.Log("Hell yeah");
            if (hit.collider == GetComponent<Collider>()) 
            {
                Debug.Log(mousePos);
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