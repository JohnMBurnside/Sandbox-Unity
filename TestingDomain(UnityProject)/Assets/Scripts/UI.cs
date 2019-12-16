using UnityEngine;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    #region VARAIBLES
    [Header("General Settings")]
    public Animator animator;
    #endregion
    //UNITY FUNCTIONS
    #region UPDATE FUNCTION
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        SceneManager.LoadScene("Testing");
    }
    #endregion
    #region EXIT GAME FUNCTION
    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion
    //PAUSE MENU FUNCTIONS
    #region START FUNCTION
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }
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
    //FADE FUNCTIONS
    #region FADE TO LEVEL FUNCTION
    public void FadeToLevel(int levelIndex)
    {
        animator.SetTrigger("FadeOut");
    }
    #endregion
    #region ON FADE COMPLETE FUNCTIOn
    public void OnFadeComplete()
    {
        SceneManager.LoadScene("Testing Domain #5");
    }
    #endregion
}
