using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    #region VARIABLES
    [Header("Health Settings")]
    public int maxHealth = 5;
    int currentHealth;
    #endregion
    #region START FUNCTION
    void Start()
    {
        currentHealth = maxHealth;
    }
    #endregion
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
}
