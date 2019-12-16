using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    #region VARIABLES
    [Header("General Settings")]         
    public float moveSpeed = 10;         
    bool grounded = false;
    [Header("Hitpoint Settings")]       
    public int health = 5;                
    public int lives = 3;           
    [Header("Movement Settings")]        
    public bool TopDown = false;         
    public bool Platformer = false;        
    public bool TrueTopDown = false;       
    [Header("Jump Settings")]              
    public float jumpSpeed = 1;
    public int jumpCount = 0;
    public int maxJumps = 2;
    [Header("Shoot Settings")]
    public GameObject prefab;
    public float bulletSpeed = 10.0f;
    public float bulletLifetime = 1.0f;
    public float shootDelay = 1.0f;
    float timer = 0;
    [Header("Animations Settings")]
    public Animator animator;
    [Header("Other Settings/Save Test")]
    public int emptyInt = 5;
    #endregion
    //UNITY FUNCTIONS
    #region UPDATE FUNCTION
    void Update()
    {
        //HITPOINTS
        if (health < 1)
        {
            if (lives < 0)
                SceneManager.LoadScene("GameOver");
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //MOVEMENT
        MovementSwitch();
        if (TopDown == true)
            TopDownMovement();
        else if (TrueTopDown == true)
            TrueTopDownMovement();
        else if (Platformer == true)
            PlatformerMovement();
        else
            TopDownMovement();
        //SHOOTING
        Shoot();
        //ANIMATION
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        GetComponent<Animator>().SetFloat("x", x);
        GetComponent<Animator>().SetFloat("y", y);
        //SAVING
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
    }
    #endregion
    #region ON TRIGGER ENTER 2D FUNCTION
    void OnTriggerEnter2D(Collider2D collision)
    {
        //HITPOINTS
        if (collision.gameObject.tag == "Enemy Bullet")
            health--;
        if (collision.gameObject.tag == "Death")
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //MOVEMENT
        if (Platformer == true)
        {
            if (collision.gameObject.layer == 0)
            {
                grounded = true;
                jumpCount = 0;
            }
        }
    }
    #endregion
    #region ON TRIGGER STAY 2D FUNCTION
    void OnTriggerStay2D(Collider2D collision)
    {
        if (Platformer == true)
        {
            if (collision.gameObject.layer == 0)
            {
                grounded = true;
                jumpCount = 0;
            }
        }
    }
    #endregion
    #region ON TRIGGER EXIT FUNCTION
    void OnTriggerExit2D(Collider2D collision)
    {
        if (Platformer == true)
        {
            if (collision.gameObject.layer == 0)
                grounded = false;
        }
        if (collision.gameObject.tag == "NextScene")
            FadeToLevel(1);
    }
    #endregion
    //MOVEMENT FUNCTIONS
    #region MOVEMENT SWITCH FUNCTION
    void MovementSwitch()
    {
        if (TopDown == true)
        {
            Platformer = false;
            TrueTopDown = false;
        }
        if (Platformer == true)
        {
            TopDown = false;
            TrueTopDown = false;
        }
        if (TrueTopDown == true)
        {
            TopDown = false;
            Platformer = false;
        }
    }
    #endregion
    #region TOP DOWN MOVEMENT FUNCTION
    void TopDownMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 moveDir = new Vector2(x, y);
        GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
    }
    #endregion
    #region TRUE TOP DOWN MOVEMENT
    void TrueTopDownMovement()
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
    #endregion
    #region PLATFORMER MOVEMENT FUNCTION
    void PlatformerMovement()
    {
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
            Jump();
        float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveSpeed * moveX;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
    #endregion
    #region JUMP FUNCTION
    void Jump()
    {
        if (!grounded)
            jumpCount++;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
        jumpCount++;
    }
    #endregion
    //ATTACK FUNCTIONS
    #region SHOOT FUNCTION
    void Shoot()
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer > shootDelay)
        {
            timer = 0;
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            Vector3 mousePostion = Input.mousePosition;
            mousePostion = Camera.main.ScreenToViewportPoint(mousePostion);
            Vector2 shootDir = new Vector2(mousePostion.x - transform.position.x, mousePostion.y - transform.position.y);
            shootDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
            Destroy(bullet, bulletLifetime);
        }
    }
    #endregion
    //SAVE FUNCTIONS
    #region SAVE PLAYER DATA FUNCTION
    public void SavePlayerData()
    {
        //SaveSystem.SavePlayer(this);
    }
    #endregion
    #region LOAD PLAYER DATA FUNCTION
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
    #endregion
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
}
  