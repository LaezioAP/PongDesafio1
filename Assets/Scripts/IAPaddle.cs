using UnityEngine;

public class IAPaddle : MonoBehaviour
{
    //Public variable
    public float speed;


    // Private variables
    private Transform ball;
    private float posicaoLimite;

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    private void Update()
    {
        if (ball.position.y > transform.position.y)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        } 
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        posicaoLimite = Mathf.Clamp(transform.position.y, -4.10f, 4.10f);

        transform.position = new Vector2(transform.position.x, posicaoLimite);
    }   
}