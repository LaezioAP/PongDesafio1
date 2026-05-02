using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerScore;
    public int AIScore;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI AIScoreText;

    [Header("Audios")]
    public AudioSource audioSource;
    public AudioClip pointScored;

    public void PlayerPoint()
    {
        ShakePoint(playerScoreText);
        playerScore++;
        playerScoreText.text = playerScore.ToString();
    }

    public void IAPoint()
    {
        ShakePoint(AIScoreText);
        AIScore++;
        AIScoreText.text = AIScore.ToString();
    }

    public void ShakePoint(TextMeshProUGUI scoreText)
    {
        audioSource.PlayOneShot(pointScored);

        scoreText.transform.DOKill();
        scoreText.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        scoreText.transform.DOScale(1.0f, 0.4f).SetLoops(2, LoopType.Yoyo);

        scoreText.DOColor(Color.green, 0.4f).SetLoops(2, LoopType.Yoyo);
    }
}
