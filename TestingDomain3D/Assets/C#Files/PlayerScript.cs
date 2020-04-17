using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    #region VARIABLES
    [Header("Movement Settings")]
    public float speed = 12;
    public float gravityForce = 1;
    CharacterController characterController;
    const float gravity = -9.81f;
    Vector3 velocity;
    [Header("Jumping Settings")]
    public float jumpHeight = 6f;
    [Header("Ground Check Settings")]
    public Transform groundCheckTransform;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    [Header("Level Settings")]
    public string levelToLoad;
    #endregion
    //UNITY FUNCTIONS
    #region START FUNCTION
    void Start() { characterController = GetComponent<CharacterController>(); }
    #endregion
    #region UPDATE FUNCTION
    void Update()
    {
        //Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        //Gravity
        isGrounded = Physics.CheckSphere(groundCheckTransform.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
        velocity.y += gravity * gravityForce * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
    #endregion
    #region ON TRIGGER ENTER FUNCTION
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "LevelTrigger")
            SceneManager.LoadScene(levelToLoad);
    }
    #endregion
    #region ON DRAW GIZMOS SELECTED FUNCTION
    void OnDrawGizmosSelected() { Gizmos.DrawWireSphere(groundCheckTransform.position, groundDistance); }
    #endregion
}
