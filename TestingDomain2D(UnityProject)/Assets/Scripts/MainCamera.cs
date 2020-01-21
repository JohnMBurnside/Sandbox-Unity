using UnityEngine;
public class MainCamera : MonoBehaviour
{
    #region VARIABLES
    [Header("General Settings")]    
    public Transform player;
    #endregion
    //UNITY FUNCTIONS
    #region UPDATE FUNCTION
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
    #endregion
}
