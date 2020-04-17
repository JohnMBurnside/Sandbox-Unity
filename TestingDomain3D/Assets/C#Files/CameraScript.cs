using UnityEngine;
public class CameraScript : MonoBehaviour
{
    #region VARIABLES
    public float mouseSen = 100f;
    public Transform player;
    public float xRotation = 0;
    #endregion
    //UNITY FUNCTIONS
    #region START FUNCTION
    void Start() {  Cursor.lockState = CursorLockMode.Locked; }
    #endregion
    #region UPDATE FUNCTION
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSen * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSen * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
    #endregion
}
