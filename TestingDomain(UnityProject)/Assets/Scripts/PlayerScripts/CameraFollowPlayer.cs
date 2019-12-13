using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollowPlayer : MonoBehaviour
{
    //VARIABLES                     //VARIABLES
    [Header("General Settings")]    //GENERAL VARIABLES
    public Transform player;        //Player position/transform
    //UPDATE FUNCTION
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
