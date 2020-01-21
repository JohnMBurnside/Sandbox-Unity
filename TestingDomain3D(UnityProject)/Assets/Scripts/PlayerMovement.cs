#region NAMESPACES
using UnityEngine;
#endregion
public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES
    Rigidbody rigid;
    public float MouseSensitivity;
    public float MoveSpeed;
    public float JumpForce;
    #endregion
    //UNITY FUNCTIONS
    #region START FUNCTION
    void Start(){rigid = GetComponent<Rigidbody>();}
    #endregion
    #region UPDATE FUNCTION 
    void Update()
    {
        rigid.MoveRotation(rigid.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
        rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
        if (Input.GetKeyDown(KeyCode.Space))
            rigid.AddForce(transform.up * JumpForce);
    }
    #endregion
}
