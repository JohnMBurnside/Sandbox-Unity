using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyShoot : MonoBehaviour
{
    //VARIABLES                             //VARIABLES
    [Header("General Settings")]            //GENERAL VARIABLES
    public Transform Player;                //The position/transform of the player
    public GameObject prefab;               //The bullet prefab
    [Header("Bullet Settings")]             //BULLET VARIABLES
    public float bulletSpeed = 10.0f;       //Bullet speed
    public float bulletLifetime = 1.0f;     //How long the bullet lasts before destroying
    public float shootDelay = 1.0f;         //How long the enemy has to wait before shooting again
    float timer = 0;                        //Timer
    //UPDATE FUNCTION
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > shootDelay)
        {
            timer = 0;
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            Vector3 mousePostion = Input.mousePosition;
            Vector2 shootDir = new Vector2(mousePostion.x - transform.position.x, mousePostion.y - transform.position.y);
            shootDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
            Destroy(bullet, bulletLifetime);
        }
    }
}