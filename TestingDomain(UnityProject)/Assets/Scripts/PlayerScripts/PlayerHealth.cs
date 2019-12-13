using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    //VARIABLES                         //VARIABLES
    [Header("General Settings")]        //GENERAL VARIABLES
    public Slider healthSlider;         //Health slider
    [Header("Hitpoint Settings")]       //HITPOINT VARIABLES
    public int health = 5;              //Player health    
    public int lives = 3;               //Player lives
    //START FUNCTION
    void Start()
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
    //UPDATE FUNCTION
    void Update()
    {
        if(health < 1)
        {
            if (lives < 0)
                SceneManager.LoadScene("GameOver");
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    //TRIGGER FUNCTION
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy Bullet")
        {
            health--;
            healthSlider.value = health;
        }
        if (collision.gameObject.tag == "Death")
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
