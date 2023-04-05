using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ColorObject
{
    //[SerializeField] Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask stairLayer;
    [SerializeField] private Transform skin;

    //Brick
    private List<PlayerBrick> playerBricks = new List<PlayerBrick>();
    [SerializeField] private PlayerBrick playerBrickPreFabs;
    [SerializeField] private Transform brickHolder;

    public Stage stage;
    

    void Start()
    {
       ChangeColor(ColorType.Red);
    }  
 
    // Update is called once per frame 
    void Update()
    {
        if(Input.GetMouseButton(0))
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
            return hit.point + Vector3.up * 1f;
        }

        return transform.position;
    }


    public bool CanMove(Vector3 nextPoint)
    {
        //check mau stair
        //khong cung mau -> fill
        //het gach + khong cung mau + huong di len 

        bool isCanMove = true;
        RaycastHit hit;

        if (Physics.Raycast(nextPoint, Vector3.down, out hit, 2f, stairLayer))
        {
            Stair stair = hit.collider.GetComponent<Stair>();

            if (stair.colorType != colorType && playerBricks.Count > 0)
            {
                stair.ChangeColor(colorType);
                RemoveBrick();
                Debug.Log("da doi mau ");
            }

            if (stair.colorType != colorType && playerBricks.Count == 0 && skin.forward.z > 0)
            {
                isCanMove = false;
                Debug.Log("Khong doi mauuuuuuu");
            }
        }

        return isCanMove;
    }


    //Brick

    public void AddBrick()
    {
        PlayerBrick playerBrick = Instantiate(playerBrickPreFabs, brickHolder);
        playerBrick.ChangeColor(colorType);
        playerBrick.transform.localPosition = Vector3.up * 1f * playerBricks.Count;
        playerBricks.Add(playerBrick);
    }

    public void RemoveBrick() 
    {
        if (playerBricks.Count > 0)
        {
            PlayerBrick playerBrick = playerBricks[playerBricks.Count - 1];
            playerBricks.RemoveAt(playerBricks.Count - 1);
            Destroy(playerBrick.gameObject);
        }
    }

    public void ClearBrick()
    {
        for (int i = 0; i < playerBricks.Count; i++)
        {
            Destroy(playerBricks[i]);
        }

        playerBricks.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brick"))
        {
            Brick brick = other.GetComponent<Brick>();

            if (brick.colorType == colorType)
            {
                Destroy(brick.gameObject);
                AddBrick();
            }
        }
    }
}
 