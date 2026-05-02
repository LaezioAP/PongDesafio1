using UnityEngine;

public class Wall : MonoBehaviour
{

    public GameManager manager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball"  && gameObject.name == "LeftWall")
        {
            manager.IAPoint();
            
        } else
        {
            manager.PlayerPoint();
        }

        collision.gameObject.GetComponent<Ball>().ResetBall();
    }
}
