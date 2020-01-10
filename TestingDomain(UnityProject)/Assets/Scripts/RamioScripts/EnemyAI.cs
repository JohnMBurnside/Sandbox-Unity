using System.Collections;
using UnityEngine;
public class EnemyAI : MonoBehaviour
{
    #region VARIABLES
    [Header("Weapon Settings")]
    public Weapon weapon;
    public GameObject projectile;
    [HideInInspector] public int attackDamage;
    [Header("Combat Settings")]
    public Transform firePoint;
    public float engageRange;
    public float attackRate = 2f;
    float shootTimer;
    [Header("Movement Settings")]
    public Vector2 moveDir;
    public int moveSpeed;
    public int paceDuration;
    float moveTimer = 0;
    GameObject player;
    Vector2 chaseDirection;
    float timer;
    #endregion
    //UNITY FUNCTIONS
    #region START FUNCTION
    void Start()
    {
        player = GameObject.Find("Player");
    }
    #endregion
    #region UPDATE FUNCTION
    void Update()
    {
        timer += Time.deltaTime;
        moveTimer += Time.deltaTime;
        if (moveTimer > paceDuration)
            PaceSwitch();
        try{chaseDirection = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);}
        catch{Debug.LogWarning("Player not found. Try renaming the player to 'Player' with a capital P");}
        if (chaseDirection.magnitude < engageRange)
            Attack();
        else
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        if (GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
            GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
        if (timer > 10)
            Destroy(gameObject);
    }
    #endregion
    #region ON DRAW GIZMO SELECTED FUNCTION
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(256, 0, 0);
        if (transform.position != null)
            Gizmos.DrawWireSphere(transform.position, engageRange);
        else
            return;
    }
    #endregion
    //ENEMY AI FUNCTIONS
    #region PACE SWITCH FUNCTION
    void PaceSwitch()
    {
        moveDir *= -1;
        moveTimer = 0;
    }
    #endregion
    #region ATTACK FUNCTION
    void Attack()
    {
        shootTimer += Time.deltaTime;
        shootTimer += Time.deltaTime;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        if(shootTimer > attackRate)
        {
            Instantiate(projectile, firePoint.position, firePoint.rotation);
            GameObject arrow = GameObject.FindGameObjectWithTag("Enemy Bullet");
            arrow.GetComponent<EnemyArrowScript>().damage = attackDamage;
            shootTimer = 0;
        }
    }
    #endregion
}
