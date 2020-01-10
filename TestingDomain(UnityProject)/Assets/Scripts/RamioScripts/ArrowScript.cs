using UnityEngine;
public class ArrowScript : MonoBehaviour
{
    #region VARIABLES
    [Header("Arrow Settings")]
    public float speed = 10f;
    public int damage;
    public Rigidbody2D rb;
    #endregion
    //UNITY FUNCTIONS
    #region START FUNCTION
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        GameObject player = GameObject.Find("Player");
        damage = player.GetComponent<PlayerCombat>().attackDamage;
    }
    #endregion
    #region ON TRIGGER ENTER 2D FUNCTION
    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
            enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
    #endregion
}
