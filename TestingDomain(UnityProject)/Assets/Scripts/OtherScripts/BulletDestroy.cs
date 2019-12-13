using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletDestroy : MonoBehaviour
{
    //DESTROY FUNCTION
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Destroy(gameObject);
    }
}