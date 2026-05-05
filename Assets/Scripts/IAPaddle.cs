using UnityEngine;

public class IAPaddle : MonoBehaviour
{
    //Public variable
    public float speed;
    float speedWithDifficulty;


    // Private variables
    private Transform ball;
    private Rigidbody2D ballRb;
    private float posicaoLimite;

    private void Start()
    {
        GameObject ballObject = GameObject.FindGameObjectWithTag("Ball");
        ball = ballObject.transform;
        ballRb = ballObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (ballRb.linearVelocity.x > 0)
        {
            MoverAI();
        }

    }

    void MoverAI()
    {
        float speedWithDifficulty = speed * GameSettings.cpuDifficulty;
        Debug.Log("Velocidade da IA: " + speedWithDifficulty);
        Debug.Log("Dificuldade da IA: " + GameSettings.cpuDifficulty);

        if (ball.position.y > transform.position.y)
        {
            transform.Translate(Vector2.up * speedWithDifficulty * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speedWithDifficulty * Time.deltaTime);
        }

        posicaoLimite = Mathf.Clamp(transform.position.y, -4.07f, 4.07f);

        transform.position = new Vector2(transform.position.x, posicaoLimite);
    }
}