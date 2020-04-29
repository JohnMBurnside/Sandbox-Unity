using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    #region VARIABLES
    public float health = 50f;
    #endregion
    //ENEMY FUNCTIONS
    #region TAKE DAMAGE FUNCTION
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
            Destroy(gameObject);
    }
    #endregion
}