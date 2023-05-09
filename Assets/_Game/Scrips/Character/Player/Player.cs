using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character 
{
    [SerializeField] private float speed = 5;
   
    void Update()
    {
        if(GameManager.Ins.IsState(GameState.Gameplay))
        {

            if (Input.GetMouseButton(0))
            {
                Vector3 nextPoint = JoystickController.direct * speed * Time.deltaTime + transform.position;

                if (CanMove(nextPoint))
                {
                    transform.position = CheckGround(nextPoint);
                    //Debug.Log("di duoc ");
                }

                if (JoystickController.direct != Vector3.zero)
                {
                    skin.forward = JoystickController.direct;
                }

                ChangeAnim("run");
            }

            if (Input.GetMouseButtonUp(0))
            {
                ChangeAnim("idle");
            }
        }

    }

}
 