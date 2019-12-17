using UnityEngine;
public class Player : MonoBehaviour
{
    #region VARAIBLES
    [Header("Movement Settings")]
    public float moveSpeed = 5.0f;
    public float jumpSpeed = 5.0f;
    public float fallMultiplier = 5.0f;
    public float lowJumpMultiplier = 2.5f;
    [ReadOnly] public bool grounded;
    [ReadOnly] public bool doubleJump;
    [ReadOnly] public int jumpCount;
    Rigidbody2D playerRigidbody;
    #endregion
    //UNITY FUNCTIONS
    #region START FUNCTION
    void Start()
    {
        //SET JUMP VARIABLES
        playerRigidbody = GetComponent<Rigidbody2D>();
        doubleJump = false;
    }
    #endregion
    #region UPDATE FUNCTION
    void Update()
    {
        //RUN MOVEMENT
        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = 7;
        else
            moveSpeed = 5;
        float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveSpeed * moveX;
        GetComponent<Rigidbody2D>().velocity = velocity;
        //DOUBLE JUMP AND NORMAL JUMP
        if (Input.GetButtonDown("Jump") && doubleJump == false && grounded == true)
            Jump();
        else if (Input.GetButtonDown("Jump") && jumpCount < 2 && doubleJump == true)
            Jump();
        if (playerRigidbody.velocity.y < 0)
            playerRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (playerRigidbody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            playerRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }
    #endregion
    #region ON TRIGGER ENTER 2D FUNCTION
    void OnTriggerEnter2D(Collider2D collision)
    {
        //JUMPING
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            jumpCount = 0;
        }
    }
    #endregion
    #region ON TRIGGER STAY 2D FUNCTION
    void OnTriggerStay2D(Collider2D collision)
    {
        //JUMPING
        if (collision.gameObject.layer == 0)
        {
            grounded = true;
            jumpCount = 0;
        }
    }
    #endregion
    #region ON TRIGGER EXIT 2D FUNCTION
    void OnTriggerExit2D(Collider2D collision)
    {
        //JUMPING
        grounded &= collision.gameObject.layer != 0;
    }
    #endregion
    //PLAYER FUNCTIONS
    #region JUMP FUNCTION
    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpSpeed;
        //DOUBLE JUMP
        if (doubleJump == true)
        {
            if (!grounded)
                jumpCount++;
            jumpCount++;
        }
    }
    #endregion
}
