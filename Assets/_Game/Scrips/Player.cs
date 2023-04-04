using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private LayerMask groundLayer;
     
    void Start()
    {
        
    }  
 
    // Update is called once per frame 
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 nextPoint = JoystickController.direct * speed * Time.deltaTime + transform.position;
            transform.position = CheckGround(nextPoint);
            //rb.velocity = JoystickController.direct * speed + rb.velocity.y * Vector3.up ; 
        }

        //if (Input.GetMouseButtonUp(0))
        //{
        //    //rb.velocity = Vector3.zero;
        //}
    }

    //Chech diem tiep theo cos phai la ground khong
    //+ tra ve vi tri next do
    //- tra ve vi tri hien tai
    public Vector3 CheckGround(Vector3 nextPoint)
    {
        RaycastHit hit;
        if (Physics.Raycast(nextPoint,Vector3.down,out hit , 2f, groundLayer))
        {
            return hit.point + Vector3.up * 1.1f;
        }

        return transform.position;
    }
}
