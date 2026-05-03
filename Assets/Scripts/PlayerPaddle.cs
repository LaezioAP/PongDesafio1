using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPaddle : MonoBehaviour
{
    public float speed;
    private Vector2 directionInput;
    private float posicaoLimite;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * directionInput.y * Time.deltaTime);

        posicaoLimite = Mathf.Clamp(transform.position.y, -4.10f, 4.10f);
        
        transform.position = new Vector2(transform.position.x, posicaoLimite);
    }

    public void OnMove(InputValue value)
    {
        directionInput = value.Get<Vector2>();
    }
}
