using UnityEngine;
using UnityEngine.SceneManagement;
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
    [Header("Animations Settings")]
    public Animator animator;
    [Header("Other Settings/Save Test")]
    public int emptyInt = 5;
    //UPDATE FUNCTION
    void Update()
    {
        MovementSwitch();
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            print("Saving...");
            SavePlayerData();
        }
        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            print("Loading...");
            LoadPlayerData();
        }

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
        if (collision.gameObject.tag == "NextScene")
        {
            FadeToLevel(1);
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
    //FADE FUNCTIONS
    #region FADE TO LEVEL FUNCTION
    public void FadeToLevel(int levelIndex)
    {
        animator.SetTrigger("FadeOut");
    }
    #endregion 
    #region ON FADE COMPLETE FUNCTION
    public void OnFadeComplete()
    {
        SceneManager.LoadScene("Testing Domain #5");
    }
    #endregion
    //SAVE FUNCTIONS
    public void SavePlayerData()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayerData()
    {
        Save data = SaveSystem.LoadPlayer();
        emptyInt = data.emptyIntData;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
