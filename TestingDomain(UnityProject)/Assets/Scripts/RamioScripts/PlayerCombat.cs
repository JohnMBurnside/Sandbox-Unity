using UnityEngine;
public class PlayerCombat : MonoBehaviour
{
    #region VARIABLES
    [Header("Weapon Settings")]
    public Weapon weapon;
    [HideInInspector] public int attackDamage;
    [Header("Melee Range Settings")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    [Header("Ranged Attack Settings")]
    public Transform firePoint;
    public GameObject arrowPrefab;
    [Header("Delay Settings")]
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    #endregion
    //UNITY FUNCTIONS
    #region START FUNCTION
    void Start()
    {
        attackDamage = weapon.damage;
    }
    #endregion
    #region UPDATE FUNCTION
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    #endregion
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
        }
        //Shoot
        if (weapon.weaponType == Weapon.Weapons.bow)
            Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
    #endregion
}
