using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMenu : MonoBehaviour
{

    [Header("UI Elements")]
    public GameObject PlayModeMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayModeMenu.SetActive(false);
    }
    public void OpenPlayModeMenu()
    {
        PlayModeMenu.SetActive(true);
    }
    public void ClosePlayModeMenu()
    {
        PlayModeMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayVsAiMode() 
    {
        GameSettings.isVsAI = true;
        SceneManager.LoadScene("Game");
    }

    public void PlayVsPlayerMode()
    {
        GameSettings.isVsAI = false;
        SceneManager.LoadScene("Game");
    }
}
