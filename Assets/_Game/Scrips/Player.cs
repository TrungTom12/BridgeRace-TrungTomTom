using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] private float speed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            rb.velocity = JoystickController.direct * speed + rb.velocity.y * Vector3.up ; 
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = Vector3.zero;
        }
    }
}
