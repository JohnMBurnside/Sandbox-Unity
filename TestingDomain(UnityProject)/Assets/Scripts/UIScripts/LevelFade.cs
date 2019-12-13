using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelFade : MonoBehaviour
{
    #region VARAIBLES
    [Header("General Settings")]
    public Animator animator;
    #endregion
    //UNITY FUNCTIONS
    #region UPDATE FUNCTION
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FadeToLevel(1);
        }
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
