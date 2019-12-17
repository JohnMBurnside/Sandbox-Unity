using UnityEngine;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    #region VARAIBLES
    [Header("General Settings")]
    public Animator animator;
    public bool MainMenuSwitch;
    public bool PauseMenuSwitch;
    public bool Fade;
    #endregion
    //UNITY FUNCTIONS
    #region UPDATE FUNCTION
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PauseMenuSwitch == true)
        {
            GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
    }
    #endregion
    //MAIN MENU FUNCTIONS
    #region START GAME FUNCTION
    public void StartGame()
    {
        if(MainMenuSwitch == true)
            SceneManager.LoadScene("Testing");
    }
    #endregion
    #region EXIT GAME FUNCTION
    public void ExitGame()
    {
        if (MainMenuSwitch == true)
            Application.Quit();
    }
    #endregion
    //PAUSE MENU FUNCTIONS
    #region START FUNCTION
    void Start()
    {
        if(PauseMenuSwitch == true)
            GetComponent<Canvas>().enabled = false;
    }
    #endregion
    #region RESUME FUNCTION
    public void Resume()
    {
        if(PauseMenuSwitch == true)
        {
            GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
        }
    }
    #endregion
    #region RESTART FUNCTION
    public void Restart()
    {
        if(PauseMenuSwitch == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
        }
    }
    #endregion
    #region MAIN MENU FUNCTION
    public void MainMenu()
    {
        if(PauseMenuSwitch == true)
        {
            SceneManager.LoadScene("Main Menu");
            GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
        }
    }
    #endregion
    //FADE FUNCTIONS
    #region FADE TO LEVEL FUNCTION
    public void FadeToLevel(int levelIndex)
    {
        if(Fade == true)
            animator.SetTrigger("FadeOut");
    }
    #endregion
    #region ON FADE COMPLETE FUNCTION
    public void OnFadeComplete()
    {
        if(Fade == true)
            SceneManager.LoadScene("Testing Domain #5");
    }
    #endregion
}
