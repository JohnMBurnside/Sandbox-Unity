using UnityEngine;
public class ArrowScript : MonoBehaviour
{
    #region VARIABLES
    public int attackDamage;
    float timer = 0;
    #endregion
    //UNITY FUNCTIONS
    #region UPDATE FUNCTION
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
            Destroy(gameObject);
    }
    #endregion
    #region ON TRIGGER ENTER 2D FUNCTION
    void OnTriggerEnter2D(Collider2D collision){Destroy(gameObject);}
    #endregion
}