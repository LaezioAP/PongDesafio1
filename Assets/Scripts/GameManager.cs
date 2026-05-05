using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int playerScore;
    public int AIScore;
    int winningScore = 5;

    [Header("Objetos do Jogo")]
    public GameObject isPlayerTwo;
    public GameObject isAI;


    [Header("Audios")]
    public AudioSource audioSource;
    public AudioClip pointScored;

    [Header("UI Elements")]
    public GameObject endGamePanel;
    public TextMeshProUGUI endGameText;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI AIScoreText;

    public void PlayerPoint()
    {
        ShakePoint(playerScoreText);
        playerScore++;
        playerScoreText.text = playerScore.ToString();

        if (playerScore == winningScore)
        {
            EndGame();
        }
    }

    public void IAPoint()
    {
        ShakePoint(AIScoreText);
        AIScore++;
        AIScoreText.text = AIScore.ToString();
        if (AIScore == winningScore)
        {
            EndGame();
        }
    }

    public void ShakePoint(TextMeshProUGUI scoreText)
    {
        audioSource.PlayOneShot(pointScored);

        scoreText.transform.DOKill();
        scoreText.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        scoreText.transform.DOScale(1.0f, 0.4f).SetLoops(2, LoopType.Yoyo);

        scoreText.DOColor(Color.green, 0.4f).SetLoops(2, LoopType.Yoyo);
    }

    public void Start()
    {
        endGamePanel.SetActive(false);
        Time.timeScale = 1f;

        isAI.SetActive(GameSettings.isVsAI);
        isPlayerTwo.SetActive(!GameSettings.isVsAI);

    }

    public void EndGame()
    {
        endGamePanel.SetActive(true);
        if (playerScore == winningScore)
        {

            endGameText.text = "Player 1 Wins!";
        }
        else if (AIScore == winningScore)
        {

            if (isPlayerTwo.activeSelf)
            {
                endGameText.text = "Player 2 Wins!";
            }
            else
            {
                endGameText.text = "AI Wins!";
            }
        }
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("O jogador saiu do jogo!");
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
