using UnityEngine;
using UnityEngine.SceneManagement;
public class UIScript : MonoBehaviour
{
    #region VARIABLES
    public enum UIOptions{MainMenu, PauseMenu}
    public UIOptions UI;
    bool pauseOn;
    #endregion
    //UNITY FUNCTIONS
    #region START FUNCTION
    void Start()
    {
        if (UI == UIOptions.PauseMenu)
            GetComponent<Canvas>().enabled = false;
    }
    #endregion
    #region UPDATE FUNCTION
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseOn == false && UI == UIOptions.PauseMenu)
        {
            GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
            pauseOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseOn == true && UI == UIOptions.PauseMenu)
        {
            GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
            pauseOn = false;
        }
    }
    #endregion
    //UI FUNCTIONS
    #region START GAME FUNCTION
    public void StartGame()
    {
        PlayerPrefs.SetInt("lives", 3);
        SceneManager.LoadScene("Testing");
    }
    #endregion
    #region EXIT GAME FUNCTION
    public void ExitGame(){Application.Quit();}
    #endregion
    #region RESUME FUNCTION
    public void Resume()
    {
        GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }
    #endregion
    #region RESTART FUNCTION
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }
    #endregion
    #region MAIN MENU FUNCTION
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }
    #endregion
}
