using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAI : MonoBehaviour
{
    //VARIABLES                                     //VARIABLES
    [Header("General Settings")]                    //GENERAL VARIABLES
    public Vector2 paceDirection;                   //Pace direction for enemy
    public Vector3 startPosition;                   //Starting position for enemy
    public Transform player;                        //Position/transform of player
    bool home = true;                               //Tells whether the enemy is at the start position
    [Header("Pace/Chase Settings")]                 //ENEMY AI BALANCE VARIABLES
    public float chaseSpeed = 2f;                   //How fast the enemy chases the player
    public float paceSpeed = 1.5f;                  //How fast the enemy paces
    public float paceDistance = 3.0f;               //How far the enemy paces before switching directions
    public float chaseTriggerDistance = 5.0f;       //How far the player has to be away to trigger the chase function
    [Header("True Top Down Switch")]                //SWITCH TO TRUE TOP DOWN VARIABLES
    public bool trueTopDown = false;                //Change to true to change the AI to a topdown
    //START FUNCTION
    void Start()
    {
        startPosition = transform.position;
    }
    //UPDATE FUNCTION
    void Update()
    {
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        if (chaseDirection.magnitude < chaseTriggerDistance)
        {
            Chase();
        }
        else if (!home)
        {
            GoHome();
        }
        else
        {
            Pace();
        }
    }
    //CHASE FUNCTION
    void Chase()
    {
        home = false;
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        chaseDirection.Normalize();
        if(trueTopDown == true)
            transform.up = chaseDirection;
        GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
    }
    //GO HOME FUNCTION
    void GoHome()
    {
        Vector2 homeDirection = new Vector2(startPosition.x - transform.position.x, startPosition.y - transform.position.y);
        if (homeDirection.magnitude < 0.2f)
        {
            transform.position = startPosition;
            home = true;
        }
        else
        {
            homeDirection.Normalize();
            if (trueTopDown == true)
                transform.up = homeDirection;
            GetComponent<Rigidbody2D>().velocity = homeDirection * paceSpeed;
        }
    }
    //PACE FUNCTION
    void Pace()
    {
        Vector3 displacement = transform.position - startPosition;
        if (displacement.magnitude >= paceDistance)
            paceDirection = -displacement;
        paceDirection.Normalize();
        if (trueTopDown == true)
            transform.up = paceDirection;
        GetComponent<Rigidbody2D>().velocity = paceDirection * paceSpeed;
    }
}
