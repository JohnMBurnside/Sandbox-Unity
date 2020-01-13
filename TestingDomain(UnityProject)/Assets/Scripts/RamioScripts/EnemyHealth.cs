using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    #region VARIABLES
    [Header("Health Settings")]
    public int maxHealth = 5;
    int currentHealth;
    #endregion
    //UNITY FUNCTIONS
    #region START FUNCTION
    void Start(){currentHealth = maxHealth;}
    #endregion
    #region ON TRIGGER ENTER 2D FUNCTION
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player Arrow"))
            TakeDamage(collision.gameObject.GetComponent<ArrowScript>().attackDamage);
    }
    #endregion
    //ENEMY HEALTH FUNCTIONS
    #region TAKE DAMAGE FUNCTION
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //Play damage animation
        if(currentHealth <= 0)
        {
            //Play death animation
            Destroy(gameObject);
        }
    }
    #endregion
}