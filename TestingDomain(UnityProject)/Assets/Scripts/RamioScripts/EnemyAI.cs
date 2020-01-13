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
    public float arrowSpeed = 10f;
    float shootTimer;
    [Header("Movement Settings")]
    public Vector2 moveDir;
    public int moveSpeed;
    public int paceDuration;
    float moveTimer = 0;
    GameObject player;
    Vector2 chaseDirection;
    bool left;
    #endregion
    //UNITY FUNCTIONS
    #region START FUNCTION
    void Start()
    {
        player = GameObject.Find("Player");
        attackDamage = weapon.damage;
    }
    #endregion
    #region UPDATE FUNCTION
    void Update()
    {
        shootTimer += Time.deltaTime;
        try{chaseDirection = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);}
        catch{Debug.LogWarning("Player not found. Try renaming the player to 'Player' with a capital P");}
        if (chaseDirection.magnitude < engageRange)
            Attack();
        else
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        if (GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
        {
            moveTimer += Time.deltaTime;
            GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
        }
        if (moveTimer > paceDuration)
            PaceSwitch();
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
        left = !left;
        moveDir *= -1;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        moveTimer = 0;
    }
    #endregion
    #region ATTACK FUNCTION
    void Attack()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        if(shootTimer > attackRate)
        {
            GameObject arrow = Instantiate(projectile, firePoint.position, firePoint.rotation);
            if (left == true)
                arrow.GetComponent<Rigidbody2D>().velocity = (transform.right *= -1) * arrowSpeed;
            else
                arrow.GetComponent<Rigidbody2D>().velocity = transform.right * arrowSpeed;
            arrow.GetComponent<ArrowScript>().attackDamage = attackDamage;
            shootTimer = 0;
        }
    }
    #endregion
}
