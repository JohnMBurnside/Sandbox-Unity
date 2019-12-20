using UnityEngine;
using UnityEngine.SceneManagement;
public class UIScript : MonoBehaviour
{
    #region VARIABLES
    [Header("General Variables")]
    public Animator animator;
    string levelToLoad;
    [ReadOnly] public GameObject player;
    #endregion
    //UNITY FUNCTIONS
    #region START FUNCTION
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player/");
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