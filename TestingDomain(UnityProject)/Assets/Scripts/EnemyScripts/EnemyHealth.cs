using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    //VARIABLES                             //VARIABLES
    [Header("Health Settings")]             //HEALTH VARIABLES
    public int health = 3;                  //How much health the enemy has
    //UPDATE FUNCTION
    void Update()
    {
        if (health < 1)
            Destroy(gameObject);
    }
    //TRIGGER FUNCTION
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health--;
        }
    }
}
