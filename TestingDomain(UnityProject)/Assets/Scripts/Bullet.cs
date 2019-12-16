using UnityEngine;
public class Bullet : MonoBehaviour
{
    //UNITY FUNCTIONS
    #region ON COLLISION ENTER 2D FUNCTION
    void OnCollisionEnter2D(Collision2D collision)
    {
            Destroy(gameObject);
    }
    #endregion
}