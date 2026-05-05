using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMenu : MonoBehaviour
{

    [Header("UI Elements")]
    public GameObject PlayModeMenu;
    public GameObject DifficultyMenu;

    void Start()
    {
        PlayModeMenu.SetActive(false);
        DifficultyMenu.SetActive(false);
    }
    public void OpenPlayModeMenu(GameObject buttonObj)
    {
        // O check de nulidade é o seu melhor amigo no C#
        if (buttonObj == null)
        {
            Debug.LogWarning("Nenhum objeto foi passado para a função!");
            return;
        }

        if (buttonObj.name == "BackMenuPlayMode")
        {
            DifficultyMenu.SetActive(false);
            return;
        }

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

    public void OpenDifficultyAiMenu()
    {
        GameSettings.isVsAI = true;
        DifficultyMenu.SetActive(true);
    }

    public void toChooseNormalGame()
    {
        DifficultyMenu.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void toChooseHardGame()
    {
        GameSettings.cpuDifficulty = 1.0f;
        DifficultyMenu.SetActive(false);
        SceneManager.LoadScene("Game");
    }
    public void PlayVsAiMode()
    {

        Debug.Log("Teste");
    }

    public void PlayVsPlayerMode()
    {
        GameSettings.isVsAI = false;
        SceneManager.LoadScene("Game");
    }
}
