﻿using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    #region VARAIBLES
    [Header("Movement Settings")]
    public float moveSpeed = 5.0f;
    public float jumpSpeed = 5.0f;
    public float fallMultiplier = 5.0f;
    public float lowJumpMultiplier = 2.5f;
    public bool doubleJump;
    [ReadOnly] public bool grounded;
    [ReadOnly] public int jumpCount;
    Rigidbody2D playerRigidbody;
    [Header("Auto Run Settings")]
    public bool autoRun;
    public int autoRunSpeed = 10;
    [ReadOnly] public bool autoRunOn;
    [ReadOnly] public float textTimer;
    [ReadOnly] public GameObject autoRunText;
    [ReadOnly] public GameObject autoRunOffText;
    [Header("Animation Settings")]
    Animator animator;
    [Header("Camera Settings")]
    [ReadOnly] public GameObject mainCamera;
    [ReadOnly] public float cameraX;
    [ReadOnly] public float cameraY;
    [ReadOnly] public float exitTimer;
    bool onExit;
    #endregion
    //UNITY FUNCTIONS
    #region START FUNCTION
    void Start()
    {
        //SET JUMP VARIABLES
        playerRigidbody = GetComponent<Rigidbody2D>();
        doubleJump = false;
        //SET AUTO RUN VARIABLES
        autoRunText = GameObject.Find("UI/AutoRunAlerts/AutoRunText");
        autoRunText.SetActive(false);
        autoRunOffText = GameObject.Find("UI/AutoRunAlerts/AutoRunOffText");
        autoRunOffText.SetActive(false);
        //SET ANIMATION VAIABLES
        animator = GetComponent<Animator>();
        //SET CAMERA VARIABLES
        mainCamera = GameObject.Find("Player/MainCamera");
    }
    #endregion
    #region UPDATE FUNCTION
    void Update()
    {
        //RUN MOVEMENT AND AUTO RUN
        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = 7;
        else
            moveSpeed = 5;
        if (autoRunOn == false)
        {
            //MOVEMENT
            float moveX = Input.GetAxis("Horizontal");
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.x = moveSpeed * moveX;
            GetComponent<Rigidbody2D>().velocity = velocity;
            //ANIMATION
            animator.SetFloat("x", velocity.x);
            animator.SetFloat("y", velocity.y);
            //TIMER
            textTimer += Time.deltaTime;
            if (textTimer > 3)
                autoRunOffText.SetActive(false);
        }
        else
        {
            //MOVEMENT
            float moveX = 1.0f;
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.x = autoRunSpeed * moveX;
            GetComponent<Rigidbody2D>().velocity = velocity;
            //ANIMATION
            animator.SetFloat("x", velocity.x);
            animator.SetFloat("y", velocity.y);
            //TIMER
            textTimer += Time.deltaTime;
            if (textTimer > 3)
                autoRunText.SetActive(false);
        }
        //DOUBLE JUMP AND NORMAL JUMP
        if (Input.GetButtonDown("Jump") && doubleJump == false && grounded == true)
            Jump();
        else if (Input.GetButtonDown("Jump") && jumpCount < 2 && doubleJump == true)
            Jump();
        if (playerRigidbody.velocity.y < 0)
            playerRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (playerRigidbody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            playerRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        //ANIMATION       
        animator.SetBool("grounded", grounded);
        float x = Input.GetAxisRaw("Horizontal");
        if (autoRunOn == true)
            GetComponent<SpriteRenderer>().flipX = false;
        else
        {
            if (x > 0)
                GetComponent<SpriteRenderer>().flipX = false;
            else if (x < 0)
                GetComponent<SpriteRenderer>().flipX = true;
        }
        //EXIT
        if (onExit == true)
            OnExit();
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
        //EXIT TRIGGER
        if (collision.gameObject.CompareTag("Exit"))
        {
            exitTimer = 0;
            cameraX = mainCamera.GetComponent<Transform>().position.x;
            cameraY = mainCamera.GetComponent<Transform>().position.y;
            onExit = true;
        }
        //DEATH TRIGGER
        if (collision.gameObject.CompareTag("Death"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //AUTO RUN
        if (collision.gameObject.CompareTag("AutoRun"))
        {
            if(autoRun == true)
            {
                if (autoRunOn == false)
                {
                    textTimer = 0;
                    autoRunOn = true;
                    autoRunText.SetActive(true);
                }
            }
        }
        if(collision.gameObject.CompareTag("AutoRunOff"))
        {
            if(autoRun == true)
            {
                textTimer = 0;
                autoRunOn = false;
                autoRunOffText.SetActive(true);
            }
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
    #region ON EXIT FUNCTION
    void OnExit()
    {
        exitTimer += Time.deltaTime;
        mainCamera.GetComponent<Transform>().position = new Vector3(cameraX, cameraY, -10);
        if (exitTimer > 3)
            SceneManager.LoadScene("LevelTwo");
    }
    #endregion
}
