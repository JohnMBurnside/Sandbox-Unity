using UnityEngine;
public class PlayerCombat : MonoBehaviour
{
    #region VARIABLES
    [Header("Weapon Settings")]
    public Weapon weapon;
    public int attackDamage;
    [Header("Melee Range Settings")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    [Header("Ranged Attack Settings")]
    public Transform firePoint;
    public GameObject arrowPrefab;
    [Header("Delay Settings")]
    public float attackDelay= 2;
    public float attackTimer;
    [Header("Arrow Settings")]
    public float speed = 10f;
    #endregion
    //UNITY FUNCTIONS
    #region START FUNCTION
    void Start()
    { 
        if (gameObject.name == "Player" || gameObject.name == "player")
            attackDamage = weapon.damage;
    }
    #endregion
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > attackDelay)
            if(Input.GetKeyDown(KeyCode.Mouse0))
                Attack();
    }
    #region ON DRAW GIZMO SELECTED FUNCTION
    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        else
            return;
    }
    #endregion
    //COMBAT FUNCTIONS
    #region ATTACK FUNCTION
    void Attack()
    {
        //Melee Attack
        if(weapon.weaponType == Weapon.Weapons.sword)
        {
            //Play attack animation
            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach (Collider2D enemy in enemiesHit)
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            attackTimer = 0;
        }
        //Shoot
        if (weapon.weaponType == Weapon.Weapons.bow)
        {
            Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
            GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
            arrow.GetComponent<Rigidbody2D>().velocity = (mousePosition - firePointPosition) * speed;
            arrow.AddComponent<ArrowScript>().attackDamage = attackDamage;
            attackTimer = 0;
        }
    }
    #endregion
}