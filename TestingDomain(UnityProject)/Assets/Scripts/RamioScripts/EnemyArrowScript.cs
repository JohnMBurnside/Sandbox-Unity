using UnityEngine;
public class EnemyArrowScript : MonoBehaviour
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
    }
    #endregion
    #region ON TRIGGER ENTER 2D FUNCTION
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth player = collision.GetComponent<PlayerHealth>();
        if (player != null)
            player.TakeDamage(damage);
        Destroy(gameObject);
    }
    #endregion
}
