using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    #region VARIABLES
    [Header("Hitpoint Settings")]
    public int health = 5;
    public int lives;
    [Header("Testing Only")]
    public bool LifeTesting;
    #endregion
    #region START FUNCTION
    void Start()
    {
        //Set life variables
        lives = PlayerPrefs.GetInt("lives");
    }
    #endregion
    #region UPDATE FUNCTION
    void Update()
    {
        //Testing
        if (LifeTesting == true && Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerPrefs.SetInt("lives", 3);
            lives = PlayerPrefs.GetInt("lives");
        }
    }
    #endregion
    #region ON COLLISION ENTER 2D
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "enemy")
        {
            health--;
            if(health < 1)
            {
                PlayerPrefs.SetInt("lives", lives - 1);
                lives = PlayerPrefs.GetInt("lives");
                if (lives < 0)
                    SceneManager.LoadScene("Game Over");
                else
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    #endregion
}
