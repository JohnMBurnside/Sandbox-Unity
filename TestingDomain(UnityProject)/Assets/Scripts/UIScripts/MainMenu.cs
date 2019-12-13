using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //START GAME FUNCTION
    public void StartGame()
    {
        SceneManager.LoadScene("Testing");
    }
    //EXIT GAME FUNCTION
    public void ExitGame()
    {
        Application.Quit();
    }
}
