using UnityEngine;
public class Enemy : MonoBehaviour
{
    #region VARIABLES
    [Header("General Settings")]
    public Transform Player;
    public GameObject prefab;
    public Vector2 paceDirection;
    public Vector3 startPosition;
    public Transform player;
    bool home = true;
    public bool trueTopDown = false;
    [Header("Hitpoint Settings")]
    public int health = 3;
    [Header("AI Movement Settings")]
    public float chaseSpeed = 2f;
    public float paceSpeed = 1.5f;
    public float paceDistance = 3.0f;
    public float chaseTriggerDistance = 5.0f;
    [Header("Shoot Settings")]
    public float bulletSpeed = 10.0f;
    public float bulletLifetime = 1.0f;
    public float shootDelay = 1.0f;
    float timer = 0;
    #endregion
    //UNITY FUNCTIONS
    #region START FUNCTION
    void Start()
    {
        startPosition = transform.position;
    }
    #endregion
    #region UPDATE FUNCTION
    void Update()
    {
        //HITPOINTS
        if (health < 1)
            Destroy(gameObject);
        //AI MOVEMENT
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
        //SHOOTING
        Shoot();
    }
    #endregion
    #region ON TRIGGER ENTER 2D FUNCTION
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
            health--;
    }
    #endregion
    //ENEMY FUNCTIONS
    #region CHASE FUNCTION
    void Chase()
    {
        home = false;
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        chaseDirection.Normalize();
        if (trueTopDown == true)
            transform.up = chaseDirection;
        GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
    }
    #endregion
    #region GO HOME FUNCTION
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
    #endregion
    #region PACE FUNCTION
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
    #endregion
    #region SHOOT FUNCTION
    void Shoot()
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
    #endregion
}
