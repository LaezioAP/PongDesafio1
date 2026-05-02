using UnityEngine;

public class IAPaddle : MonoBehaviour
{
    //Public variable
    public float speed;

    // Private variables
    private Transform ball;

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
    }   
}