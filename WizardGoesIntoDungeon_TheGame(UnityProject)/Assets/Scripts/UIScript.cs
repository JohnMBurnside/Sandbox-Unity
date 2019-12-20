using UnityEngine;
using UnityEngine.SceneManagement;
public class UIScript : MonoBehaviour
{
    #region VARIABLES
    [Header("General Variables")]
    public Animator animator;
    string levelToLoad;
    GameObject player;
    #endregion
    //UNITY FUNCTIONS
    #region START FUNCTION
    void Start()
    {
        try
        {
            animator = GetComponent<Animator>();
        }
        finally
        {
            Debug.Log("Animator Not Found");
            animator = null;
        }
        try
        {
            player = GameObject.Find("Player/");
        }
        finally
        {
            Debug.Log("Player Not Found");
            player = null;
        }
    }
    #endregion
    #region UPDATE FUNCTION
    void Update()
    {
        if (player.GetComponent<PlayerScript>().loadLevel == true)
            FadeToLevel("LevelTwo");
    }
    #endregion
    //UI FUNCTIONS
    #region START GAME FUNCTION
    public void StartGame()
    {
        SceneManager.LoadScene("LevelOne");
    }
    #endregion
    #region QUIT FUNCTION
    public void Quit()
    {
        Application.Quit();
    }
    #endregion
    #region FADE TO LEVEL FUNCTION
    public void FadeToLevel(string levelName)
    {
        levelToLoad = levelName;
        animator.SetTrigger("FadeOut");
    }
    #endregion
    #region ON FADE COMPLETE FUNCTIOn
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    #endregion
}