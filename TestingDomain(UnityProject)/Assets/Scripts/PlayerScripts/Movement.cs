using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{
    //VARIABLES                             //VARIABLES
    [Header("General Settings")]            //GENERAL VARIABLES
    public float moveSpeed = 10;            //Speed in which the player moves
    bool grounded = false;                  //Tells whether the player is grounded
    [Header("Movement Settings")]           //MOVEMENT BOOL VARIABLES
    public bool TopDown = false;            //Top Down Movement
    public bool Platformer = false;         //Platformer Movement
    public bool TrueTopDown = false;        //True Top Down Movement
    [Header("Jump Settings")]               //SPEED VARIABLES
    public float jumpSpeed = 1;             //Speed in which the player jumps
    public int jumpCount = 0;               //How many jumps you've down while in air
    public int maxJumps = 2;                //How many jumps the player can do in the air
    //UPDATE FUNCTION
    void Update()
    {
        MovementSwitch();
        //TOP DOWN MOVEMENT
        if (TopDown == true)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector2 moveDir = new Vector2(x, y);
            GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
        }
        //PLATFORMER MOVEMENT
        if (Platformer == true)
        {
            if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
                Jump();
            float moveX = Input.GetAxis("Horizontal");
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.x = moveSpeed * moveX;
            GetComponent<Rigidbody2D>().velocity = velocity;
        }
        //TRUE TOP DOWN MOVEMENT
        if (TrueTopDown == true)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = transform.position.z;
            transform.up = mousePosition - transform.position;
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            Vector2 moveDir = y * transform.up + x * transform.right;
            GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
        }
    }
    //TRIGGER(ENTER) FUNCTION
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(Platformer == true)
        {
            if (collision.gameObject.layer == 0)
            {
                grounded = true;
                jumpCount = 0;
            }
        }
    }
    //TRIGGER(STAY) FUNCTION
    void OnTriggerStay2D(Collider2D collision)
    {
        if(Platformer == true)
        {
            if (collision.gameObject.layer == 0)
            {
                grounded = true;
                jumpCount = 0;
            }
        }
    }
    //TRIGGER(EXIT) FUNCTION
    void OnTriggerExit2D(Collider2D collision)
    {
        if(Platformer == true)
        {
            if (collision.gameObject.layer == 0)
                grounded = false;
        }
    }
    //JUMP FUNCTION
    void Jump()
    {
        if (!grounded)
            jumpCount++;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
        jumpCount++;
    }
    //MOVEMENT SWITCH FUNCTION
    void MovementSwitch()
    {
        if(TopDown == true)
        {
            Platformer = false;
            TrueTopDown = false;
        }
        if(Platformer == true)
        {
            TopDown = false;
            TrueTopDown = false;
        }
        if(TrueTopDown == true)
        {
            TopDown = false;
            Platformer = false;
        }
    }
}
